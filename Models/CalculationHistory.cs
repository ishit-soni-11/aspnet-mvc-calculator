using System;

namespace XCalc.Models
{
    public class CalculationHistory
    {
        public int Id { get; set; }
        public required string Expression { get; set; } // Add 'required' modifier
        public double Result { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
