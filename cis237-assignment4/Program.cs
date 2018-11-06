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
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface aMenu = new UserInterface();
            DroidCollection collection = new DroidCollection();

            DisplayMainMenu();

            void DisplayMainMenu()
            {
                Console.Clear();
                Console.Write(aMenu.MainMenu());
                Console.Write("\n\n\t\t\t");
                var menuChoice = Console.ReadLine();
                HandleMainMenuInput(menuChoice);
            }

            void DisplayDroidMenu()
            {
                Console.Clear();
                Console.ResetColor();
                Console.Write(aMenu.DroidSelection());
                Console.Write("\n\n\t\t\t\t\t");
                string droidType = Console.ReadLine().ToUpper();
                HandleDroidMenuInput(droidType);
            }

            void HandleMainMenuInput(string userSelection)
            {
                userSelection = userSelection.ToUpper();
                switch (userSelection)
                {
                    case "A":
                        DisplayDroidMenu();
                        break;

                    case "T":
                        AddTestData();
                        Console.WriteLine(aMenu.TestDataAdded());
                        aMenu.Pause();
                        DisplayMainMenu();
                        break;

                    case "P":
                        if (IsEmpty())
                        {
                            Console.WriteLine(aMenu.NothingToPrint());
                            aMenu.Pause();
                        }
                        else
                        {
                            Console.Write(aMenu.PrintListMessage());
                            string[] allDroids = collection.PrintTheDroidsInventory();
                            aMenu.WaitForUser();
                        }
                        DisplayMainMenu();
                        break;

                    case "C":
                        if (IsEmpty())
                        {
                            Console.WriteLine(aMenu.NothingToSort());
                        }
                        else
                        {
                            collection.CategorizeByModel();
                            Console.WriteLine(aMenu.DroidsSortedByCategory());
                        }
                        aMenu.Pause();
                        DisplayMainMenu();
                        break;
                    case "M":
                        if (IsEmpty())
                        {
                            Console.WriteLine(aMenu.NothingToSort());
                        }
                        else
                        {
                            collection.MergeSortByTotalCost();
                            Console.WriteLine(aMenu.DroidsSortedByTotalCost());
                        }
                        aMenu.Pause();
                        DisplayMainMenu();
                        break;

                    case "Q":
                        Console.WriteLine(aMenu.QuitProgramMessage());
                        aMenu.Pause();
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine(aMenu.InvalidOptionMessage());
                        aMenu.Pause();
                        DisplayMainMenu();
                        break;
                }
            }

            void AddTestData()
            {
                // protocol
                collection.Add("Polyskin", "Red", 6);
                collection.Add("Metaskin", "Black", 23);
                collection.Add("Ceraskin", "White", 13);

                //astromech
                collection.Add("Polyskin", "White", false, false, true, true, 12);
                collection.Add("Metaskin", "Black", false, false, false, true, 36);
                collection.Add("Metaskin", "Red", false, true, false, true, 24);

                //janitor
                collection.Add("Ceraskin", "Red", false, true, false, true, false);
                collection.Add("Metaskin", "White", false, false, true, false, false);
                collection.Add("Polyskin", "Black", true, false, true, true, true);

                //utility
                collection.Add("Metaskin", "Red", false, true, false);
                collection.Add("Polyskin", "White", true, true, false);
                collection.Add("Ceraskin", "Black", true, false, true);
            }

            // droid menu input handler
            void HandleDroidMenuInput(string droidType)
            {
                switch (droidType)
                {
                    case "P":
                        string[] protocol = aMenu.BuildProtocolDroid();
                        if (aMenu.ValidateDroidEntries(protocol))
                        {
                            collection.Add(protocol[0], protocol[1], int.Parse(protocol[2]));
                            Console.WriteLine(aMenu.DroidAdded());
                        }
                        else
                        {
                            InvalidInformation();
                        }
                        break;
                    case "U":
                        string[] utility = aMenu.BuildAUtilityDroid();
                        if (aMenu.ValidateDroidEntries(utility))
                        {
                            collection.Add(utility[0], utility[1], bool.Parse(utility[2]), bool.Parse(utility[3]), bool.Parse(utility[4]));
                            Console.WriteLine(aMenu.DroidAdded());
                        }
                        else
                        {
                            InvalidInformation();
                        }
                        break;
                    case "J":
                        string[] janitor = aMenu.BuildAJanitorDroid();
                        if (aMenu.ValidateDroidEntries(janitor))
                        {
                            collection.Add(janitor[0], janitor[1], bool.Parse(janitor[2]), bool.Parse(janitor[3]), bool.Parse(janitor[4]), bool.Parse(janitor[5]), bool.Parse(janitor[6]));
                            Console.WriteLine(aMenu.DroidAdded());
                        }
                        else
                        {
                            InvalidInformation();
                        }
                        break;
                    case "A":
                        string[] astromech = aMenu.BuildAnAstromechDroid();
                        if (aMenu.ValidateDroidEntries(astromech))
                        {
                            collection.Add(astromech[0], astromech[1], bool.Parse(astromech[2]), bool.Parse(astromech[3]), bool.Parse(astromech[4]), bool.Parse(astromech[5]), int.Parse(astromech[6]));
                            Console.WriteLine(aMenu.DroidAdded());
                        }
                        else
                        {
                            InvalidInformation();
                        }

                        break;
                    case "M":
                        DisplayMainMenu();
                        break;
                    default:
                        Console.WriteLine(aMenu.InvalidOptionMessage());
                        aMenu.Pause();
                        break;
                }
                aMenu.Pause();
                DisplayDroidMenu();
            }

            // The Badlands
            void InvalidInformation()
            {
                Console.Write(aMenu.InvalidInformation());
                aMenu.Pause();
                Console.ResetColor();
            }

            bool IsEmpty()
            {
                return collection.IsEmpty(collection.GetDroidArray());
            }
        }
    }
}
