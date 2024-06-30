using Microsoft.AspNetCore.Mvc;
using Services.Downloader;
using Services.Persistence;

namespace WebTools.Controllers.Media
{
    public class MediaController : Controller
    {
        private readonly Downloader downloader;
        private readonly ILogger logger;
        private readonly FileManager fileManager;

        public MediaController(ILogger<HomeController> logger, Downloader downloader, FileManager fileManager)
        {
            this.logger = logger;
            this.downloader = downloader;
            this.fileManager = fileManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Search(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                ViewData["errorMessage"] = "URL field will not be empty.";
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(actionName: nameof(Detail), routeValues: url);
        }
    }
}
