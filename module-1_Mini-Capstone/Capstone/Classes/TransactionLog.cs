using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class TransactionLog
    {
        public string TransactionName { get; }
        public double TransactionAmount { get; }
        public double TotalRemainingAmount { get; }
        public DateTime TransactionDateTime { get; }

        public TransactionLog(string transactionName, double transactionAmount, double totalRemainingAmount, DateTime transactionDateTime)
        {
            this.TransactionName = transactionName;
            this.TransactionAmount = transactionAmount;
            this.TotalRemainingAmount = totalRemainingAmount;
            this.TransactionDateTime = transactionDateTime;
        }
    }
}
