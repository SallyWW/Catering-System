using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class provides all user communications, but not much else.
    /// All the "work" of the application should be done elsewhere
    /// </summary>
    /// <remarks>
    /// ALL instances of Console.ReadLine and Console.WriteLine in your application should be in this class
    /// </remarks>
    public class UserInterface
    {
        private Catering catering = new Catering();
        private FileAccess menuInitialization = new FileAccess();


        public void RunInterface()
        {
            bool done = false;
            int menuSelection = -1;

            menuInitialization.ReadInMenuFile();
            catering = menuInitialization.getCatering();
            while (!done)
            {
                Console.WriteLine("Welcome to Catering Vendor, Weyland Corporation!");
                Console.WriteLine("(1) Display Catering Items");
                Console.WriteLine("(2) Order");
                Console.WriteLine("(3) Quit");
                menuSelection = MenuSelection();

                switch (menuSelection)
                {
                    case 1:
                        //logic for displaying catering items
                        DisplayItems(catering.getItems());
                        break;
                    case 2:
                        // logic for oplacing an order
                        OrderInterface();
                        break;
                    case 3:
                        //set escape condition to true
                        done = true;
                        break;
                }
            }
        }


        /// <summary>
        /// Logic to check user input for a valid menu selection
        /// returns Menu input as an int from 1-3
        /// </summary>
        /// <returns></returns>
        public int MenuSelection()
        {
            int menuSelection = -1;
            bool validInput = false;
            
            while (!validInput)
            {
                try
                {
                    menuSelection = int.Parse(Console.ReadLine());
                    if (menuSelection > 0 && menuSelection < 4)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number from 1 to 3");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Invalid input, try again");
                }
            }

            return menuSelection;
        }

        public void OrderInterface()
        {
            bool done = false;
            int menuSelection = -1;

            while (!done)
            {
                Console.WriteLine("(1) Add Money");
                Console.WriteLine("(2) Select Products");
                Console.WriteLine("(3) Complete Transaction");
                //will display balance RETURN TO THIS
                Console.WriteLine("Current Account Balance : ");

                menuSelection = MenuSelection();
                switch (menuSelection)
                {
                    case 1:
                        //logic to add money
                        break;
                    case 2:
                        //logic to select products
                        break;
                    case 3:
                        //set escape condition to true
                        done = true;
                        break;
                }


            }
        }

        public void DisplayItems(List<CateringItem> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                Console.WriteLine(input[i].ToString());
            }
        }


    }
}
