using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebTools.Models;
using WebTools.Services.Persistence.Interfaces;
using WebTools.Services.Web.Interfaces;

namespace WebTools.Controllers {
    public class HomeController : Controller {
        private readonly IDownloader downloader;
        private readonly ILogger logger;
        private readonly IFileManager fileManager;

        public HomeController(ILogger<HomeController> logger, IDownloader downloader, IFileManager fileManager) {
            this.logger = logger;
            this.downloader = downloader;
            this.fileManager = fileManager;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        public IActionResult About() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
