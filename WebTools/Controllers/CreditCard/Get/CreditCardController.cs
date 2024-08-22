using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebTools.Requests.CreditCard;
using WebTools.Services.Interfaces;

namespace WebTools.Controllers.CreditCard.Get
{
    public class CreditCardController : Controller{

        private readonly IFileManager fileManager;

        public CreditCardController(IFileManager fileManager) {
            this.fileManager = fileManager;
            fileManager.Configure(
                Path.Combine(Environment.GetEnvironmentVariable("appPath"),
                "Finances"), "Credit Cards");
        }

        [HttpGet]
        public IActionResult Index() {
            var creditCardsFiles = fileManager.EnumerateFolderFiles(string.Empty);
            var savedCreditCards = creditCardsFiles.Select(x => {
                string json = fileManager.GetFileText(x);
                return JsonSerializer.Deserialize<Models.Finances.CreditCard>(json);
            });
            return View(new GetCreditCardRequest {
                creditCards = savedCreditCards.ToList(),
                TotalLimit = savedCreditCards.Sum(x => x.Limit),
                TotalUsed = savedCreditCards.Sum(x => x.TotalUsed)
            });
        }
    }
}
