using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using maibagamofisa.Models;

namespace maibagamofisa.Controllers
{
    public class SentenceConstructionController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public SentenceConstructionController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "json", "sentenceconstruction.json");
            var jsonData = await System.IO.File.ReadAllTextAsync(filePath);
            var sentences = JsonConvert.DeserializeObject<List<SentenceConstruction>>(jsonData);

            return View(sentences);
        }
    }
}
