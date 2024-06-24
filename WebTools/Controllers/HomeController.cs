using Microsoft.AspNetCore.Mvc;
using Services.Downloader;
using Services.IOManagement;
using System.Diagnostics;
using WebTools.Models;

namespace WebTools.Controllers {
    public class HomeController : Controller {
        private readonly Downloader downloader;
        private readonly ILogger logger;
        private readonly FileManager fileManager;

        public HomeController(ILogger<HomeController> logger, Downloader downloader, FileManager fileManager) {
            this.logger = logger;
            this.downloader = downloader;
            this.fileManager = fileManager;
        }

        public IActionResult Index() {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DownloadVideo(string url) {
            var videoInfo = await downloader.GetVideo(url);

            if (videoInfo == null) {
                return NoContent();
            }

            fileManager.Save(videoInfo.Title, FileExtesions.mpeg4, videoInfo.Data);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
