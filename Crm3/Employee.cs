using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm3
{

    public abstract class Employee : Person
    {
        public string JobTitle { get; set; }
        public abstract decimal CalculatePayment();
        public abstract void Pay();
    }

}
