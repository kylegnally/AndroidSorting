using System;
using System.Collections.Generic;
using System.Text;

namespace cis237_assignment4
{
    class DroidCollection : IDroidCollection
    {
        // variables used by the collection
        Droid[] droids;
        int collectionPosition;

        /// <summary>
        /// DroidCollection constructor. Creates a new array of type Droid
        /// and sets the collectionPosition to 0.  
        /// </summary>
        public DroidCollection()
        {
            droids = new Droid[100];
            collectionPosition = 0;
        }

        /******************************************************************************
         *
         *  Overloaded Add methods. These add the four droid types to the collection.
         *  Adding a droid advances the collectionposition variable so we can add a
         *  droid to the next array slot.
         *
         *  All four of these are functionally identical and only have different signatures,
         *  so only the first is commented.
         *
         ******************************************************************************/

        /// <summary>
        /// ProtocolDroid Add method
        /// </summary>
        /// <param name="material"></param>
        /// <param name="color"></param>
        /// <param name="numberOfLanguages"></param>
        public void Add(string material,
            string color,
            int numberOfLanguages)
        {
            // create a new Droid of the type indicated by the method signature
            droids[collectionPosition] = new ProtocolDroid(
                material,
                color,
                numberOfLanguages);

            // invoke the total cost calculation method for this specific droid type
            droids[collectionPosition].CalculateTotalCost();

            // advance to the next position
            collectionPosition++;
        }

        /// <summary>
        /// UtilityDroid Add method
        /// </summary>
        /// <param name="material"></param>
        /// <param name="color"></param>
        /// <param name="toolBox"></param>
        /// <param name="computerConnection"></param>
        /// <param name="arm"></param>
        public void Add(
            string material,
            string color,
            bool toolBox,
            bool computerConnection,
            bool arm)
        {
            droids[collectionPosition] = new UtilityDroid(
                material,
                color,
                toolBox,
                computerConnection,
                arm);
            droids[collectionPosition].CalculateTotalCost();
            collectionPosition++;
        }

        /// <summary>
        /// JanitorDroid Add method
        /// </summary>
        /// <param name="material"></param>
        /// <param name="color"></param>
        /// <param name="toolBox"></param>
        /// <param name="computerConnection"></param>
        /// <param name="arm"></param>
        /// <param name="trashCompactor"></param>
        /// <param name="vacuum"></param>
        public void Add(
            string material,
            string color,
            bool toolBox,
            bool computerConnection,
            bool arm,
            bool trashCompactor,
            bool vacuum)
        {
            droids[collectionPosition] =
                new JanitorDroid(material,
                    color,
                    toolBox,
                    computerConnection,
                    arm,
                    trashCompactor,
                    vacuum);
            droids[collectionPosition].CalculateTotalCost();
            collectionPosition++;
        }

        /// <summary>
        /// AstromechDroid Add method
        /// </summary>
        /// <param name="material"></param>
        /// <param name="color"></param>
        /// <param name="toolBox"></param>
        /// <param name="computerConnection"></param>
        /// <param name="arm"></param>
        /// <param name="fireExtinguisher"></param>
        /// <param name="numberOfShips"></param>
        public void Add(
            string material,
            string color,
            bool toolBox,
            bool computerConnection,
            bool arm,
            bool fireExtinguisher,
            int numberOfShips)
        {
            droids[collectionPosition] =
                new AstromechDroid(material,
                    color,
                    toolBox,
                    computerConnection,
                    arm,
                    fireExtinguisher,
                    numberOfShips);
            droids[collectionPosition].CalculateTotalCost();
            collectionPosition++;
        }

        /// <summary>
        /// Method to loop through the collection and pass it
        /// into a simple string array for display.
        /// </summary>
        /// <returns>string[]</returns>
        public string[] PrintTheDroidsInventory()
        {
            Console.ResetColor();
            string[] allDroids = new string[collectionPosition];

            for (int i = 0; i < droids.Length; i++)
            {
                if (droids[i] != null)
                {
                    Console.WriteLine(allDroids[i] = droids[i].ToString());
                }

                else if (droids[0] == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\t\t\t\t\tNO DROIDS IN INVENTORY");
                    Console.ResetColor();
                }
            }

            return allDroids;
        }

        public void CategorizeByModel(Droid[] droids)
        {

        }
    }
}
