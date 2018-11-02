using System;
using System.Collections.Generic;
using System.Text;

namespace cis237_assignment4
{
    class DroidCollection : IDroidCollection
    {
        // variables used by the collection
        IDroid[] droids;
        int collectionPosition;

        // Generic stacks - we're using type IDroid
        GenericStack<IDroid> aDroidStack = new GenericStack<IDroid>();
        GenericStack<IDroid> jDroidStack = new GenericStack<IDroid>();
        GenericStack<IDroid> uDroidStack = new GenericStack<IDroid>();
        GenericStack<IDroid> pDroidStack = new GenericStack<IDroid>();

        // generic queue - type IDroid
        GenericQueue<IDroid> droidQueue = new GenericQueue<IDroid>();

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

        public void CategorizeByModel()
        {
            AddToStacks();
            StacksToQueue();
            QueueToArray();
        }

        // required modified bucket sort method
        public void AddToStacks()
        {

            foreach (Droid droid in droids)
            {
                if (droid != null)
                {
                    if (droid is AstromechDroid) aDroidStack.Push(droid);
                    else if (droid is JanitorDroid) jDroidStack.Push(droid);
                    else if (droid is UtilityDroid) uDroidStack.Push(droid);
                    else if (droid is ProtocolDroid) pDroidStack.Push(droid);
                }
            }
        }

        // send each the stacks into a queue in the required order
        public void StacksToQueue()
        {
            for (int i = 0; i < aDroidStack.Size + 1; i++)
            {
                droidQueue.Enqueue(aDroidStack.Pop());
            }

            for (int i = 0; i < jDroidStack.Size + 1; i++)
            {
                droidQueue.Enqueue(jDroidStack.Pop());
            }

            for (int i = 0; i < uDroidStack.Size + 1; i++)
            {
                droidQueue.Enqueue(uDroidStack.Pop());
            }

            for (int i = 0; i < pDroidStack.Size + 1; i++)
            {
                droidQueue.Enqueue(pDroidStack.Pop());
            }
        }

        // send the queue into the original array, overwriting its contents
        public void QueueToArray()
        {
            int i = 0;

            // a for loop can't work here because the counter increments while the queue counter decrements,
            // so to get all the droids we just keep track of the queue size and stop when we get cake
            while (droidQueue.Size != 0)
            {
                IDroid droid = droidQueue.Dequeue();
                droids[i] = droid;
                i++;
            }
        }
    }
}
