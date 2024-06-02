using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using maibagamofisa.Models;
using Microsoft.AspNetCore.Authorization;

[Authorize]  // This will restrict access to all actions in this controller
public class LessonsController : Controller
{
    private readonly IWebHostEnvironment _hostingEnvironment;
    private readonly UserManager<IdentityUser> _userManager;

    public LessonsController(IWebHostEnvironment hostingEnvironment, UserManager<IdentityUser> userManager)
    {
        _hostingEnvironment = hostingEnvironment;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var lessons = await GetLessonsAsync();
        return View(lessons);
    }

    public async Task<IActionResult> Details(int id)
    {
        var lessons = await GetLessonsAsync();
        var lesson = lessons.FirstOrDefault(l => l.Id == id);
        if (lesson == null)
        {
            return NotFound();
        }
        return View(lesson);
    }

    [HttpPost]
    public async Task<IActionResult> CompleteLesson(int lessonId)
    {
        var userId = _userManager.GetUserId(User);
        var progress = await GetUserProgressAsync();
        var userProgress = progress.FirstOrDefault(p => p.UserId == userId && p.LessonId == lessonId);

        if (userProgress == null)
        {
            userProgress = new UserProgress
            {
                UserId = userId,
                LessonId = lessonId,
                IsCompleted = true
            };
            progress.Add(userProgress);
        }
        else
        {
            userProgress.IsCompleted = true;
        }

        await SaveUserProgressAsync(progress);
        return RedirectToAction("Details", new { id = lessonId });
    }

    private async Task<List<Lesson>> GetLessonsAsync()
    {
        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "json", "lessons.json");
        var jsonData = await System.IO.File.ReadAllTextAsync(filePath);
        return JsonConvert.DeserializeObject<List<Lesson>>(jsonData);
    }

    private async Task<List<UserProgress>> GetUserProgressAsync()
    {
        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "json", "userProgress.json");
        if (!System.IO.File.Exists(filePath))
        {
            return new List<UserProgress>();
        }
        var jsonData = await System.IO.File.ReadAllTextAsync(filePath);
        return JsonConvert.DeserializeObject<List<UserProgress>>(jsonData);
    }

    private async Task SaveUserProgressAsync(List<UserProgress> progress)
    {
        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "json", "userProgress.json");
        var jsonData = JsonConvert.SerializeObject(progress, Formatting.Indented);
        await System.IO.File.WriteAllTextAsync(filePath, jsonData);
    }
}
