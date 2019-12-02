using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    class DoublyLinkedList
    {
        private Dnode head;

        public DoublyLinkedList()
        {
            this.head = null;
        }


        public void InsertFront(DoublyLinkedList doubleLinkedList, int data)
        {
            Dnode newNode = new Dnode(data);
            newNode.next = doubleLinkedList.head;
            newNode.prev = null;
            if (doubleLinkedList.head != null)
            {
                doubleLinkedList.head.prev = newNode;
            }
            doubleLinkedList.head = newNode;
        }
        
        public void InsertLast(DoublyLinkedList doubleLinkedList, int data)
        {
            Dnode newNode = new Dnode(data);
            if (doubleLinkedList.head == null)
            {
                newNode.prev = null;
                doubleLinkedList.head = newNode;
                return;
            }
            Dnode lastNode = GetLastNode(doubleLinkedList);
            lastNode.next = newNode;
            newNode.prev = lastNode;
        }

        private Dnode GetLastNode(DoublyLinkedList doubleList)
        {
            Dnode temp = doubleList.head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }

        public void DeleteNodebyKey(DoublyLinkedList doubleLinkedList, int key)
        {
            Dnode temp = doubleLinkedList.head;
            if (temp != null && temp.data == key)
            {
                doubleLinkedList.head = temp.next;
                doubleLinkedList.head.prev = null;
                return;
            }
            while (temp != null && temp.data != key)
            {
                temp = temp.next;
            }
            if (temp == null)
            {
                return;
            }
            if (temp.next != null)
            {
                temp.next.prev = temp.prev;
            }
            if (temp.prev != null)
            {
                temp.prev.next = temp.next;
            }
        }

        public void Print()
        {
            if (head != null)
            {
                head.Print();
            }
        }
    }
}
