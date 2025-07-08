using Microsoft.AspNetCore.Mvc;

namespace XCalc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult HomeRedirect()
        {
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Calculator()
        {
            return View(Calculator);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CalculationHistory()
        {
            return View();
        }
    }
}