using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    class Program
    {
        static void Main(string[] args)
        {
            Сompany com = new Сompany();

            foreach (var item in com)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            com.ListWorker.Sort();

            foreach (var e in com) { Console.WriteLine(e); }

            

            Console.ReadKey();
        }
    }
}
