/************************************************************************************
 *
 * Kyle Nally
 * CIS237 T/Th 3:30pm Assignment 4 - Algorithms: Modified Bucket Sort and Merge Sort
 * 11/3/2018
 *
 ************************************************************************************/

using System;
using System.Linq;

namespace cis237_assignment4
{
    class UserInterface
    {
        string menuString;

        #region Menus
        /// <summary>
        /// Displays the program main menu.
        /// </summary>
        /// <returns>string</returns>
        public string MainMenu()
        {
            Console.ResetColor();
            menuString = "\n\n\n\n\n\t\t\tWelcome to LookSir Droids!\n\n" +
                "\t\t\tPlease select an option: \n\n" +
                "\t\t\t(A) Add a droid to the list\n" +
                "\t\t\t(T) Add some test data to the list\n" +
                "\t\t\t(P) Print the list of droids currently in inventory\n" +
                "\t\t\t(C) Categorize the list of droids in this order: Astromech, Janitor, Utility, Protocol\n" +
                "\t\t\t(M) Merge sort by Total Cost\n" +
                "\t\t\t(Q) Quit\n\n";
            return menuString;
        }

        /// <summary>
        /// Displays the droid selection menu.
        /// </summary>
        /// <returns>string</returns>
        public string DroidSelection()
        {
            Console.ResetColor();
            menuString = ("\n\n\n\n\n\t\t\t\t\t--- SELECT A DROID TYPE ---\n\n" +
                          "\t\t\t\t\t--- BASE UNIT COST (ALL DROIDS): $20 ---\n\n" +
                          "\t\t\t\t\t(P) Protocol Droid \n" +
                          "\t\t\t\t\t(U) Utility Droid\n" +
                          "\t\t\t\t\t(J) Janitor Droid\n" +
                          "\t\t\t\t\t(A) Astromech Droid\n\n" +
                          "\t\t\t\t\t(M) Main Menu\n\n");
            return menuString;
        }

        /// <summary>
        /// Displays the material selection menu.
        /// </summary>
        /// <returns>string</returns>
        public string MaterialSelection()
        {
            Console.ResetColor();
            menuString = "\n\n\n\n\n\t\t\t\t\t--- SELECT A MATERIAL TYPE ---\n\n" +
                         "\t\t\t\t\t(P) Polyskin ($15)\n" +
                         "\t\t\t\t\t(M) Metaskin ($25)\n" +
                         "\t\t\t\t\t(C) Ceraskin ($50)\n";
            return menuString;
        }

        /// <summary>
        /// Displays the color selection menu.
        /// </summary>
        /// <returns>string</returns>
        public string ColorSelection()
        {
            Console.Clear();
            Console.ResetColor();
            menuString = "\n\n\n\n\n\t\t\t\t\t--- SELECT A COLOR ---\n\n" +
                         "\t\t\t\t\t(B) Black ($10)\n" +
                         "\t\t\t\t\t(R) Red ($15)\n" +
                         "\t\t\t\t\t(W) White ($20)\n";
            return menuString;
        }

        #endregion

        #region Utility Methods
        /// <summary>
        /// Message displayed when the user prints the droid list.
        /// </summary>
        /// <returns>string</returns>
        public string PrintListMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string printListMessage = "\n\n\t\t\t--- DROID INVENTORY ---\n\n";
            return printListMessage;
        }

        /// <summary>
        /// Pauses execution by putting the currently running thread to sleep for 1500ms.
        /// </summary>
        public void Pause()
        {
            System.Threading.Thread.Sleep(1500);
        }

        #endregion

        #region output messages

        /// <summary>
        /// Message displayed when the user exits the program.
        /// </summary>
        /// <returns>string</returns>
        public string QuitProgramMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string searchListMessage = "\n\n\t\t\t\t\tExiting program.";
            return searchListMessage;
        }

        /// <summary>
        /// Message displayed when the user selects an invalid menu option.
        /// </summary>
        /// <returns>string</returns>
        public string InvalidOptionMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string invalidOption = "\n\n\t\t\t\t\tInvalid option. Please select a valid option from the menu.";
            return invalidOption;
        }

        /// <summary>
        /// If called, informs the user that the droid has been successfully added to the collection. Returns a string.
        /// </summary>
        /// <returns>string</returns>
        public string DroidAdded()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string droidAdded = "\n\n\t\t\t\t\tNew droid added.";
            return droidAdded;
        }

        /// <summary>
        /// If called, informs the user that the droids have been sorted by category. Returns a string.
        /// </summary>
        /// <returns>string</returns>
        public string DroidsSortedByCategory()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string droidsSortedByCategory = "\n\n\t\t\tDroids sorted by category.";
            return droidsSortedByCategory;
        }

        /// <summary>
        /// If called, informs the user that the droids have been sorted by cost. Returns a string.
        /// </summary>
        /// <returns>string</returns>
        public string DroidsSortedByTotalCost()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string droidsSortedByTotalCost = "\n\n\t\t\tDroids sorted by total cost.";
            return droidsSortedByTotalCost;
        }

        /// <summary>
        /// If called, informs the user that test data has been successfully added to the collection. Returns a string.
        /// </summary>
        /// <returns>string</returns>
        public string TestDataAdded()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string testDataAdded = "\n\n\t\t\tTest droid data added.";
            return testDataAdded;
        }

        /// <summary>
        /// If called, instructs the user to press a key to continue and waits for input.
        /// </summary>
        public void WaitForUser()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n\n\t\t\tPress any key to continue.");
            Console.ReadKey(true);
        }

        /// <summary>
        /// Called when the user has entered some incorrect information when entering a droid's options.
        /// </summary>
        /// <returns>string</returns>
        public string InvalidInformation()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string invalidOption = "\n\n\t\t\t\t\tIt seems you've entered some incorrect information.";
            invalidOption += "\n\n\t\t\t\t\tDROID NOT ADDED.";
            invalidOption += "\n\t\t\t\t\tPlease Re-enter this droid's information.";
            return invalidOption;
        }

        #endregion

        #region Droid Build Methods

        /// <summary>
        /// Entry point for building a protocol droid.
        /// </summary>
        /// <returns>string[]</returns>
        public string[] BuildProtocolDroid()
        {
            string material = ChooseDroidMaterial();
            string color = ChooseDroidColor();
            string languages = ChooseDroidLanguages();
            return new[] { material, color, languages };
        }

        /// <summary>
        /// Entry point for building a utility droid.
        /// </summary>
        /// <returns>string[]</returns>
        public string[] BuildAUtilityDroid()
        {
            string material = ChooseDroidMaterial();
            string color = ChooseDroidColor();
            string toolbox = ChooseToolboxOption();
            string compcnxn = ChooseComputerConnectionOption();
            string arm = ChooseArmOption();

            return new[] { material, color, toolbox, compcnxn, arm };
        }

        /// <summary>
        /// Entry point for building a janitor droid.
        /// </summary>
        /// <returns>string[]</returns>
        public string[] BuildAJanitorDroid()
        {
            string[] janitorDroidBasics = BuildAUtilityDroid();
            string[] janitorDroidSpecifics = ChooseJanitorDroidSpecifics();
            string[] janitorDroid = janitorDroidBasics.Concat(janitorDroidSpecifics).ToArray();
            return janitorDroid;
        }

        /// <summary>
        /// Entry point for building an astromech droid.
        /// </summary>
        /// <returns>string[]</returns>
        public string[] BuildAnAstromechDroid()
        {
            string[] astromechDroidBasics = BuildAUtilityDroid();
            string[] astromechSpecifics = ChooseAstromechDroidSpecifics();
            string[] astromechDroid = astromechDroidBasics.Concat(astromechSpecifics).ToArray();
            return astromechDroid;
        }

        #endregion

        #region Droid Options Methods

        /// <summary>
        /// Allows the user to specify the number of supported languages for a droid.
        /// </summary>
        /// <returns>string</returns>
        private string ChooseDroidLanguages()
        {
            Console.ResetColor();
            Console.Write("\n\n\t\t\t\t\t");
            Console.Write("How many languages ($15 each) would you like to support? ");
            string languages = Console.ReadLine();
            int number;
            if (!int.TryParse(languages, out number)) languages = "invalid";
            return languages;
        }

        /// <summary>
        /// Allows the user to choose the material a droid is made of.
        /// </summary>
        /// <returns>string</returns>
        private string ChooseDroidMaterial()
        {
            Console.Clear();
            Console.Write(MaterialSelection());
            Console.Write("\n\n\t\t\t\t\t");
            string material = DetermineMaterial();
            return material;
        }

        /// <summary>
        /// Allows a user to specify the color of a droid.
        /// </summary>
        /// <returns></returns>
        private string ChooseDroidColor()
        {
            Console.Clear();
            Console.Write(ColorSelection());
            Console.Write("\n\n\t\t\t\t\t");
            string color = DetermineColor();
            return color;
        }

        /// <summary>
        /// Allows a user to add a toolbox to a droid.
        /// </summary>
        /// <returns>string</returns>
        private string ChooseToolboxOption()
        {
            Console.Write("\n\n\t\t\t\t\t");
            Console.Write("Would you like to add a toolbox ($15) to this model (Y/N)? ");
            string toolboxChoice = Console.ReadLine().ToUpper();
            switch (toolboxChoice)
            {
                case "Y":
                    toolboxChoice = "true";
                    break;
                case "N":
                    toolboxChoice = "false";
                    break;
                default:
                    toolboxChoice = "invalid";
                    break;
            }

            return toolboxChoice;
        }

        /// <summary>
        /// Allows a user to add an arm to a droid.
        /// </summary>
        /// <returns>string</returns>
        private string ChooseArmOption()
        {
            Console.Write("\n\n\t\t\t\t\t");
            Console.Write("Would you like to add a utility arm ($10) to this model (Y/N)? ");
            string arm = Console.ReadLine().ToUpper();
            switch (arm)
            {
                case "Y":
                    arm = "true";
                    break;
                case "N":
                    arm = "false";
                    break;
                default:
                    arm = "invalid";
                    break;
            }

            return arm;
        }

        /// <summary>
        /// Allows a user to add a computer connection to a droid.
        /// </summary>
        /// <returns>string</returns>
        private string ChooseComputerConnectionOption()
        {
            Console.Write("\n\n\t\t\t\t\t");
            Console.Write("Would you like to add a computer connection ($20) to this model (Y/N)? ");
            string compcnxn = Console.ReadLine().ToUpper();
            switch (compcnxn)
            {
                case "Y":
                    compcnxn = "true";
                    break;
                case "N":
                    compcnxn = "false";
                    break;
                default:
                    compcnxn = "invalid";
                    break;
            }

            return compcnxn;
        }

        /// <summary>
        /// Allows a user to choose options specific to a janitor droid.
        /// </summary>
        /// <returns>string[]</returns>
        private string[] ChooseJanitorDroidSpecifics()
        {
            Console.Write("\n\n\t\t\t\t\t");
            Console.Write("Would you like to add a trash compactor ($15) to this model (Y/N)? ");
            string compactorChoice = Console.ReadLine().ToUpper();
            switch (compactorChoice)
            {
                case "Y":
                    compactorChoice = "true";
                    break;
                case "N":
                    compactorChoice = "false";
                    break;
                default:
                    compactorChoice = "invalid";
                    break;
            }

            Console.Write("\n\n\t\t\t\t\t");
            Console.Write("Would you like to add a vacuum to this model (Y/N)? ");
            string vacuumChoice = Console.ReadLine().ToUpper();
            switch (vacuumChoice)
            {
                case "Y":
                    vacuumChoice = "true";
                    break;
                case "N":
                    vacuumChoice = "false";
                    break;
                default:
                    vacuumChoice = "invalid";
                    break;
            }

            return new[] { compactorChoice, vacuumChoice };
        }

        /// <summary>
        /// Allows a user to choose options aspecific to an astromech droid.
        /// </summary>
        /// <returns>string[]</returns>
        private string[] ChooseAstromechDroidSpecifics()
        {
            Console.Write("\n\n\t\t\t\t\t");
            Console.Write("Would you like to add a fire extinguisher ($35) to this model (Y/N)? ");
            string extinguisherChoice = Console.ReadLine().ToUpper();
            switch (extinguisherChoice)
            {
                case "Y":
                    extinguisherChoice = "true";
                    break;
                case "N":
                    extinguisherChoice = "false";
                    break;
                default:
                    extinguisherChoice = "invalid";
                    break;
            }

            Console.Write("\n\n\t\t\t\t\t");
            Console.Write("How many ships would you like to support? ");
            string ships = Console.ReadLine();
            int number;
            if (!int.TryParse(ships, out number)) ships = "invalid";

            return new[] { extinguisherChoice, ships };
        }

        /// <summary>
        /// Method to determine which material is selected based on
        /// a user's choice from the material menu.
        /// </summary>
        /// <returns>string</returns>
        private string DetermineMaterial()
        {
            Console.ResetColor();
            string material = Console.ReadLine().ToUpper();
            switch (material)
            {
                case "P":
                    material = "Polyskin";
                    break;
                case "M":
                    material = "Metaskin";
                    break;
                case "C":
                    material = "Ceraskin";
                    break;
                default:
                    material = "invalid";
                    break;
            }

            return material;
        }

        /// <summary>
        /// Method to determine which color is selected based on
        /// their choice from the color menu.
        /// </summary>
        /// <returns>string</returns>
        private string DetermineColor()
        {
            Console.ResetColor();
            string color = Console.ReadLine().ToUpper();
            switch (color)
            {
                case "B":
                    color = "Black";
                    break;
                case "R":
                    color = "Red";
                    break;
                case "W":
                    color = "White";
                    break;
                default:
                    color = "invalid";
                    break;
            }

            return color;
        }

        #endregion

        #region Validation

        /// <summary>
        /// Input validation method. Loops through a string array. Returns
        /// false if "invalid" is found in the array.
        /// </summary>
        /// <param name="droid"></param>
        /// <returns>bool</returns>
        public bool ValidateDroidEntries(string[] droid)
        {
            for (int i = 0; i < droid.Length; i++)
            {
                if (droid[i] == "invalid") return false;
            }
            return true;
        }

        #endregion

    }
}
