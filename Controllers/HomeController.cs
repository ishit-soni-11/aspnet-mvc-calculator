using Microsoft.AspNetCore.Mvc;

namespace XCalc.Controllers
{
    public class HomeController : Controller
    {
        // Remove the [Route("Home")] attribute - this is causing conflicts
        public IActionResult HomeRedirect()
        {
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View();
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