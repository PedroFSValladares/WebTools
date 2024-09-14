using System;
using System.Linq.Expressions;
using VideoLibrary;
using WebTools.Models.Media;
using WebTools.Requests.Media;
using WebTools.Services.Interfaces;

namespace WebTools.Services.Implementantions.Web {
    public class VideoDownloader : IDownloader {

        private YouTube YouTubeClient;

        public VideoDownloader() {
            YouTubeClient = YouTube.Default;
        }

        public async Task<byte[]> DownloadData(string url) {
            var video = YouTubeClient.GetVideo(url);
            byte[] videoBytes = await video.GetBytesAsync();
            return videoBytes;
        }

        public Task<Models.Media.Video> GetVideo(string videoUrl) {
            throw new NotImplementedException();
        }

        public GetVideoInfoResponse GetVideoInfo(string videoUrl) {
            var video = YouTubeClient.GetVideo(videoUrl);
            return new GetVideoInfoResponse {
                VideoName = video.Title,
                ImageUrl = "",
                Url = videoUrl,
                Extension = video.FileExtension
            };
            throw new NotImplementedException();
        }
    }
}
