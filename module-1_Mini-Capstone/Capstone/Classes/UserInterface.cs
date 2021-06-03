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

        /// <summary>
        /// 
        /// </summary>
        public void RunInterface()
        {
            bool done = false;
            int menuSelection = -1;

            menuInitialization.ReadInMenuFile();
            catering = menuInitialization.getCatering();

            Customer customer = new Customer("Bob");

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
                        OrderInterface(customer);
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
        private int MenuSelection()
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

        private void OrderInterface(Customer customer)
        {
            bool done = false;
            int menuSelection = -1;

            while (!done)
            {
                Console.WriteLine("(1) Add Money");
                Console.WriteLine("(2) Select Products");
                Console.WriteLine("(3) Complete Transaction");
                //will display balance RETURN TO THIS
                Console.WriteLine("Current Account Balance : " + customer.CurrentAccountBalance);

                menuSelection = MenuSelection();
                switch (menuSelection)
                {
                    case 1:
                        //logic to add money
                        AddToBalance(customer);
                        break;
                    case 2:
                        //logic to select products
                        ProductSelection(customer);
                        break;
                    case 3:
                        //set escape condition to true
                        done = true;
                        break;
                }


            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>

        private void DisplayItems(List<CateringItem> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                Console.WriteLine(input[i].ToString());
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        private void AddToBalance(Customer input)
        {
            int toAdd = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine("Please enter a positive amount to add: ");
                try
                {
                    toAdd = int.Parse(Console.ReadLine());

                    if (toAdd < 0)
                    {
                        throw new IndexOutOfRangeException("toAdd");
                    }
                    if (input.CurrentAccountBalance + toAdd > 5000)
                    {
                        throw new IndexOutOfRangeException("toAdd");
                    }
                    validInput = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Invalid input. Please enter a whole dollar amount.");
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine("Total balance cannot be less than 0 or greater than 5000.");
                }
            }

            input.ChangeBalance(toAdd);

        }

        private void ProductSelection(Customer customer)
        {
            string userInput = "";
            bool isFound = false;

            while (!isFound)
            {
                Console.WriteLine("Please enter a product code for purchase: ");
                userInput = Console.ReadLine().ToUpper();

                isFound = catering.ItemExists(userInput);

                if (isFound == false)
                {
                    Console.WriteLine("Item does not exist.");
                }
            }
        }
    }
}
