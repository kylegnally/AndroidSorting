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
    /// Enforces methods and properties used by the GenericQueue class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IGenericQueue<T>
    {
        void Enqueue(T Data);
        T Dequeue();

        bool IsEmpty { get; }
        int Size { get; }
    }
}
