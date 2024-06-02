using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using maibagamofisa.Models;
public class UserProgress
{
    public string UserId { get; set; }
    public int LessonId { get; set; }
    public bool IsCompleted { get; set; }
}

public class LessonsController : Controller
{
    private readonly IWebHostEnvironment _hostingEnvironment;

    public LessonsController(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public async Task<IActionResult> Index()
    {
        var lessons = await GetLessonsAsync();
        return View(lessons); // Passing a list of Lesson objects
    }

    public async Task<IActionResult> Details(int id)
    {
        var lessons = await GetLessonsAsync();
        var lesson = lessons.FirstOrDefault(l => l.Id == id);
        if (lesson == null)
        {
            return NotFound();
        }
        return View(lesson); // Passing a single Lesson object
    }

    private async Task<List<Lesson>> GetLessonsAsync()
    {
        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "json", "lessons.json");
        var jsonData = await System.IO.File.ReadAllTextAsync(filePath);
        return JsonConvert.DeserializeObject<List<Lesson>>(jsonData);
    }

    private async Task SaveLessonsAsync(List<Lesson> lessons)
    {
        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "json", "lessons.json");
        var jsonData = JsonConvert.SerializeObject(lessons, Formatting.Indented);
        await System.IO.File.WriteAllTextAsync(filePath, jsonData);
    }

    public IActionResult SpeechToText()
        {
            return View();
        }
}






