﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Customer
    {
        public double CurrentAccountBalance { get; private set; } = 0;

        private List<CateringItem> pastPurchase = new List<CateringItem>();

        /// <summary>
        /// Takes a positive int less than 5000 and adds it to the current balance
        /// </summary>
        /// <param name="input"></param>
       public void ChangeBalance(int input)
        {

            CurrentAccountBalance += input;
        }

    }
}
