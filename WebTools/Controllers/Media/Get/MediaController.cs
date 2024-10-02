using Microsoft.AspNetCore.Mvc;
using WebTools.Services.Interfaces;

namespace WebTools.Controllers.Media.Get
{
    public class MediaController : Controller
    {
        private readonly IDownloader downloader;
        private readonly ILogger logger;
        private readonly IFileManager fileManager;

        public MediaController(ILogger<HomeController> logger, IDownloader downloader, IFileManager fileManager)
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
