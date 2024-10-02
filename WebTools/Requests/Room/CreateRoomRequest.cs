namespace WebTools.Requests.Room
{
    public class CreateRoomRequest
    {
        public Models.Room Room { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
