using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    class WorkerFixedPayment : WorkerBase
    {
        public WorkerFixedPayment(string Name, int Age, int Rate) : base(Name, Age, Rate)
        {
            SalaryCalculation();
        }

        public override void SalaryCalculation()
        {
            this.Salary = this.Rate;
        }
    }
}
