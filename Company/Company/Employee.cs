using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class Employee : INotifyPropertyChanged
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
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public string NameDep { get; set; }
        /// <summary>
        /// Параметры сотрудника через строку
        /// </summary>
        /// <returns>Запись сотрудника в строчку</returns>
        public override string ToString()
        {
            return $"Имя: {this.Name}; Возрвст: {this.Age}; Зарплата: {this.Salary} ";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
                PropertyChanged(this, new PropertyChangedEventArgs("DisplayMember"));
            }
        }
    }
}
