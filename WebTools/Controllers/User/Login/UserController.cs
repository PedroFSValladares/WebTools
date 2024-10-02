using Microsoft.AspNetCore.Mvc;

namespace WebTools.Controllers.User {
    public class UserController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
