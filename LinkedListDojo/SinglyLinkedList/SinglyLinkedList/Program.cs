using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            SingleLinkedList myList = new SingleLinkedList();

            myList.AddToFirst(35);
            myList.AddToLast(4);
            myList.AddSorted(12);
            myList.AddSorted(9);
            myList.AddSorted(3);
            myList.DeleteNodebyKey(9);
            myList.Print();
            Console.WriteLine("\n" + myList.Last.data);

            Console.Read();
        }
    }
}
