using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    class WorkerHourlyPay : WorkerBase
    {
        public WorkerHourlyPay(string Name, int Age, int hourlyRate) : base(Name, Age, hourlyRate)
        {
            SalaryCalculation();
        }

        public override void SalaryCalculation()
        {
            this.Salary = (int)(20.8 * 8 * this.Rate);
        }
    }
}
