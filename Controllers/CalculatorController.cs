using Microsoft.AspNetCore.Mvc;
using MvcCalculator.Models;

namespace MvcCalculator.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new CalculatorViewModel());
        }

        [HttpPost]
        public IActionResult Index(CalculatorViewModel model)
        {
            if (model.Number1 == null || model.Number2 == null)
            {
                model.ErrorMessage = "Please enter values for both numbers.";
                return View(model);
            }

            switch (model.Operation)
            {
                case "Add":
                    model.Result = model.Number1 + model.Number2;
                    break;
                case "Subtract":
                    model.Result = model.Number1 - model.Number2;
                    break;
                case "Multiply":
                    model.Result = model.Number1 * model.Number2;
                    break;
                case "Divide":
                    if (model.Number2 == 0)
                        model.ErrorMessage = "Cannot divide by zero.";
                    else
                        model.Result = model.Number1 / model.Number2;
                    break;
                default:
                    model.ErrorMessage = "Please select a valid operation.";
                    break;
            }

            return View(model);
        }
    }
}
