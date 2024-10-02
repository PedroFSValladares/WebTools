using Microsoft.AspNetCore.Mvc;

namespace WebTools.Controllers.Settings {
    public class SettingsController : Controller {
        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public IActionResult Update() {
        
            return Ok();
        }
    }
}
