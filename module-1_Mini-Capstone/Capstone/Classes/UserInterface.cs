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

        public void RunInterface()
        {
            bool done = false;
            int menuSelection = -1;

            while (!done)
            {
                Console.WriteLine("Welcome to Catering Vendor, Weyland Corporation!");
                Console.WriteLine("(1) Display Catering Items");
                Console.WriteLine("(2) Order");
                Console.WriteLine("(3) Quit");
                menuSelection = MenuSelection();

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

            while(!validInput)
            {
                try
                {
                    menuSelection = int.Parse(Console.ReadLine());
                    if(menuSelection > 0 && menuSelection < 4)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number from 1 to 3");
                    }
                }
                catch(FormatException ex)
                {
                    Console.WriteLine("Invalid input, try again");
                }
            }

            return menuSelection;
        }
    }
}
