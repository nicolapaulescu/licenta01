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
    public class VegetablesController : Controller
    {
        private readonly DeutschlernenproContext _context;

        public VegetablesController(DeutschlernenproContext context)
        {
            _context = context;
        }

        // GET: Vegetables
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vegetables.ToListAsync());
        }

        // GET: Vegetables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vegetable = await _context.Vegetables
                .FirstOrDefaultAsync(m => m.VegetableID == id);
            if (vegetable == null)
            {
                return NotFound();
            }

            return View(vegetable);
        }

        // GET: Vegetables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vegetables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VegetableID,EnglishName,GermanName,ImagePath,LessonID")] Vegetable vegetable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vegetable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vegetable);
        }

        

        // POST: Vegetables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VegetableID,EnglishName,GermanName,ImagePath,LessonID")] Vegetable vegetable)
        {
            if (id != vegetable.VegetableID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vegetable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VegetableExists(vegetable.VegetableID))
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
            return View(vegetable);
        }

      

        

        private bool VegetableExists(int id)
        {
            return _context.Vegetables.Any(e => e.VegetableID == id);
        }
    }
}
