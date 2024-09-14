using System.Text.Json;

namespace WebTools.Requests.Media
{
    public class GetVideoInfoResponse : BaseVideoRequest
    {
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public string Extension { get; set; }
    }
}
