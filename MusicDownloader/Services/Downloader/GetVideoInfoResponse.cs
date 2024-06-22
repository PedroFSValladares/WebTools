using System.Text.Json;

namespace MusicDownloader.Services.Downloader {
    public class GetVideoInfoResponse {
        public int code {  get; set; }
        public JsonElement data { get; set; }
        //public string message { get; set; }
        //public object page { get; set; }
        
    }
}
