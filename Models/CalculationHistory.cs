using System;

namespace MyMvcApp.Models
{
    public class CalculationHistory
    {
        public int Id { get; set; }
        public string Expression { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
