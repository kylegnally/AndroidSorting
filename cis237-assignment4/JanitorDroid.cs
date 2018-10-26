using System;
using System.Collections.Generic;
using System.Text;

namespace cis237_assignment4
{
    class JanitorDroid : UtilityDroid
    {
        // variables specific to this class
        private bool trashCompactor;
        private bool vacuum;
        private const string NAME = "Janitor Droid";

        // constants specific to this class
        private const decimal TRASH_COST = 15.0m;
        private const decimal VAC_COST = 15.0m;

        /// <summary>
        /// Public property to override TotalCost property of parent class.
        /// Remains zero until CalculateTotalCost is called.
        /// </summary>
        public override decimal TotalCost { get; set; }

        /// <summary>
        /// Constructor. Inherits marterial, color, toolbox, computerConnection, and arm
        /// from parent class and adds trashCompactor and vacuum to itself as additional
        /// options.
        /// </summary>
        /// <param name="material"></param>
        /// <param name="color"></param>
        /// <param name="toolBox"></param>
        /// <param name="computerConnection"></param>
        /// <param name="arm"></param>
        /// <param name="trashCompactor"></param>
        /// <param name="vacuum"></param>
        public JanitorDroid(
            string material,
            string color,
            bool toolBox,
            bool computerConnection,
            bool arm,
            bool trashCompactor,
            bool vacuum) : base(
                material,
                color,
                toolBox,
                computerConnection,
                arm)
        {
            this.Name = NAME;
            this.trashCompactor = trashCompactor;
            this.vacuum = vacuum;
        }

        /// <summary>
        /// ToString override method. Calls the base classes' ToString method
        /// (including that of its grandparent Droid class) and then concatenates
        /// this child classes' properties onto that string.
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return base.ToString()
                   + " "
                   + " compactor: "
                   + trashCompactor
                   + " vacuum: "
                   + vacuum;
        }

        /// <summary>
        /// Calculates the total cost by adding the value in the BaseCost
        /// property to the options this specific droid type has.
        /// Sets the TotalCost property (which overrides that of its parent).
        /// </summary>
        public override void CalculateTotalCost()
        {
            if (trashCompactor) BaseCost += TRASH_COST;
            if (vacuum) BaseCost += VAC_COST;
            TotalCost = BaseCost;
        }
    }
}
