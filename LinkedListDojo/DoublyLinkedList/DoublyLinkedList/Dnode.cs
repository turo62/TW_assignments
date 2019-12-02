using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    class Dnode
    {
        internal int data;
        internal Dnode prev;
        internal Dnode next;

        public Dnode(int d)
        {
            data = d;
            prev = null;
            next = null;
        }

        public void Print()
        {
            Console.Write("|" + data + "| -->");
            if (next != null)
            {
                next.Print();
            }
        }

        public override string ToString()
        {
            return data.ToString();
        }
    }
}
