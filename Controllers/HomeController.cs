using Microsoft.AspNetCore.Mvc;


namespace MyMvcApp.Controllers
{
    public class HomeController : Controller
    {
        [Route("Home")]
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

