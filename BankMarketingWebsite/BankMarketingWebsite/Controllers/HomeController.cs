using System.Web.Mvc;
using BankMarketingWebsite.Models;

namespace BankMarketingWebsite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(new InputParameters());
        }
    }
}