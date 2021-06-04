using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Customer
    {
        public double CurrentAccountBalance { get; private set; } = 0;

        private List<CateringItem> purchases = new List<CateringItem>();


        private Dictionary<string, int> wallet = new Dictionary<string, int>() {
            {"twenty", 0 },
            {"ten", 0 },
            {"five", 0 },
            {"one", 0 },
            {"quarter", 0 },
            {"dime", 0 },
            {"nickel", 0 }
        };


        /// <summary>
        /// Takes a positive int less than 5000 and adds it to the current balance
        /// </summary>
        /// <param name="input"></param>
        public void ChangeBalance(int input)
        {

            CurrentAccountBalance += input;
        }
        public List<CateringItem> GetPurchases()
        {
            return purchases;
        }

        public void removeBalance(double input)
        {
            CurrentAccountBalance -= input;
        }

        public void AddToPurchases(CateringItem itemBought)
        {
            purchases.Add(itemBought);
        }

        public void PrintCurrentCart()
        {
            string temp = "";
            foreach (CateringItem item in purchases)
            {
                temp = String.Format("{0, -5} {1, -10} {2, -25} {3, -10} {4, -10}",
                   item.Inventory, item.Type, item.Name, item.Price.ToString("C"), item.TotalAmount.ToString("C"));

            }
        }

        public void ChangeReturned()
        {


            wallet["twenty"] += MakeChange(20);
            wallet["ten"] += MakeChange(10);
            wallet["five"] += MakeChange(5);
            wallet["one"] += MakeChange(1);
            wallet["quarter"] += MakeChange(.25);
            wallet["dime"] += MakeChange(.1);
            wallet["nickel"] += MakeChange(0.05);

        }

        private int MakeChange(double inputCurrency)
        {
            int billQuantity = 0;

            billQuantity = (int)(CurrentAccountBalance / inputCurrency);
            removeBalance(billQuantity * inputCurrency);

            return billQuantity;
        }

        public void PrintWallet()
        {
            foreach(KeyValuePair<string, int> pair in wallet)
            {
                Console.WriteLine(pair.Key + " " + pair.Value);
            }
        }


    }

}
