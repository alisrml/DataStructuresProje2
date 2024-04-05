using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresProje2
{
    internal class MyQueue
    {
        List<UM_ALANI> queueList;
        int front;
        int rear;
        int nitems;
        
        public MyQueue() 
        { 
            this.queueList = new List<UM_ALANI>();
            this.front = 0;
            this.rear = -1;
            this.nitems = 0;
        }

        public void insert(UM_ALANI item)
        {
            queueList[rear++] = item;
            nitems++;
        }

        public UM_ALANI remove()
        {
            UM_ALANI alan = queueList[front++];
            nitems--;
            return alan;
        }

        public UM_ALANI peekFront()
        {
            return queueList[front];
        }

        public Boolean isEmpty() 
        { 
            return queueList.Count == 0;
        }

        public int size() { return nitems; }
    }
}
