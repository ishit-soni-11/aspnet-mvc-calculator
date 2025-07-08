using Microsoft.AspNetCore.Mvc;


namespace XCalc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Redirect to Calculator
            return RedirectToAction("Index", "Calculator");
        }
    }
}

