/************************************************************************************
 *
 * Kyle Nally
 * CIS237 T/Th 3:30pm Assignment 4 - Algorithms: Modified Bucket Sort and Merge Sort
 * 11/3/2018
 *
 ************************************************************************************/

namespace cis237_assignment4
{
    interface IDroidCollection
    {
        /// <summary>
        ///  Method to add a protocol droid.
        /// </summary>
        /// <param name="material"></param>
        /// <param name="color"></param>
        /// <param name="numberOfLanguages"></param>
        void Add(string material, string color, int numberOfLanguages);

        /// <summary>
        /// Method to add a utility droid.
        /// </summary>
        /// <param name="material"></param>
        /// <param name="color"></param>
        /// <param name="hasToolBox"></param>
        /// <param name="hasComputerConnection"></param>
        /// <param name="hasArm"></param>
        void Add(string material, string color, bool hasToolBox, bool hasComputerConnection, bool hasArm);

        /// <summary>
        /// Method to add a janitor droid.
        /// </summary>
        /// <param name="material"></param>
        /// <param name="color"></param>
        /// <param name="hasToolBox"></param>
        /// <param name="hasComputerConnection"></param>
        /// <param name="hasArm"></param>
        /// <param name="hasTrashCompactor"></param>
        /// <param name="hasVaccum"></param>
        void Add(string material, string color, bool hasToolBox, bool hasComputerConnection, bool hasArm, bool hasTrashCompactor, bool hasVaccum);

        /// <summary>
        /// Method to add an astromech droid.
        /// </summary>
        /// <param name="material"></param>
        /// <param name="color"></param>
        /// <param name="hasToolBox"></param>
        /// <param name="hasComputerConnection"></param>
        /// <param name="hasArm"></param>
        /// <param name="hasFireExtinguisher"></param>
        /// <param name="numberOfShips"></param>
        void Add(string material, string color, bool hasToolBox, bool hasComputerConnection, bool hasArm, bool hasFireExtinguisher, int numberOfShips);

        /// <summary>
        /// Method to categorize the droids in the inventory.
        /// </summary>
        void CategorizeByModel();

        /// <summary>
        /// Method to perform a merge sort on the droids.
        /// </summary>
        void MergeSortByTotalCost();

        /// <summary>
        /// Method to get the data for a droid into a nicely formatted string that can be output.
        /// </summary>
        /// <returns></returns>
        string[] PrintTheDroidsInventory();
    }
}
