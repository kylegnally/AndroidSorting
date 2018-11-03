/************************************************************************************
 *
 * Kyle Nally
 * CIS237 T/Th 3:30pm Assignment 4 - Algorithms: Modified Bucket Sort and Merge Sort
 * 11/3/2018
 *
 ************************************************************************************/

namespace cis237_assignment4
{
    interface IGenericStack<T>
    {
        void Push(T Data);
        T Pop();

        bool isEmpty { get; }
        int Size { get; }
    }
}
