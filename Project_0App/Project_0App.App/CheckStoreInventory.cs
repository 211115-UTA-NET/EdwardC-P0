using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_0App.App
{
    public class CheckStoreInventory
    {
        public void RetrieveDataFromDatabase()
        {
            // Get data from Store Database
        }

        public void DisplayInventoryInformation() //Manager only
        {
            // Display store location, item, and quanities
        }

        public void IsItemAvaiable() // SetOrder.cs only
        {
            // Check if items and quanity are avaiable to CustomerOrder.
            // Ex: item: bike gear, quanity: 2
            // if customer is ask for one quanity then return true; or
            // customer is ask for three quanity, then return false;
        }

        public void UpdateStoreDatabase() // ProcessOrder.cs only
        {
            // Update Store database to decrease the quanity of item
        }
    }
}
