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
    public class DaysoftheweeksController : Controller
    {
        private readonly DeutschlernenproContext _context;

        public DaysoftheweeksController(DeutschlernenproContext context)
        {
            _context = context;
        }

        // GET: Daysoftheweeks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Daysoftheweek.ToListAsync());
        }

        // GET: Daysoftheweeks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daysoftheweek = await _context.Daysoftheweek
                .FirstOrDefaultAsync(m => m.DaysoftheweekID == id);
            if (daysoftheweek == null)
            {
                return NotFound();
            }

            return View(daysoftheweek);
        }


        private bool DaysoftheweekExists(int id)
        {
            return _context.Daysoftheweek.Any(e => e.DaysoftheweekID == id);
        }
    }
}
