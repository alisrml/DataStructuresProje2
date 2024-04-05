using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresProje2
{
    class PriorityQueue
    {
        List<UM_ALANI> kuyrukList;
        int baş, son;
        int elemanSayısı;

        public PriorityQueue()
        {
            kuyrukList = new List<UM_ALANI>();
            baş = 0; son = -1; elemanSayısı = 0;
        }
        public void enque(UM_ALANI alan)
        {
            kuyrukList.Add(alan);
            elemanSayısı++;
        }
        public UM_ALANI deque()
        {
            if (elemanSayısı == 0)
            {
                Console.WriteLine("Kuyruk boş!");
                return null;
            }

            // oncelikli elemanı adınaa gore listeden cikarma
            UM_ALANI enOncelikli = kuyrukList.OrderBy(x => x.alanAdi).First();

            kuyrukList.Remove(enOncelikli);
            elemanSayısı--;

            return enOncelikli;

        }
        public bool bosMu()
        {
            return (elemanSayısı == 0);
        }
    }
}
