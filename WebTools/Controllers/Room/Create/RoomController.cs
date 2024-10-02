using Microsoft.AspNetCore.Mvc;

namespace WebTools.Controllers.Room.Create {
    public class RoomController : Controller {
        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Room newRoom) {



            return RedirectToAction("Index");
        }
    }
}
