using Microsoft.AspNetCore.Mvc;
using WebTools.Services.Interfaces;

namespace WebTools.Controllers.CreditCard.Delete {
    public class CreditCardController : Controller {

        private readonly IFileManager fileManager;

        public CreditCardController(IFileManager fileManager) {
            this.fileManager = fileManager;
            fileManager.Configure(
                Path.Combine(Environment.GetEnvironmentVariable("appPath"),
                "Finances"), "Credit Cards");
        }

        public IActionResult Delete(Guid id) {
            fileManager.Delete(id + ".json");
            return RedirectToAction("Index");
        }
    }
}
