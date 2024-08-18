using System.Text.Json;

namespace WebTools.Requests.Media
{
    public class GetVideoInfoResponse
    {
        public int code { get; set; }
        public JsonElement data { get; set; }
        //public string message { get; set; }
        //public object page { get; set; }

    }
}
