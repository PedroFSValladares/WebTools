using Microsoft.AspNetCore.Mvc;

namespace WebTools.Controllers.CreditCard.Get {
    public class CreditCardController : Controller{

        [HttpGet]
        public IActionResult Index() {
            return View();
        }
    }
}
