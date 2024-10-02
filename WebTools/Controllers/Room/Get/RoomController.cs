using Microsoft.AspNetCore.Mvc;
using WebTools.Requests.Room;

namespace WebTools.Controllers.Room.Get
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            var rooms = new GetRoomRequest
            {
                Rooms = new List<Models.Room> { new Models.Room {
                    Name = "teste",
                    Owner = "tester",
                    MaxPlayers = 16
                } }
            };
            return View(rooms);
        }
    }
}
