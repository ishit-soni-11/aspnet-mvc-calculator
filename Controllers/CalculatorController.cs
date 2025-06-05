using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;
using MyMvcApp.Extensions;
using System.Collections.Generic;

namespace MyMvcApp.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = new CalculatorViewModel();
            model.History = HttpContext.Session.GetObjectFromJson<List<string>>("History") ?? new List<string>();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(CalculatorViewModel model)
        {
            model.History = HttpContext.Session.GetObjectFromJson<List<string>>("History") ?? new List<string>();

            if (model.Number1 == null || model.Number2 == null)
            {
                model.ErrorMessage = "Please enter values for both numbers.";
                return View(model);
            }

            string opSymbol = "";
            switch (model.Operation)
            {
                case "Add":
                    model.Result = model.Number1 + model.Number2;
                    opSymbol = "+";
                    break;
                case "Subtract":
                    model.Result = model.Number1 - model.Number2;
                    opSymbol = "-";
                    break;
                case "Multiply":
                    model.Result = model.Number1 * model.Number2;
                    opSymbol = "×";
                    break;
                case "Divide":
                    if (model.Number2 == 0)
                        model.ErrorMessage = "Cannot divide by zero.";
                    else
                        model.Result = model.Number1 / model.Number2;
                    opSymbol = "÷";
                    break;
                default:
                    model.ErrorMessage = "Please select a valid operation.";
                    break;
            }

            if (model.Result != null && string.IsNullOrEmpty(model.ErrorMessage))
            {
                string historyEntry = $"{model.Number1} {opSymbol} {model.Number2} = {model.Result}";
                model.History.Insert(0, historyEntry);
                HttpContext.Session.SetObjectAsJson("History", model.History);
            }

            return View(model);
        }
    }
}
