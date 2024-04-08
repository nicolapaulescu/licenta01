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
    public class HousesController : Controller
    {
        private readonly DeutschlernenproContext _context;

        public HousesController(DeutschlernenproContext context)
        {
            _context = context;
        }

        // GET: Houses
        public async Task<IActionResult> Index()
        {
            return View(await _context.House.ToListAsync());
        }

        // GET: Houses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var house = await _context.House
                .FirstOrDefaultAsync(m => m.HouseID == id);
            if (house == null)
            {
                return NotFound();
            }

            return View(house);
        }

       
        private bool HouseExists(int id)
        {
            return _context.House.Any(e => e.HouseID == id);
        }
    }
}
