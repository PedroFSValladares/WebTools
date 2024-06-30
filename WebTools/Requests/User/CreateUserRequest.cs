using WebTools.Models;

namespace WebTools.Requests.User
{
    public class CreateUserRequest
    {
        public Models.User User { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
