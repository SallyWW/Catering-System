using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This represents a single catering item in your system
    /// </summary>
    /// <remarks>
    /// NO Console statements are allowed in this class
    /// </remarks>
    public class CateringItem
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }
        public string Type { get; private set; }
        public int inventory { get; private set; } = 50;
        public CateringItem(string code, string name, double price, string type)
        {
            this.Code = code;
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }
        public override string ToString()
        {
            string fullType = "";
            if (Type == "B")
            {
                fullType = "beverage";
            }
            else if (Type == "E")
            {
                fullType = "entree";
            }
            else if (Type == "A")
            {
                fullType = "appetizer";
            }
            else if (Type == "D")
            {
                fullType = "dessert";
            }
            return fullType + "\t" + Name + "\t" + Price + "\t" + inventory;
        }
    }
}
