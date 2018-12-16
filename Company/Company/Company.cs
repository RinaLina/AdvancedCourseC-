using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Company
{
    static class Comp
    {
        static public int WRONGVAL = -1;
        static public int NEWINDEX = -2;
        static string DEFULT = "Отдел_деф";
        static ObservableCollection<Department> list = new ObservableCollection<Department>();
        /// <summary>
        /// Получение списка сотрудников отдела
        /// </summary>
        static public ObservableCollection<Department> ListDep
        {
            get
            {
                return list;
            }
        }
        /// <summary>
        /// Добавление нового департамента
        /// </summary>
        /// <param name="newdep">департамент</param>
        static public void Adddep(string name)
        {
            if(GetDepIndex(name) >= 0)
            {
                return;
            }
            Department newdep = new Department(name);
            list.Add(newdep);
        }
        static public void Addempl(string Name, int Age, int Salary, string NameDep)
        {
            Employee newempl = new Employee(Name, Age, Salary, NameDep);
            list[GetDepIndex(NameDep)].AddEmpl(newempl);
        }

        static public void DelEmpl(int indD, int indE)
        {
            list[indD].ListWorker.RemoveAt(indE);
        }
        /// <summary>
        /// Удаление департамента
        /// </summary>
        /// <param name="index">индекс департамента</param>
        static public void DeleteDep(int index)
        {
            list.RemoveAt(index);
        }
        /// <summary>
        /// Получение числового значения из строки
        /// (P.S. Пока добавила в этот класс, позже сделаю вспомогательный)
        /// </summary>
        /// <param name="text">строка</param>
        /// <returns></returns>
        static public int GetValue(string text)
        {
            int x;
            bool flag;
            while (true)
            {
                flag = int.TryParse(text, out x);
                if (!flag)
                {
                    return WRONGVAL;
                }
                else
                {
                    return x;
                }
            }
        }
        /// <summary>
        /// Получение индекса отдела по названию
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        static public int GetDepIndex(string Name)
        {
            for(int i = 0; i < list.Count; i++)
            {
                if(list[i].NameDepart == Name)
                {
                    return i;
                }
            }
            return WRONGVAL;
        }
        /// <summary>
        /// Добавляет дефолтный отдел в компанию
        /// </summary>
        static public void AddDefult()
        {
            if (GetDepIndex(DEFULT) >= 0)
            {
                return;
            }
            Department dep = new Department();
            list.Add(dep);
        }
    }
}
