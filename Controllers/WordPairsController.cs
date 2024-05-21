using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using maibagamofisa.Models;

namespace maibagamofisa.Controllers
{
    public class WordPairsController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public WordPairsController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> WordMatching()
        {
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "json", "wordpairs.json");
            var jsonData = await System.IO.File.ReadAllTextAsync(filePath);
            var wordPairs = JsonConvert.DeserializeObject<List<WordPair>>(jsonData);

            // Pass the serialized word pairs to the view
            ViewBag.WordPairsJson = JsonConvert.SerializeObject(wordPairs);

            return View(wordPairs);
        }
    }
}
