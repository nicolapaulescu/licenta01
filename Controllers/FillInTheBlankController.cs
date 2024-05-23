using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using maibagamofisa.Models;

namespace maibagamofisa.Controllers
{
    public class FillInTheBlankController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public FillInTheBlankController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "json", "fillintheblank.json");
            var jsonData = await System.IO.File.ReadAllTextAsync(filePath);
            var fillInTheBlankPairs = JsonConvert.DeserializeObject<List<FillInTheBlankPair>>(jsonData);

            // Pass the serialized word pairs to the view
            ViewBag.FillInTheBlankPairsJson = JsonConvert.SerializeObject(fillInTheBlankPairs);

            return View(fillInTheBlankPairs);
        }
    }
}
