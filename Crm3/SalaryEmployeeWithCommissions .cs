using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm3
{
    public class SalaryEmployeeWithCommissions : SalaryEmployee
    {
        public List<CommissionBonus> CommissionBonuses { get; set; }
        public override decimal CalculatePayment()
        {
            decimal totalCommission = 0;
            foreach (var commission in CommissionBonuses)
            {
                if (!commission.Paid)
                {
                    totalCommission += BaseSalary * commission.CommissionPercent;
                    commission.Paid = true;
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
            return BaseSalary + totalCommission + totalExtraPayment;
        }
        public override void Pay()
        {
            Console.WriteLine($"Paying {fname} {Lname} for {JobTitle} with ID {Id} {CalculatePayment()} as salaried payment with commissions");
        }
    }
}
