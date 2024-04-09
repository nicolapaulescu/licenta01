using maibagamofisa.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tesseract;

namespace maibagamofisa.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                try
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        imageFile.CopyTo(memoryStream);
                        memoryStream.Position = 0;

                        using (var engine = new TesseractEngine(@"./tesseract/tessdata", "deu", EngineMode.Default))
                        {
                            using (var image = Pix.LoadFromMemory(memoryStream.ToArray()))
                            {
                                using (var page = engine.Process(image))
                                {
                                    var extractedText = page.GetText();
                                    ViewBag.ExtractedText = extractedText;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception
                    ViewBag.ExtractedText = "Error processing the image: " + ex.Message;
                }
            }
            else
            {
                ViewBag.ExtractedText = "No image file provided.";
            }

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
