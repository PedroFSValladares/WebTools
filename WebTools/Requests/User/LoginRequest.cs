using WebTools.Models;

namespace WebTools.Requests.User
{
    public class LoginRequest
    {
        public Models.User User { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
