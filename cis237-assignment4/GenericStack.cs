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
    /// <summary>
    /// This class implements a generic stack in the style of a linked list.
    /// </summary>
    class GenericStack<T> : IGenericStack<T>
    {
        /// <summary>
        /// Internal class that provides a node to the linked list in the GenericStack class. Each
        /// Node contains a generic type Data property and a Next node object.
        /// </summary>
        protected class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
        }

        // variables providing the Node object and size
        protected Node head;
        protected int size = 0;

        // if true this returns null as the head of the stack
        public bool isEmpty
        {
            get { return head == null; }
        }

        public int Size
        {
            get { return size; }
        }

        /// <summary>
        /// Method to push a generic type Data item onto the stack.  
        /// </summary>
        /// <param name="Data"></param>
        public void Push(T Data)
        {
            // give Node oldHead the same data as the head of the stack
            Node oldHead = head;

            // make the head instance a new Node
            head = new Node();

            // give the new Node the information in Data
            head.Data = Data;

            // set the Next property of that same node (head) equal to the oldHead node
            head.Next = oldHead;

            // size up!
            size++;

        }

        // this should be the same as RemoveFromFront in the class example
        public T Pop()
        {

            // if empty, burp
            if (isEmpty)
            {
                throw new Exception("List is empty");
            }

            // set a generic returnData equal to the Data property of head
            T returnData = head.Data;

            // make head equal the next item in the stack
            head = head.Next;

            // size down
            size--;
            
            // and return the data we just popped off the stack
            return returnData;
        }
    }
}
