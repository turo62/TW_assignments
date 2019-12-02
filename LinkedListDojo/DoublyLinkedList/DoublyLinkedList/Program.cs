using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList myDList = new DoublyLinkedList();

            myDList.InsertFront(myDList, 24);
            myDList.InsertLast(myDList, 4);
            myDList.InsertLast(myDList, 91);
            myDList.InsertLast(myDList, 32);
            myDList.InsertFront(myDList, 1222);
            myDList.DeleteNodebyKey(myDList, 4);
            myDList.Print();
            Console.Read();
        }
    }
}
