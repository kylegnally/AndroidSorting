using System;
using System.Collections.Generic;
using System.Text;

namespace cis237_assignment4
{
    class AstromechDroid : UtilityDroid
    {
        // private variables for this specific droid type
        private bool fireExtinguisher;
        private int numberOfShips;

        // constants specific to this droid 
        private const string NAME = "Astromech Droid";
        private const decimal EXTINGUISHER_COST = 35.0m;
        private const decimal SHIPS_COST = 50.0m;

        /// <summary>
        /// Public property to override TotalCost property of parent class.
        /// Remains zero until CalculateTotalCost is called.
        /// </summary>
        public override decimal TotalCost { get; set; }

        /// <summary>
        /// Constructor. Inherits material and color from the top of the
        /// inheritance chain (the Droid class itself), inherits toolbox, computerconnection,
        /// and arm from the UtilityDroid class, and adds fireExtinguisher and NumberOfShips
        /// to this type of droid.
        /// </summary>
        /// <param name="material"></param>
        /// <param name="color"></param>
        /// <param name="toolBox"></param>
        /// <param name="computerConnection"></param>
        /// <param name="arm"></param>
        /// <param name="fireExtinguisher"></param>
        /// <param name="numberOfShips"></param>
        public AstromechDroid(
            string material,
            string color,
            bool toolBox,
            bool computerConnection,
            bool arm,
            bool fireExtinguisher,
            int numberOfShips) : base(
            material,
            color,
            toolBox,
            computerConnection,
            arm)
        {
            this.Name = NAME;
            this.fireExtinguisher = fireExtinguisher;
            this.numberOfShips = numberOfShips;
        }

        /// <summary>
        /// ToString override method. Calls the base classes' ToString method
        /// (including that of the grandparent Droid class) first,
        /// then concatenates this child classes' properties onto that string.
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return base.ToString()
                   + " "
                   + " extinguisher: "
                   + fireExtinguisher
                   + " ships: "
                   + numberOfShips;
        }

        /// <summary>
        /// Calculates the total cost by adding the value in the BaseCost
        /// property to the options this specific droid type has.
        /// Sets the TotalCost property (which overrides that of its parent).
        /// </summary>
        public override void CalculateTotalCost()
        {
            if (fireExtinguisher) BaseCost += EXTINGUISHER_COST;
            BaseCost += (numberOfShips * SHIPS_COST);
            TotalCost = BaseCost;
        }
    }
}
