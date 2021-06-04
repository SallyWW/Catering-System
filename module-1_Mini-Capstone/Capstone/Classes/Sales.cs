using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Sales
    {
        public string Name { get; private set; }
        public int QuantitySold { get; private set; }
        public double ItemSales { get; private set; }

        public Sales(string name, int quantitySold, double ItemSales)
        {
            this.Name = name;
            this.QuantitySold = quantitySold;
            this.ItemSales = ItemSales;
        }


    }
}
