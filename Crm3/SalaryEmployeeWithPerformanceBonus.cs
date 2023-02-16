using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm3
{
    public class SalaryEmployeeWithPerformanceBonus : SalaryEmployee
    {
        public List<PerformanceBonus> PerformanceBonuses { get; set; }
        public List<ExtraPay> ExtraPayments = new List<ExtraPay>();

        public override decimal CalculatePayment()
        {
            decimal totalPerformanceBonus = 0;
            foreach (var performanceBonus in PerformanceBonuses)
            {
                if (!performanceBonus.Paid)
                {
                    totalPerformanceBonus += performanceBonus.Amount;
                    performanceBonus.Paid = true;
                }
            }
            decimal totalExtraPayment = 0;
            foreach (var extraPay in ExtraPayments)
            {
                if (!extraPay.Paid)
                {
                    totalExtraPayment += extraPay.Amount;
                    extraPay.Paid = true;
                }
            }
            return BaseSalary + totalPerformanceBonus + totalExtraPayment;
        }
        public override void Pay()
        {
            decimal totalPayment = CalculatePayment();
            Console.WriteLine($"Paying {fname} {Lname} for {JobTitle} with ID {Id} {totalPayment} as salaried payment with performance bonuses");

            foreach (var performanceBonus in PerformanceBonuses)
            {
                if (!performanceBonus.Paid)
                {
                    Console.WriteLine($"Paying performance bonus: {performanceBonus.Amount} for {performanceBonus.Description}");
                    performanceBonus.Paid = true;
                }
            }
        }
    }
}
