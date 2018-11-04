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

        /// <summary>
        /// Public method used to call the private methods involved in using the GenericStack
        /// and GenericQueue classes. This method represents the only entry point to using
        /// those classes.
        /// </summary>
        public void CategorizeByModel()
        {
            AddToStacks();
            StacksToQueue();
            QueueToArray();
        }

        /// <summary>
        /// Check to see if there's anything in the array. Returns true if the array is empty.
        /// </summary>
        /// <param name="droids"></param>
        /// <returns></returns>
        public bool IsEmpty(IDroid[] droids)
        {
            if (droids[0] == null) return true;
            return false;
        }

        /// <summary>
        /// Method to return the array contained within the collection. Used during IsEmpty check
        /// in Program class.
        /// </summary>
        /// <returns></returns>
        public IDroid[] GetDroidArray()
        {
            return droids;
        }

        /// <summary>
        /// Method to send the array of droids into the MergeSort class for sorting by
        /// the TotalCost of each droid.
        /// </summary>
        public void MergeSortByTotalCost()
        {
            MergeSort mergeSort = new MergeSort(this.droids);
        }

        /// <summary>
        /// Required modified bucket sort method. Tests each droid in the droids array to determine
        /// its type, then pushes that droid onto the appropriate stack. This method is protected
        /// and can only be accessed via the CategorizeByModel method.
        /// </summary>
        protected void AddToStacks()
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

            return;
        }

        /// <summary>
        /// Method to send the droids on each stack into a single queue in the order required.
        /// Tests to see if the size is zero and, if it is not, enqueues each droid by utilizing
        /// the Pop method in the GenericStack class. This method is protected
        /// and can only be accessed via the CategorizeByModel method.
        /// </summary>
        protected void StacksToQueue()
        {
            while (aDroidStack.Size != 0)
            {
                droidQueue.Enqueue(aDroidStack.Pop());
            }

            while (jDroidStack.Size != 0)
            {
                droidQueue.Enqueue(jDroidStack.Pop());
            }

            while (uDroidStack.Size != 0)
            {
                droidQueue.Enqueue(uDroidStack.Pop());
            }

            while (pDroidStack.Size != 0)
            {
                droidQueue.Enqueue(pDroidStack.Pop());
            }

            return;
        }

        /// <summary>
        /// Sends each droid in the queue created by the GenericQueue class into the droids array
        /// by using a while loop to determine if the queue size is zero, setting the droid in
        /// index i equal to that droid in the queue, and then incrementing the counter.
        /// This method is protected and can only be accessed via the CategorizeByModel method.
        /// </summary>
        protected void QueueToArray()
        {
            int i = 0;

            while (droidQueue.Size != 0)
            {
                IDroid droid = droidQueue.Dequeue();
                droids[i] = droid;
                i++;
            }
        }
    }
}
