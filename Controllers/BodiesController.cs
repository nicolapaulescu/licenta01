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
    public class BodiesController : Controller
    {
        private readonly DeutschlernenproContext _context;

        public BodiesController(DeutschlernenproContext context)
        {
            _context = context;
        }

        // GET: Bodies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Body.ToListAsync());
        }

        // GET: Bodies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var body = await _context.Body
                .FirstOrDefaultAsync(m => m.BodyID == id);
            if (body == null)
            {
                return NotFound();
            }

            return View(body);
        }

        private bool BodyExists(int id)
        {
            return _context.Body.Any(e => e.BodyID == id);
        }
    }
}
