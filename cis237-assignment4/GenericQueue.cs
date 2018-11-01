﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment4
{
    class GenericQueue<T> : IGenericQueue<T>
    {
        protected class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
        }

        protected Node head;
        protected Node tail;
        protected int size = 0;

        public bool IsEmpty
        {
            get { return head == null; }
        }

        public int Size
        {
            get
            {
                return size;
            }
        }

        public void Enqueue(T Data)
        {
            Node oldTail = tail;
            tail = new Node();
            tail.Data = Data;
            tail.Next = null;

            if (IsEmpty)
            {
                head = tail;
            }
            else
            {
                oldTail.Next = tail;
            }

            size++;
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new Exception("List is empty");
            }

            T returnData = head.Data;
            head = head.Next;
            size--;

            if (IsEmpty)
            {
                tail = null;
            }

            return returnData;
        }
    }
}
