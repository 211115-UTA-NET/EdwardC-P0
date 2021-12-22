using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_0App.App
{
    public class ProcessOrder
    {
        /// <summary>
        /// Ask customer for final order before add to invoice(Invoices, InvoiceHistory, InvoiceList) 
        /// and pay the item. Customer can decide to pay or cancel the order.
        /// </summary>
        /// <param name="myMode"></param>       // Change myMode's varaible when done with process order
        /// <param name="CustomerId"></param>   // Assign Customer's Id
        /// <param name="StoreId"></param>      // Assign Store's Location
        /// <param name="userItems"></param>    // Store the array of Item Name
        /// <param name="userQuantity"></param> // Store the array of Quantity
        public void StartProcessOrder(ref MainProgram.Mode myMode, int CustomerId, int StoreId, List<string> userItems, List<int> userQuantity)
        {
            DatabaseConnect db = new DatabaseConnect();
            RetrieveDatabaseRecords retrieve = new RetrieveDatabaseRecords();
            ModifyDatabaseRecords modify = new ModifyDatabaseRecords();
            List<decimal> totalPrices = new List<decimal>();
            string? input;
            bool invalid = true;

            //prompt user to confirm the final process order
            Console.WriteLine("\nStart Process Order");
            DisplayListofItems(retrieve, userItems, userQuantity, ref totalPrices);
            Console.WriteLine("------------------------------");

            do
            {
                Console.WriteLine("\nFinal confirming, Are you ready to check out? Enter 'yes' to process or 'no' to cancel");
                input = Console.ReadLine();

                if (input == "yes")
                {
                    // Update database to decrease quantity and add Invoices for Customer and Store history
                    UpdateDatabaseDecreaseInventory(modify, StoreId, userItems, userQuantity);
                    AddHistoryToInvoices(modify, CustomerId, StoreId, userItems, userQuantity, totalPrices);
                    Console.WriteLine("Your order is complete.");
                    myMode = MainProgram.Mode.Logout;
                    break;
                }
                else if (input == "no")
                {
                    myMode = MainProgram.Mode.Logout;
                    Console.WriteLine("Your order is canceled.");
                    break;
                }
                else
                {
                    Console.WriteLine("Your input is invalid. Please input again.");
                }
            }
            while (invalid);
        }

        private static void DisplayListofItems(RetrieveDatabaseRecords retrieve, List<string> userItems, List<int> userQuantity, ref List<decimal> TotalPrices)
        {
            decimal price = 0;

            // Display the list of items, quanities, prices, and total prices
            for (int i = 0; i < userItems.Count; i++)
            {
                price += retrieve.RetrieveInvoices(i+1, userItems[i], userQuantity[i], ref TotalPrices);
                
            }
            Console.WriteLine($"Final Price: {price}");
        }

        private static void UpdateDatabaseDecreaseInventory(ModifyDatabaseRecords modify, int StoreId, List<string> userItems, List<int> userQuantity)
        {
            // Decrease the list of item's quantity
            for (int i = 0; i < userItems.Count; i++)
            {
                modify.DecreaseStoreItems(StoreId, userItems[i], userQuantity[i]);

            }
        }

        private static void AddHistoryToInvoices(ModifyDatabaseRecords modify, int CustomerId, int StoreId, List<string> userItems, List<int> userQuantity, List<decimal> TotalPrices)
        {
            int InvoiceId = 0;
            DateTime date = DateTime.Now;

            for (int i = 0; i < userItems.Count; i++)
            {
                modify.AddInvoicesTable(CustomerId, StoreId);
                InvoiceId = modify.GetLatestInvoiceId();
                modify.AddInvoiceHistory(InvoiceId, date);
                modify.AddInvoiceList(InvoiceId, userItems[i], userQuantity[i], TotalPrices[i]);
            }


        }
    }
}
