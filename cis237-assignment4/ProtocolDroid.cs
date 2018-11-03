/************************************************************************************
 *
 * Kyle Nally
 * CIS237 T/Th 3:30pm Assignment 4 - Algorithms: Modified Bucket Sort and Merge Sort
 * 11/3/2018
 *
 ************************************************************************************/

namespace cis237_assignment4
{
    class ProtocolDroid : Droid
    {
        // variable specific to this class
        private int numberOfLanguages;

        // constants specific to this class
        private const decimal COST_PER_LANGUAGE = 15.00m;
        private const string NAME = "Protocol Droid";

        /// <summary>
        /// Public property to override TotalCost property of parent class.
        /// Remains zero until CalculateTotalCost is called.
        /// </summary>
        public override decimal TotalCost { get; set; }

        /// <summary>
        /// Constructor. Inherits material and color from the Droid parent class,
        /// and adds numberoflanguages to this type of droid.
        /// </summary>
        /// <param name="material"></param>
        /// <param name="color"></param>
        /// <param name="numberOfLanguages"></param>
        public ProtocolDroid(
            string material,
            string color,
            int numberOfLanguages) : base(material, color)
        {
            this.numberOfLanguages = numberOfLanguages;
            this.Name = NAME;
        }

        /// <summary>
        /// ToString override method. Calls the base classes' ToString method,
        /// then concatenates this child classes' properties onto that string.
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return base.ToString()
                   + " "
                   + " languages: "
                   + numberOfLanguages;
        }

        /// <summary>
        /// Calculates the total cost by adding the value in the BaseCost
        /// property to the options this specific droid type has.
        /// Sets the TotalCost property (which overrides that of its parent).
        /// </summary>
        public override void CalculateTotalCost()
        {
            TotalCost = BaseCost + (numberOfLanguages * COST_PER_LANGUAGE);
        }
    }
}
