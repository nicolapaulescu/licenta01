using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using maibagamofisa.Models;

namespace maibagamofisa.Controllers
{
    public class PictureWordMatchController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PictureWordMatchController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "json", "picturewordmatch.json");
            var jsonData = await System.IO.File.ReadAllTextAsync(filePath);
            var matches = JsonConvert.DeserializeObject<List<PictureWordMatch>>(jsonData);

            return View(matches);
        }
    }
}
