using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresProje2
{
    internal class PriorityQueue2
    {
        List<int> kuyrukList;

        public PriorityQueue2()
        {
            kuyrukList = new List<int>();
        }

        public void Enqueue(int item)
        {
            kuyrukList.Add(item);
        }

        public int Dequeue()
        {
            if (kuyrukList.Count == 0)
            {
                Console.WriteLine("Kuyruk boş");
                return -1;
            }

            int enOncelikli = kuyrukList.OrderBy(x => x).First();
            kuyrukList.Remove(enOncelikli);

            return enOncelikli;
        }

        public bool IsEmpty()
        {
            return (kuyrukList.Count == 0);
        }
    }
}
