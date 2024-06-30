using Microsoft.AspNetCore.Mvc;
using Services.Downloader;
using Services.Persistence;

namespace WebTools.Controllers.Media.Detail {
    public class MediaController : Controller {

        private readonly Downloader downloader;
        private readonly FileManager fileManager;

        public MediaController(Downloader downloader, FileManager fileManager) {
            this.downloader = downloader;
            this.fileManager = fileManager;
        }

        public async Task<IActionResult> Detail(string url) {
            var videoInfo = await downloader.GetVideoInfo(url);
            var model = new DetailViewModel {
                ImageUrl = videoInfo.data.GetProperty("thumbnailUrl").ToString(),
                VideoDownloadUrl = videoInfo.data.GetProperty("downloadUrl").ToString(),
                VideoName = videoInfo.data.GetProperty("videoName").ToString()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Save(string url, string name) {
            var media = await downloader.DownloadData(url);
            fileManager.Save(name, FileExtesions.mpeg4, media);
            return RedirectToAction("Index");
        }
    }
}
