using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicDownloader.Services.Downloader;
using MusicDownloader.Services.IOManagement;

namespace MusicDownloader.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase {

        private readonly Downloader downloader;
        private readonly ILogger logger;
        private readonly FileManager fileManager;

        public MusicController(Downloader downloader, FileManager fileManager) {
            this.downloader = downloader;
            this.fileManager = fileManager;
        }

        [HttpGet]
        public async Task<IActionResult> DownloadVideo(string url) {
            var videoInfo = await downloader.GetVideo(url);

            if (videoInfo == null) {
                return NoContent();
            }

            fileManager.Save(videoInfo.Title, FileExtesions.mpeg4, videoInfo.Data);

            return Ok();
        }
    }
}
