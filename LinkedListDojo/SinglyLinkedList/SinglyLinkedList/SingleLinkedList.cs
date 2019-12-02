using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
    class SingleLinkedList
    {
        public Node head;

        public SingleLinkedList()
        {
            this.head = null;
        }

        public void AddToFirst (int data)
        {
            if (head == null)
            {
                head = new Node(data);
            }
            else
            {
                Node new_node = new Node(data);
                new_node.next = head;
                head = new_node;
            }
        }

        public Node Last
        {
            get
            {
                Node curr = head;
                if (curr == null)
                    return null;
                while (curr.next != null)
                    curr = curr.next;
                return curr;
            }
        }
        
        public void AddToLast(int data)
        {
            if (head == null)
            {
                head = new Node(data);
            }
            else
            {
                head.AddToEnd(data);
            }
        }

        public void AddSorted(int data)
        {
            if (head == null)
            {
                head = new Node(data);
            }
            else if ( data < head.data)
            {
                AddToFirst(data);
            }
            else
            {
                AddSorted(data);
            }
        }

        public void DeleteNodebyKey(int key)
        {
            Node temp = head;
            Node prev = null;
            if (temp != null && temp.data == key)
            {
                head = temp.next;
                return;
            }
            while (temp != null && temp.data != key)
            {
                prev = temp;
                temp = temp.next;
            }
            if (temp == null)
            {
                return;
            }
            prev.next = temp.next;
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
