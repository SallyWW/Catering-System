using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class TotalSales
    {
        public double RunningTotal { get; private set; }

        private List<Sales> salesLog = new List<Sales>();
        private List<TransactionLog> customerTransaction = new List<TransactionLog>();


        public void AddSale(Sales currentSale)
        {
            salesLog.Add(currentSale);
        }

        public void SetCustomerTransaction(Customer currentCustomer)
        {
            customerTransaction = currentCustomer.GetTransactions();
        }



    }
}
