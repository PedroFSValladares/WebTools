using WebTools.Models.Media;
using WebTools.Requests.Media;

namespace WebTools.Services.Web.Interfaces {
    public interface IDownloader {
        public Task<Video> GetVideo(string videoUrl);
        public Task<byte[]> DownloadData(string url);
        public Task<GetVideoInfoResponse> GetVideoInfo(string videoUrl);
    }
}
