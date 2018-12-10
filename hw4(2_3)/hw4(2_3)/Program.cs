using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4_2_3_
{
    class Program
    {
        class Phone
        {
            public string Name { get; set; }
            public string Company { get; set; }
        }
        static void Main(string[] args)
        {
            List<int> listInt = new List<int>();
            var dict = new Dictionary<int, int>();
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                listInt.Add(rnd.Next(1, 10));
                Console.WriteLine(listInt[i]);
                int value;
                if (dict.TryGetValue(listInt[i], out value)) // таким образом можно сделать пункт а и б
                {
                    dict[listInt[i]] += 1;
                }
                else
                {
                    dict[listInt[i]] = 1;
                }
            }
            Console.WriteLine("2.1 - 2.2");
            foreach (var a in dict)
            {
                Console.WriteLine("{0} - {1}", a.Key, a.Value);
            }
            List<Phone> phones = new List<Phone>
            {
                new Phone {Name="Lumia 430", Company="Microsoft" },
                new Phone {Name="Mi 5", Company="Xiaomi" },
                new Phone {Name="LG G 3", Company="LG" },
                 new Phone {Name="LG G 3", Company="LG" },
                  new Phone {Name="LG G 3", Company="LG" },
                new Phone {Name="iPhone 5", Company="Apple" },
                new Phone {Name="Lumia 930", Company="Microsoft" },
                new Phone {Name="iPhone 6", Company="Apple" },
                new Phone {Name="iPhone 6", Company="Apple" },
                new Phone {Name="iPhone 6", Company="Apple" },
                new Phone {Name="Lumia 630", Company="Microsoft" },
                new Phone {Name="Lumia 630", Company="Microsoft" },
                new Phone {Name="LG G 4", Company="LG" }
            };
            var phoneGroups = from phone in phones
                               group phone by new { phone.Company,phone.Name} into g
                               select new { Name = g.Key, Count = g.Count() };
            Console.WriteLine("2.3");
            foreach (var group in phoneGroups)
                Console.WriteLine("{0} : {1}", group.Name, group.Count);
            Dictionary<string, int> dict2 = new Dictionary<string, int>()
              {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
              };
            var d = dict2.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            Console.WriteLine("3.0");
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
            var d1 = dict2.OrderBy(p => p.Value);
            Console.WriteLine("3");
            foreach (var pair in d1)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
            Console.ReadKey();

        }
    }
}
