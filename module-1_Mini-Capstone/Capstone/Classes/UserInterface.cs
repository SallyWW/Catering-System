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
        private Customer customer = new Customer();

        /// <summary>
        /// runs the main interface, creates a new customer
        /// </summary>
        public void RunInterface()
        {
            bool done = false;
            int menuSelection = -1;

            menuInitialization.ReadInMenuFile();
            catering = menuInitialization.getCatering();

            //Customer customer = new Customer();

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
        /// <returns>Returns menu selection from 1-3</returns>
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
        /// <summary>
        /// presents the user with an interface for adding money, buying,
        /// and returning to the main menu
        /// </summary>

        private void OrderInterface()
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
                        AddToBalance();
                        break;
                    case 2:
                        //logic to select products
                        ProductSelection();
                        break;
                    case 3:
                        //set escape condition to true
                        done = true;
                        break;
                }


            }
        }

        /// <summary>
        /// prints a formated list of inventory items, their cost,
        /// inventory amount, name, and code
        /// </summary>
        /// <param name="input">List of items on the menu</param>

        private void DisplayItems(List<CateringItem> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                Console.WriteLine(input[i].ToString());
            }
        }


        /// <summary>
        /// Adds a dollar amount to a customers account.
        /// total cannot be less than 0 or greater than 5k
        /// </summary>
        /// <param name="input">Customer Object who's account is changed</param>
        private void AddToBalance()
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
                    if (customer.CurrentAccountBalance + toAdd > 5000)
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

            customer.ChangeBalance(toAdd);

        }

        /// <summary>
        /// Main logic for adding items to the Customers "cart" for purchase
        /// </summary>
        /// 
        private void ProductSelection()
        {

            string userInput = "";
            bool isFound = false;
            ItemOnMenu(ref userInput, ref isFound);
            CateringItem currentSelection = catering.GetItemFromList(userInput);
            int amountToBuy = AmountToBuy(currentSelection);///

            BuyItem(amountToBuy, currentSelection);



        }

        private int AmountToBuy(CateringItem currentItem)
        {
            int userInput = 0;
            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("Please enter the amount to purchase: ");
                try
                {
                    userInput = int.Parse(Console.ReadLine());
                    if (userInput > currentItem.Inventory)
                    {
                        throw new IndexOutOfRangeException("userInput");
                    }
                    validInput = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Invalid format");
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine("Not enough inventory");
                }

            }

            return userInput;
        }

        /// <summary>
        /// Checks to see if an Item exists on a menu based on it's code
        /// </summary>
        /// <param name="userInput">The code a user wished to check</param>
        /// <param name="isFound">Returns true if the item exists</param>
        private void ItemOnMenu(ref string userInput, ref bool isFound)
        {
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="amountToBuy"></param>
        /// <param name="selectedItem"></param>
        private void BuyItem(int amountToBuy, CateringItem selectedItem)
        {

            if (CustomerCanAfford(selectedItem, amountToBuy))
            {
                selectedItem.RemoveInventory(amountToBuy);
                CateringItem customerPurchase =
                    new CateringItem(selectedItem.Code, selectedItem.Name, selectedItem.Price, selectedItem.Type, amountToBuy);
                customer.AddToPurchases(customerPurchase);
                customer.removeBalance(amountToBuy * selectedItem.Price);

            }

        }

        private bool CustomerCanAfford(CateringItem currentItem, int amountToBuy)
        {
            bool canAfford = false;
            if (customer.CurrentAccountBalance < (currentItem.Price * amountToBuy))
            {
                Console.WriteLine("Not enough money...");
                return canAfford;
            }
            return true;
        }




    }
}
