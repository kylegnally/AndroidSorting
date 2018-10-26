using System;
using System.Collections.Generic;
using System.Text;

namespace cis237_assignment4
{
    class UtilityDroid : Droid
    {
        // private variables for this specific droid type
        private bool toolBox;
        private bool computerConnection;
        private bool arm;

        // constants specific to this droid
        private const decimal TOOLBOX_COST = 15.0m;
        private const decimal COMPUTER_CONNECTION_COST = 20.0m;
        private const decimal ARM_COST = 10.0m;
        private const string NAME = "Utility Droid";

        /// <summary>
        /// Public property to override TotalCost property of parent class.
        /// Remains zero until CalculateTotalCost is called.
        /// </summary>
        public override decimal TotalCost { get; set; }

        /// <summary>
        /// constructor. Inherits material and color from Droid class,
        /// but sets the toolbox, computerconnection, and arm bools
        /// from inside this class. Also sets the droid type's name.
        /// </summary>
        /// <param name="material"></param>
        /// <param name="color"></param>
        /// <param name="toolBox"></param>
        /// <param name="computerConnection"></param>
        /// <param name="arm"></param>
        public UtilityDroid(
            string material,
            string color,
            bool toolBox,
            bool computerConnection,
            bool arm) : base(material, color)
        {
            this.toolBox = toolBox;
            this.computerConnection = computerConnection;
            this.arm = arm;
            this.Name = NAME;

            CalculateSubtotal();
        }

        /// <summary>
        /// ToString override method. Calls the base classes' ToString method first,
        /// then concatenates this child classes' properties onto that string.
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return base.ToString()
                   + " "
                   + " toolbox: "
                   + toolBox
                   + " comp cnxn: "
                   + computerConnection
                   + " arm: "
                   + arm;
        }

        /// <summary>
        /// Calculates a running subtotal which includes the inherited base cost of
        /// a droid plus this particular droid's options.
        /// </summary>
        private void CalculateSubtotal()
        {
            if (this.toolBox) BaseCost += TOOLBOX_COST;
            if (this.computerConnection) BaseCost += COMPUTER_CONNECTION_COST;
            if (this.arm) BaseCost += ARM_COST;
        }

        /// <summary>
        /// Calculates the total cost by adding the value in the BaseCost
        /// property to the options this specific droid type has.
        /// Sets the TotalCost property (which overrides that of its parent).
        /// </summary>
        public override void CalculateTotalCost()
        {
            TotalCost = BaseCost;
        }
    }
}
