using System;
using System.Collections.Generic;
using System.Text;

namespace cis237_assignment4
{
    abstract class Droid : IDroid
    {
        // Basic costs for all droids
        private const decimal UNIT_BASE_COST = 20.00m;
        private const decimal POLYSKIN_MAT_COST = 15.0m;
        private const decimal METASKIN_MAT_COST = 25.0m;
        private const decimal CERASKIN_MAT_COST = 50.0m;
        private const decimal COLOR_BLACK_COST = 10.0m;
        private const decimal COLOR_RED_COST = 15.0m;
        private const decimal COLOR_WHITE_COST = 20.0m;

        // properties shared by all droids
        private string Material { get; }
        private string Color { get; }
        protected decimal BaseCost { get; set; }
        public abstract decimal TotalCost { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Constructor used as a base by all child classes. Requires
        /// parameters for basic droid material and droid color. Also
        /// calls a CalculateSubTotal method which stores the combined prices
        /// associated with those parameters in BaseCost protected property.
        /// </summary>
        /// <param name="material"></param>
        /// <param name="color"></param>
        protected Droid(string material, string color)
        {
            BaseCost = UNIT_BASE_COST;
            this.Material = material;
            this.Color = color;
            CalculateSubtotal();
        }

        // subtotal method used to add skin and color costs to the base cost
        private void CalculateSubtotal()
        {
            if (this.Material == "Polyskin") BaseCost += POLYSKIN_MAT_COST;
            if (this.Material == "Metaskin") BaseCost += METASKIN_MAT_COST;
            if (this.Material == "Ceraskin") BaseCost += CERASKIN_MAT_COST;
            if (this.Color == "Black") BaseCost += COLOR_BLACK_COST;
            if (this.Color == "Red") BaseCost += COLOR_RED_COST;
            if (this.Color == "White") BaseCost += COLOR_WHITE_COST;
        }

        public int CompareTo(object droid)
        {
            return this;
        }

        /// <summary>
        /// returns the basic droid information when called from any child class.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return TotalCost.ToString("C") + " " + Color + " " + Material + " " + Name + " ";
        }

        /// <summary>
        /// abstract method to return total cost. Implemented in child classes.
        /// </summary>
        public abstract void CalculateTotalCost();
    }
}
