using System.Net.Http.Json;

namespace Services.Downloader
{
    public class Downloader
    {
        public string BaseUrl { get; set; }
        private HttpClient _httpClient { get; set; }

        public Downloader(){
            BaseUrl = Environment.GetEnvironmentVariable("youtubeVideoDownloadUrl");
        }

        public async Task<Video> GetVideo(string videoUrl)
        {
            Video videoRespose = new Video();
            var videoInfo = await GetVideoInfo(videoUrl);
            
            var videoDownloadUrl = videoInfo.data.GetProperty("downloadUrl").ToString();

            var videoTitle = videoInfo.data.GetProperty("videoName").ToString();
            var videoData = await DownloadData(videoDownloadUrl);

            videoRespose.Title = videoTitle;
            videoRespose.Data = videoData;

            return videoRespose;
        }

        public async Task<byte[]> DownloadData(string url) {
            _httpClient = new HttpClient {
                BaseAddress = new Uri(url)
            };

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsByteArrayAsync();
            return data;
        }

        public async Task<GetVideoInfoResponse> GetVideoInfo(string videoUrl) {
            _httpClient = new HttpClient {
                BaseAddress = new Uri(BaseUrl)
            };

            var result = await _httpClient.PostAsJsonAsync("", new GetVideoInfoRequest {
                url = videoUrl,
                videoSource = 3
            });

            if (!result.IsSuccessStatusCode) {
                throw new DownloadException("Falha ao obter as informações de video");
            }

            var responseBody = await result.Content.ReadFromJsonAsync<GetVideoInfoResponse>();
            
            return responseBody;
        }
       
    }
}
