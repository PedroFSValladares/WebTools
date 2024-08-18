using Microsoft.AspNetCore.Mvc;
using WebTools.Requests.CreditCard;

namespace WebTools.Controllers.CreditCard.Create
{
    public class CreditCardController : Controller
    {

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCreditCardRequest newCardRequest)
        {
            throw new NotImplementedException();
        }

    }
}
