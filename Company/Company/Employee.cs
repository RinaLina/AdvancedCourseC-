using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    public class Employee : INotifyPropertyChanged
    {
        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <param name="Name">Имя</param>
        /// <param name="Age">Возрвст</param>
        /// <param name="Salary">Зарплата</param>
        public Employee(string Name, int Age, int Salary, string NameDep)
        {
            this.Name = Name;
            this.Age = Age;
            this.Salary = Salary;
            this.NameDep = NameDep;
        }
        string name, namedep = String.Empty;
        int age, salary;
        public string Name {
            get
            {
                return this.name;
            }
            set
            {
                this.name= value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Name)));

            }
        }
        public int Age {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Age)));

            }
        }
        public int Salary {
            get
            {
                return this.salary;
            }
            set
            {
                this.salary = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Salary)));

            }
        }
        public string NameDep {
            get
            {
                return this.namedep;
            }
            set
            {
                if (this.namedep != String.Empty)
                {
                    if (Comp.GetDepIndex(value) != Comp.GetDepIndex(namedep))
                    {
                        Comp.ListDep[Comp.GetDepIndex(namedep)].ListWorker.Remove(this);
                        Comp.ListDep[Comp.GetDepIndex(value)].AddEmpl(this);
                    }
                }
                this.namedep = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.NameDep)));

            }
        }
        /// <summary>
        /// Параметры сотрудника через строку
        /// </summary>
        /// <returns>Запись сотрудника в строчку</returns>
        public override string ToString()
        {
            return $"Имя: {this.Name}; Возрвст: {this.Age}; Зарплата: {this.Salary} ";
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
