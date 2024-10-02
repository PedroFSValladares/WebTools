using Microsoft.AspNetCore.Mvc;

namespace WebTools.Controllers.Room.Detail {
    public class RoomController : Controller {
        [HttpGet]
        public IActionResult Detail(Guid roomId) {
            return View();
        }
    }
}
