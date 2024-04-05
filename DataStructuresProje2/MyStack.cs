using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresProje2
{
    internal class MyStack
    {
        List<UM_ALANI> stackList;
        int top;

        public MyStack()
        {
            this.stackList = new List<UM_ALANI>();
        }

        public void Push(UM_ALANI alan)
        {
            this.stackList.Add(alan);
            top++;
        }

        public UM_ALANI pop() {

            return stackList[top--];
        }

        public Boolean isEmpty()
        {
            return stackList.Count == 0;
        }
    }
}
