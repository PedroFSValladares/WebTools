using Microsoft.AspNetCore.Mvc;
using WebTools.Models.Media;
using WebTools.Requests.Media;
using WebTools.Services.Interfaces;

namespace WebTools.Controllers.Media.Detail
{
    public class MediaController : Controller {

        private readonly IDownloader downloader;
        private readonly IFileManager fileManager;

        public MediaController(IDownloader downloader, IFileManager fileManager) {
            this.downloader = downloader;
            this.fileManager = fileManager;
        }

        public async Task<IActionResult> Detail(string url) {
            var videoInfo = downloader.GetVideoInfo(url);
            return View(videoInfo);
        }

        [HttpPost]
        public async Task<IActionResult> Save(string url, string name, string extension) {
            var media = await downloader.DownloadData(url);
            fileManager.SaveFile(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), name + extension, media, false);
            return RedirectToAction("Index");
        }
    }
}
