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
    public class AnimalsController : Controller
    {
        private readonly DeutschlernenproContext _context;

        public AnimalsController(DeutschlernenproContext context)
        {
            _context = context;
        }

        // GET: Animals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Animals.ToListAsync());
        }

        // GET: Animals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals
                .FirstOrDefaultAsync(m => m.AnimalID == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

       
        

       
        private bool AnimalExists(int id)
        {
            return _context.Animals.Any(e => e.AnimalID == id);
        }
    }
}
