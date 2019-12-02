using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
    public class Node
    {
        public Node next;
        public int data;

        public Node(int d)
        {
            data = d;
            next = null;
        }

        public void AddToEnd(int d)
        {
            if (next == null)
            {
                next = new Node(d);
            }
            else
            {
                next.AddToEnd(d);
            }
        }

        public void Print()
        {
            Console.Write("|" + data + "| --> ");
            if (next != null)
            {
                next.Print();
            }
        }
    }
}
