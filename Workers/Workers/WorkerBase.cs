using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    abstract class WorkerBase : IComparable<WorkerBase>
    {
        public WorkerBase(string Name, int Age, int Rate)
        {
            this.Name = Name;
            this.Age = Age;
            this.Rate = Rate;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public int Rate { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Salary} ";
        }

        public abstract void SalaryCalculation();

        public int CompareTo(WorkerBase other)
        {
            return other.Salary > this.Salary ? -1 : 1;

        }
    }
}
