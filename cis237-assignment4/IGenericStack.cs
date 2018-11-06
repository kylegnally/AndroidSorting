/************************************************************************************
 *
 * Kyle Nally
 * CIS237 T/Th 3:30pm Assignment 4 - Algorithms: Modified Bucket Sort and Merge Sort
 * 11/3/2018
 *
 ************************************************************************************/


namespace cis237_assignment4
{
    /// <summary>
    /// Interface to provide methods required for implementing a generic stack.
    /// </summary>
    interface IGenericStack<T>
    {
        void Push(T Data);
        T Pop();

        bool isEmpty { get; }
        int Size { get; }
    }
}
