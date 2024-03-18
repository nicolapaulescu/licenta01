using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using maibagamofisa.Models;

namespace maibagamofisa.Controllers
{
    public class VocabularyLessonsController : Controller
    {
        private readonly DeutschlernenproContext _context;

        public VocabularyLessonsController(DeutschlernenproContext context)
        {
            _context = context;
        }

        // GET: VocabularyLessons
        public async Task<IActionResult> Index()
        {
            return View(await _context.VocabularyLessons.ToListAsync());
        }
        


        // GET: VocabularyLessons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vocabularyLesson = await _context.VocabularyLessons
                .FirstOrDefaultAsync(m => m.LessonId == id);
            if (vocabularyLesson == null)
            {
                return NotFound();
            }

            return View(vocabularyLesson);
        }

        // GET: VocabularyLessons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VocabularyLessons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LessonId,LessonName,CoverImagePath,GermanLessonName")] VocabularyLesson vocabularyLesson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vocabularyLesson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vocabularyLesson);
        }

        // GET: VocabularyLessons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vocabularyLesson = await _context.VocabularyLessons.FindAsync(id);
            if (vocabularyLesson == null)
            {
                return NotFound();
            }
            return View(vocabularyLesson);
        }

        // POST: VocabularyLessons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LessonId,LessonName,CoverImagePath,GermanLessonName")] VocabularyLesson vocabularyLesson)
        {
            if (id != vocabularyLesson.LessonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vocabularyLesson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VocabularyLessonExists(vocabularyLesson.LessonId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vocabularyLesson);
        }

        // GET: VocabularyLessons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vocabularyLesson = await _context.VocabularyLessons
                .FirstOrDefaultAsync(m => m.LessonId == id);
            if (vocabularyLesson == null)
            {
                return NotFound();
            }

            return View(vocabularyLesson);
        }

        // POST: VocabularyLessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vocabularyLesson = await _context.VocabularyLessons.FindAsync(id);
            if (vocabularyLesson != null)
            {
                _context.VocabularyLessons.Remove(vocabularyLesson);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VocabularyLessonExists(int id)
        {
            return _context.VocabularyLessons.Any(e => e.LessonId == id);
        }
    }
}
