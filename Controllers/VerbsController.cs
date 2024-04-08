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
    public class VerbsController : Controller
    {
        private readonly DeutschlernenproContext _context;

        public VerbsController(DeutschlernenproContext context)
        {
            _context = context;
        }

        // GET: Verbs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Verbs.ToListAsync());
        }

        // GET: Verbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verb = await _context.Verbs
                .FirstOrDefaultAsync(m => m.VerbID == id);
            if (verb == null)
            {
                return NotFound();
            }

            return View(verb);
        }

       

        private bool VerbExists(int id)
        {
            return _context.Verbs.Any(e => e.VerbID == id);
        }
    }
}
