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
    /// Interface used for creation of a Droid. Enforces inclusion of
    /// CalculateTotalCost() as a void as well as inclusion of a TotalCost
    /// property.
    /// </summary>
    interface IDroid : IComparable
    {
        // Method to calculate the total cost of a droid
        void CalculateTotalCost();

        // Property to get the total cost of a droid
        decimal TotalCost { get; set; }
    }
}
