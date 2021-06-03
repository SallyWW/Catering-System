using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class should contain all the "work" for catering
    /// </summary>
    /// <remarks>
    /// NO Console statements are allowed in this class
    /// </remarks>
    public class Catering
    {
        private List<CateringItem> items = new List<CateringItem>();
        private List<Customer> customers = new List<Customer>();

        
        public void addCateringItem(CateringItem toAdd)
        {

            items.Add(toAdd);
        }

        public List<CateringItem> getItems()
        {
            return items;
        }
   
        public bool ItemExists(string userCode)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Code == userCode)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
