using System.Collections;
using System.Collections.Generic;

namespace Workers
{
    class Сompany : IEnumerable
    {
        List<WorkerBase> list;

        public List<WorkerBase> ListWorker
        {
            get
            {
               return list;
            }
        }

        public Сompany(params WorkerBase[] Args)
        {
            list = new List<WorkerBase>();
            foreach (var e in Args)
            {
                list.Add(e);
            }
        }

        public Сompany() : this(new WorkerBase[0])
        {
            this.list = new List<WorkerBase>{
                new WorkerFixedPayment("имя_1", 11, 11154),
                new WorkerFixedPayment("имя_2", 22, 33344),
                new WorkerFixedPayment("имя_3", 55, 222566),
                new WorkerHourlyPay("имя_4", 44, 52),
                new WorkerHourlyPay("имя_5", 11, 33)
            };
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < this.list.Count; i++)
            {
                yield return this.list[i];
            }
        }
    }
}
