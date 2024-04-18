using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using maibagamofisa.Data;
using maibagamofisa.Models;
using Tesseract;

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


        public List<Dialogue> GetDialogues()
        {
            return _context.Dialogue.ToList();
        }

        [HttpGet]
        public async Task<IActionResult> Extract()
        {
            var dialogues = GetDialogues();
            ViewBag.Dialogues = dialogues;

            return View();
        }






        [HttpPost]
        public async Task<IActionResult> Extract(IFormFile imageFile)
        {
            try
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        imageFile.CopyTo(memoryStream);
                        memoryStream.Position = 0;

                        using (var engine = new TesseractEngine(@"./tesseract/tessdata", language: "deu", EngineMode.Default))
                        {
                            using (var image = Pix.LoadFromMemory(memoryStream.ToArray()))
                            {
                                using (var page = engine.Process(image))
                                {
                                    var extractedText = page.GetText();
                                    ViewData["ExtractedText"] = extractedText;
                                }
                            }
                        }
                    }
                }
                else
                {
                    ViewData["ExtractedText"] = "No image file provided.";
                }
            }
            catch (Exception ex)
            {
                ViewData["ExtractedText"] = "Error processing the image: " + ex.Message;
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SaveText(int dialogueId, string extractedText)
        {
            // Assuming you have a method to retrieve the dialogue by its ID
            var dialogue = await _context.Dialogue.FindAsync(dialogueId);

            if (dialogue == null)
            {
                return NotFound();
            }

            // Assuming you have a property in your Dialogue model to store the extracted text
            dialogue.Content = extractedText;

            _context.Update(dialogue);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
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
                dialogue.Questions = string.Join(";", dialogue.Questions);
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
