using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Company
{
    public class Department : INotifyPropertyChanged
    {
        public bool defult;
        /// <summary>
        /// Список сотрудников отдела
        /// </summary>
        ObservableCollection<Employee> list = new ObservableCollection<Employee>();
        private string namedep;
        /// <summary>
        /// название департамента
        /// </summary>
        public string NameDepart
        {
            get
            {
                return this.namedep;
            }
            set
            {

                if (Comp.GetDepIndex(this.namedep) >= 0)
                {
                    return;
                }
                this.namedep = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.NameDepart)));

            }
        }
        /// <summary>
        /// Получение списка сотрудников отдела
        /// </summary>
        public ObservableCollection<Employee> ListWorker
        {
            get
            {
                return list;
            }
        }
        /// <summary>
        /// Создание отдела из готового списка сотрудников
        /// </summary>
        /// <param name="Args">список сотрудников</param>
        public Department(string namedep, params Employee[] Args)
        {
            NameDepart = namedep;
            list = new ObservableCollection<Employee>();
            foreach (var e in Args)
            {
                list.Add(e);
            }
        }
        public Department(string namedep)
        {
            NameDepart = namedep;
            list = new ObservableCollection<Employee>();
        }
        /// <summary>
        /// Создание дефолтного отдела
        /// </summary>
        public Department()
        {
                NameDepart = "Отдел_деф";
                this.list = new ObservableCollection<Employee>{
                new Employee("имя_1", 11, 11154,"Отдел_деф"),
                new Employee("имя_2", 22, 33344,"Отдел_деф"),
                new Employee("имя_3", 55, 222566,"Отдел_деф"),
                new Employee("имя_4", 44, 52,"Отдел_деф"),
                new Employee("имя_5", 11, 33,"Отдел_деф")
                };         
        }
        /// <summary>
        /// Добавление сотрудника в отдел
        /// </summary>
        /// <param name="newEmpl">Сотрудник</param>
        public void AddEmpl(Employee newEmpl)
        {
            list.Add(newEmpl);
        }
        public override string ToString()
        {
            return $"{this.NameDepart}";
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
