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
    public class JobsController : Controller
    {
        private readonly DeutschlernenproContext _context;

        public JobsController(DeutschlernenproContext context)
        {
            _context = context;
        }

        // GET: Jobs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jobs.ToListAsync());
        }

        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs
                .FirstOrDefaultAsync(m => m.JobID == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

      
        private bool JobExists(int id)
        {
            return _context.Jobs.Any(e => e.JobID == id);
        }
    }
}
