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
    public class FruitsController : Controller
    {
        private readonly DeutschlernenproContext _context;

        public FruitsController(DeutschlernenproContext context)
        {
            _context = context;
        }

        // GET: Fruits
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fruits.ToListAsync());
        }

        // GET: Fruits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fruit = await _context.Fruits
                .FirstOrDefaultAsync(m => m.FruitId == id);
            if (fruit == null)
            {
                return NotFound();
            }

            return View(fruit);
        }

       


        private bool FruitExists(int id)
        {
            return _context.Fruits.Any(e => e.FruitId == id);
        }
    }
}
