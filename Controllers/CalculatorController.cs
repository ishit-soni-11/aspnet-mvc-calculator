using Microsoft.AspNetCore.Mvc;

namespace MyMvcApp.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(double number1, double number2, string operation)
        {
            double result = 0;
            if (operation == "Add")
                result = number1 + number2;
            else if (operation == "Subtract")
                result = number1 - number2;

            ViewBag.Result = result;
            return View();
        }
    }
}
