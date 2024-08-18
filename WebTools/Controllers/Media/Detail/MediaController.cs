using Microsoft.AspNetCore.Mvc;
using WebTools.Models.Media;
using WebTools.Services.Persistence.Interfaces;
using WebTools.Services.Web.Interfaces;

namespace WebTools.Controllers.Media.Detail
{
    public class MediaController : Controller {

        private readonly IDownloader downloader;
        private readonly IFileManager fileManager;

        public MediaController(IDownloader downloader, IFileManager fileManager) {
            this.downloader = downloader;
            this.fileManager = fileManager;
            this.fileManager.Configure(
                Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), Environment.GetEnvironmentVariable("defaultMediaDownloadFolderName"));
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
            fileManager.Save(name + ".mp4", media);
            return RedirectToAction("Index");
        }
    }
}
