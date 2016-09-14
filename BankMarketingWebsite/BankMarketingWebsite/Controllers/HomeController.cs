using System.Web.Mvc;
using BankMarketingWebsite.Models;

namespace BankMarketingWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new InputParameters());
        }

        [HttpPost]
        public ActionResult Index(InputParameters input)
        {
            var bankModel = new BankModel();

            var result = bankModel.WillSubscribe(input);

            return RedirectToAction("Prediction", (object)new {value = result});
        }

        public ActionResult Prediction(string value)
        {
            return View((object)value);
        }
    }
}