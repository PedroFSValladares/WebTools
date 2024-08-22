using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Text.Json;
using WebTools.Requests.CreditCard;
using WebTools.Services.Interfaces;
using WebTools.Utilities;

namespace WebTools.Controllers.CreditCard.Edit {
    public class CreditCardController : Controller {

        private readonly IFileManager fileManager;

        public CreditCardController(IFileManager fileManager) {
            this.fileManager = fileManager;
            fileManager.Configure(
                Path.Combine(Environment.GetEnvironmentVariable("appPath"),
                "Finances"), "Credit Cards");
        }

        [HttpGet]
        public IActionResult Edit(Guid id) {
            var creditCardJson = fileManager.GetFileText(id.ToString() + ".json");
            var creditCard = JsonSerializer.Deserialize<Models.Finances.CreditCard>(creditCardJson);
            return View(new EditCreditCardRequest {
                id = id,
                Name = creditCard.Name,
                Limit = creditCard.Limit,
                DueDate = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, creditCard.DueDate),
                PaymentDay = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, creditCard.PaymentDay),
                Color = Color.FromArgb(creditCard.Color.Red, creditCard.Color.Green, creditCard.Color.Blue)
            });
        }

        [HttpPost]
        public IActionResult Save(EditCreditCardRequest editCreditCardRequest) {
            var creditCard = Extractor.GetCreditCardFromRequest(editCreditCardRequest);
            var creditCardJson = JsonSerializer.Serialize(creditCard);

            fileManager.Save(editCreditCardRequest.id.ToString() + ".json", creditCardJson, true);

            return RedirectToAction("Index");
        }
    }
}
