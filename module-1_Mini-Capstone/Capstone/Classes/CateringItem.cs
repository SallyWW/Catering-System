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
        public int Inventory { get; private set; } = 50;

        public bool IsSoldOut
        {
            get
            {
                if (Inventory <= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public double TotalAmount { get
            {
                return Inventory * Price;
            } }


        public CateringItem(string code, string name, double price, string type)
        {
            this.Code = code;
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }

        public CateringItem(string code, string name, double price, string type, int inventory)
        {
            this.Code = code;
            this.Name = name;
            this.Price = price;
            this.Type = type;
            this.Inventory = inventory;
        }

        public void RemoveInventory(int itemsToRemove)
        {
            Inventory -= itemsToRemove;
        }

        public override string ToString()
        {
            string isSoldOut = "";
            string fullType = FullType();


            if (IsSoldOut == true)
            {
                isSoldOut = "SOLD OUT" ;
            }
            else
            {
                isSoldOut = Inventory.ToString();
            }

            return String.Format(" {0, -5} {1, -10} {2, -25} {3, -10} {4, -10}", Code, fullType, Name, Price.ToString("C"), isSoldOut);

        }

        public string FullType()
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

            return fullType;
        }

        
           

    }
}
