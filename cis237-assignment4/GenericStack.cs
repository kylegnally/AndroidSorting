using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment4
{
    class GenericStack<T> : IGenericStack<T>
    {
        protected class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
        }

        protected Node head;
        protected Node tail;
        protected int size = 0;

        public bool isEmpty
        {
            get { return head == null; }
        }

        public int Size
        {
            get { return size; }
        }

        // this should be the same as AddToFront in the class example
        public void Push(T Data)
        {
            Node oldHead = head;
            head = new Node();
            head.Data = Data;
            head.Next = oldHead;
            size++;

            if (size == 1)
            {
                tail = head;
            }

        }

        // this should be the same as RemoveFromFront in the class example
        public T Pop()
        {
            if (isEmpty)
            {
                throw new Exception("List is empty");
            }

            T returnData = head.Data;
            head = head.Next;
            size--;
            if (isEmpty)
            {
                tail = null;
            }

            return returnData;
        }
    }
}
