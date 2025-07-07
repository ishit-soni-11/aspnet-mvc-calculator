using System.Collections.Generic;

namespace XCalc.Models
{
    public class CalculatorViewModel
    {
        public double? Number1 { get; set; }
        public double? Number2 { get; set; }
        public string? Operation { get; set; }
        public string? ErrorMessage { get; set; }


        public double? Result { get; set; }
        public List<string> RecentHistory { get; set; } = new List<string>();
        public List<string> FullHistory { get; set; } = new List<string>();
    }
}
