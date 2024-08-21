using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebTools.Models.Finances;
using WebTools.Requests.CreditCard;
using WebTools.Services.Interfaces;
using WebTools.Utilities;

namespace WebTools.Controllers.CreditCard.Create
{
    public class CreditCardController : Controller
    {
        private readonly IFileManager fileManager;

        public CreditCardController(IFileManager fileManager) {
            this.fileManager = fileManager;
            fileManager.Configure(
                Path.Combine(Environment.GetEnvironmentVariable("appPath"),
                "Finances"), "Credit Cards");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateCreditCardRequest());
        }

        [HttpPost]
        public IActionResult Create(CreateCreditCardRequest newCardRequest)
        {
            var newCreditCard = Extractor.GetCreditCardFromRequest(newCardRequest);
            
            string creditCardJson = JsonSerializer.Serialize(newCreditCard);

            fileManager.Save($"{newCreditCard.Id}.json", creditCardJson, true);
            return RedirectToAction("Index");
        }

    }
}
