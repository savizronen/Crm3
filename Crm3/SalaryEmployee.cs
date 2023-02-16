using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm3
{
    public class SalaryEmployee : Employee
    {
        public decimal BaseSalary { get; set; }
        public List<ExtraPay> ExtraPayments { get; set; }
        public override decimal CalculatePayment()
        {
            decimal totalExtraPayment = 0;
            foreach (var extraPay in ExtraPayments)
            {
                if (!extraPay.Paid)
                {
                    totalExtraPayment += extraPay.Amount;
                    extraPay.Paid = true;
                }
            }
            return BaseSalary + totalExtraPayment;
        }

        public override void Pay()
        {
            Console.WriteLine($"Paying {fname} {Lname} for {JobTitle} with ID {Id} {CalculatePayment()} as salaried payment");
        }

    }
}
