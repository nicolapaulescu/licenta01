using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using maibagamofisa.Data;
using maibagamofisa.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace maibagamofisa.Controllers
{
    public class Chapter01Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Chapter01Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var chapters = await GetChaptersAsync();
            return View(chapters);
        }

        private async Task<List<Chapter01>> GetChaptersAsync()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "chapters.json");
            var jsonData = await System.IO.File.ReadAllTextAsync(filePath);
            var chaptersData = JsonConvert.DeserializeObject<ChaptersData>(jsonData);
            return chaptersData.Chapter01;
        }

        public async Task<IActionResult> Lessons(int id)
        {
            var chapters = await GetChaptersAsync();
            var chapter = chapters.FirstOrDefault(c => c.Id == id);
            if (chapter == null)
            {
                return NotFound();
            }
            return View(chapter.Lessons);
        }

        public async Task<IActionResult> Exercises(int lessonId)
        {
            var lesson = await GetLessonByIdAsync(lessonId);
            if (lesson == null)
            {
                return NotFound();
            }
            return View(lesson);
        }

        [HttpPost]
        public async Task<IActionResult> CheckAnswer(int lessonId, int exerciseId, string userAnswer)
        {
            var lesson = await GetLessonByIdAsync(lessonId); // Method to get the lesson by ID
            var exercise = lesson?.Exercises.FirstOrDefault(e => e.Id == exerciseId);

            if (exercise == null)
            {
                return NotFound();
            }

            var isCorrect = exercise.CorrectAnswer.Equals(userAnswer, StringComparison.OrdinalIgnoreCase);
            var nextExerciseId = lesson.Exercises.SkipWhile(e => e.Id != exerciseId).Skip(1).FirstOrDefault()?.Id;

            return Json(new { isCorrect, nextExerciseId });
        }

        private async Task<Lesson01> GetLessonByIdAsync(int lessonId)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "chapters.json");
            var jsonData = await System.IO.File.ReadAllTextAsync(filePath);
            var chaptersData = JsonConvert.DeserializeObject<ChaptersData>(jsonData);

            foreach (var chapter in chaptersData.Chapter01)
            {
                var lesson = chapter.Lessons.FirstOrDefault(l => l.Id == lessonId);
                if (lesson != null)
                {
                    return lesson;
                }
            }

            return null;
        }

        public IActionResult RedirectToSpecificPage()
        {
            return RedirectToAction("Lesson01", "Chapter01");
        }

        public IActionResult Lesson01()
        {
            return View();
        }
    }

    public class ChaptersData
    {
        public List<Chapter01> Chapter01 { get; set; }
    }
}
