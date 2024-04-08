using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using maibagamofisa.Data;
using maibagamofisa.Models;

namespace maibagamofisa.Controllers
{
    public class DialoguesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DialoguesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dialogues
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dialogue.ToListAsync());
        }

        // GET: Dialogues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dialogue = await _context.Dialogue
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dialogue == null)
            {
                return NotFound();
            }

            return View(dialogue);
        }

        // GET: Dialogues/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dialogues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Content,Questions")] Dialogue dialogue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dialogue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dialogue);
        }

        // GET: Dialogues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dialogue = await _context.Dialogue.FindAsync(id);
            if (dialogue == null)
            {
                return NotFound();
            }
            return View(dialogue);
        }

        // POST: Dialogues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Content,Questions")] Dialogue dialogue)
        {
            if (id != dialogue.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dialogue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DialogueExists(dialogue.Id))
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
            return View(dialogue);
        }

        // GET: Dialogues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dialogue = await _context.Dialogue
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dialogue == null)
            {
                return NotFound();
            }

            return View(dialogue);
        }

        // POST: Dialogues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dialogue = await _context.Dialogue.FindAsync(id);
            if (dialogue != null)
            {
                _context.Dialogue.Remove(dialogue);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DialogueExists(int id)
        {
            return _context.Dialogue.Any(e => e.Id == id);
        }
    }
}
