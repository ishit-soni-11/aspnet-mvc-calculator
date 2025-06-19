using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMvcApp.Data;
using MyMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMvcApp.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CalculatorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Helper to get recent history (last 3 calculations)
        private async Task<List<string>> GetRecentHistoryAsync()
        {
            return await _context.CalculationHistories
                .OrderByDescending(h => h.Timestamp)
                .Select(h => h.Expression)
                .Where(e => e != null)
                .Take(3)
                .ToListAsync();
        }

        // Helper to get full history (all calculations)
        private async Task<List<string>> GetFullHistoryAsync()
        {
            return await _context.CalculationHistories
                .OrderByDescending(h => h.Timestamp)
                .Select(h => h.Expression)
                .Where(e => e != null)
                .ToListAsync();
        }

        // Helper to save calculation to history
        private async Task SaveToHistoryAsync(string expression)
        {
            _context.CalculationHistories.Add(new CalculationHistory
            {
                Expression = expression,
                Timestamp = DateTime.UtcNow
            });
            await _context.SaveChangesAsync();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new CalculatorViewModel();
            model.RecentHistory = await GetRecentHistoryAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CalculatorViewModel model)
        {
            if (model.Number1 == null ||
                (RequiresSecondNumber(model.Operation) && model.Number2 == null))
            {
                model.ErrorMessage = "Please enter all required numbers.";
                model.RecentHistory = await GetRecentHistoryAsync();
                return View(model);
            }

            // Validation for specific operations
            if (model.Operation == "Divide" || model.Operation == "Modulus")
            {
                if (model.Number2 == 0)
                {
                    model.ErrorMessage = "Cannot divide by zero.";
                    model.RecentHistory = await GetRecentHistoryAsync();
                    return View(model);
                }
            }
            else if (model.Operation == "Sqrt")
            {
                if (model.Number1 < 0)
                {
                    model.ErrorMessage = "Cannot take square root of a negative number.";
                    model.RecentHistory = await GetRecentHistoryAsync();
                    return View(model);
                }
            }
            else if (model.Operation == "Factorial")
            {
                if (model.Number1 < 0 || model.Number1 % 1 != 0)
                {
                    model.ErrorMessage = "Enter a non-negative integer for factorial.";
                    model.RecentHistory = await GetRecentHistoryAsync();
                    return View(model);
                }
            }

            // Calculate result and format history entry
            double? result = null;
            string historyEntry = "";
            string opSymbol = "";

            switch (model.Operation)
            {
                case "Add":
                    result = model.Number1 + model.Number2;
                    opSymbol = "+";
                    historyEntry = $"{model.Number1} {opSymbol} {model.Number2} = {result}";
                    break;
                case "Subtract":
                    result = model.Number1 - model.Number2;
                    opSymbol = "-";
                    historyEntry = $"{model.Number1} {opSymbol} {model.Number2} = {result}";
                    break;
                case "Multiply":
                    result = model.Number1 * model.Number2;
                    opSymbol = "×";
                    historyEntry = $"{model.Number1} {opSymbol} {model.Number2} = {result}";
                    break;
                case "Divide":
                    result = model.Number1 / model.Number2;
                    opSymbol = "÷";
                    historyEntry = $"{model.Number1} {opSymbol} {model.Number2} = {result}";
                    break;
                case "Modulus":
                    result = model.Number1 % model.Number2;
                    opSymbol = "%";
                    historyEntry = $"{model.Number1} {opSymbol} {model.Number2} = {result}";
                    break;
                case "Exponent":
                    result = Math.Pow(model.Number1 ?? 0, model.Number2 ?? 0);
                    opSymbol = "^";
                    historyEntry = $"{model.Number1} {opSymbol} {model.Number2} = {result}";
                    break;
                case "Sqrt":
                    result = Math.Sqrt(model.Number1 ?? 0);
                    opSymbol = "√";
                    historyEntry = $"{opSymbol}{model.Number1} = {result}";
                    break;
                case "Factorial":
                    result = Factorial((int)model.Number1);
                    opSymbol = "!";
                    historyEntry = $"{model.Number1}{opSymbol} = {result}";
                    break;
                default:
                    model.ErrorMessage = "Please select a valid operation.";
                    model.RecentHistory = await GetRecentHistoryAsync();
                    return View(model);
            }

            model.Result = result;

            if (result != null && string.IsNullOrEmpty(model.ErrorMessage))
            {
                await SaveToHistoryAsync(historyEntry);
            }

            model.RecentHistory = await GetRecentHistoryAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> FullHistory()
        {
            var model = new CalculatorViewModel();
            model.FullHistory = await GetFullHistoryAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ClearHistory()
        {
            _context.CalculationHistories.RemoveRange(_context.CalculationHistories);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private static double Factorial(int n)
        {
            if (n == 0 || n == 1) return 1;
            double result = 1;
            for (int i = 2; i <= n; i++) result *= i;
            return result;
        }

        private bool RequiresSecondNumber(string? operation)
        {
            return operation == "Add" || operation == "Subtract" ||
                   operation == "Multiply" || operation == "Divide" ||
                   operation == "Modulus" || operation == "Exponent";
        }
    }
}
