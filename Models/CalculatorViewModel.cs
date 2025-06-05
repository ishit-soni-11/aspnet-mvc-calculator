using System.Collections.Generic;

namespace MyMvcApp.Models
{
    public class CalculatorViewModel
    {
        public double? Number1 { get; set; }
        public double? Number2 { get; set; }
        public string? Operation { get; set; }
        public double? Result { get; set; }
        public string? ErrorMessage { get; set; }
        public List<string> History { get; set; } = new List<string>();
    }
}
