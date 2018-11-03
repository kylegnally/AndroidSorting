/************************************************************************************
 *
 * Kyle Nally
 * CIS237 T/Th 3:30pm Assignment 4 - Algorithms: Modified Bucket Sort and Merge Sort
 * 11/3/2018
 *
 ************************************************************************************/

using System;

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
            
            return returnData;
        }
    }
}
