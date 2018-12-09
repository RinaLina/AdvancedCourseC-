using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    class Program
    {
        public delegate void MyDelegate(object o);
        class Source
        {
            public event MyDelegate Run;
            public void Start()
            {
                Console.WriteLine("RUN");
                if (Run != null) Run(this);
            }
        }
        class Observer1 // Наблюдатель 1
        {

            static public event Action<object> obs;
            public void Do(object o)
            {
                //Console.WriteLine("Первый. Принял, что объект {0} побежал", o);
                Observer1.obs?.Invoke($"Первый. Принял, что объект {o} побежал");
            }
        }
        class Observer2 // Наблюдатель 2
        {
            static public event Action<object> obs;
            public void Do(object o)
            {
                //Console.WriteLine("Второй. Принял, что объект {0} побежал", o);
                Observer2.obs?.Invoke($"Второй. Принял, что объект {o} побежал");
            }
        }

        static void Main(string[] args)
        {
            Source s = new Source();
            Observer1 o1 = new Observer1();
            Observer2 o2 = new Observer2();
            //MyDelegate d1 = new MyDelegate(o1.Do);
            //s.Run += d1;
            //s.Run += o2.Do;
            //s.Start();
            //s.Run -= d1;
            //s.Start();
            Observer1.obs += delegate (object o)
            {
                Console.WriteLine(o);
            };
            o1.Do(s);
            s.Start();
            Observer2.obs += delegate (object o)
            {
                Console.WriteLine(o);
            };
            o2.Do(s);
            s.Start();
            Console.ReadKey();
        }
    }
}
