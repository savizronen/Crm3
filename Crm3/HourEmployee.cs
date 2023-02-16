using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm3
{
    public class HourEmployee : Employee
    {
        public decimal AccumulatedHours { get; set; }
        public decimal PaymentPerHour { get; set; }
        public override decimal CalculatePayment()
        {
            return AccumulatedHours * PaymentPerHour;
        }

        public override void Pay()
        {
            Console.WriteLine($"Paying {fname} {Lname} for {JobTitle} with ID {Id} {CalculatePayment()} as hourly payment");
        }
    }
}