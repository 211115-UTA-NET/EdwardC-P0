using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_0App.App
{
    public class ProcessOrder
    {
        public void StartProcessOrder(ref MainProgram.Mode myMode, int CustomerId, int StoreId, List<string> userItems, List<int> userQuantity)
        {
            DatabaseConnect db = new DatabaseConnect();
            List<decimal> totalPrices = new List<decimal>();
            string? input;
            bool invalid = true;

            //prompt user to confirm the final process order
            Console.WriteLine("\nProcess Order");
            DisplayListofItems(db, userItems, userQuantity, ref totalPrices);

            do
            {
                Console.WriteLine("\nFinal confirming, Are you ready to check out? Enter 'yes' to process or 'no' to cancel");
                input = Console.ReadLine();

                if (input == "yes")
                {
                    // Update database to decrease quantity and add Invoices for Customer and Store history
                    UpdateDatabaseDecreaseInventory(db, StoreId, userItems, userQuantity);
                    AddHistoryToInvoices(db, CustomerId, StoreId, userItems, userQuantity, totalPrices);
                    myMode = MainProgram.Mode.Logout;
                    break;
                }
                else if (input == "no")
                {
                    do
                    {
                        Console.WriteLine("Want to log out or start over with the order.\n Enter '1' for log out or '2' for start over");
                        input = Console.ReadLine();
                        if (input == "1")
                        {
                            myMode = MainProgram.Mode.Logout;
                            invalid = false;
                            break;
                        }
                        else if (input == "2")
                        {
                            myMode = MainProgram.Mode.SetOrder;
                            invalid = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Your input is invalid. Please input again.");
                        }
                    }
                    while (true);
                }
                else
                {
                    Console.WriteLine("Your input is invalid. Please input again.");
                }
            }
            while (invalid);
        }

        private static void DisplayListofItems(DatabaseConnect db, List<string> userItems, List<int> userQuantity, ref List<decimal> TotalPrices)
        {
            decimal price = 0;

            // Display the list of items, quanities, prices, and total prices
            for (int i = 0; i < userItems.Count; i++)
            {
                price += db.RetrieveInvoices(i+1, userItems[i], userQuantity[i], ref TotalPrices);
                
            }
            Console.WriteLine($"Final Price: {price}");
        }

        private static void UpdateDatabaseDecreaseInventory(DatabaseConnect db, int StoreId, List<string> userItems, List<int> userQuantity)
        {
            // Decrease the list of item's quantity
            for (int i = 0; i < userItems.Count; i++)
            {
                db.DecreaseStoreItems(StoreId, userItems[i], userQuantity[i]);

            }
        }

        private static void AddHistoryToInvoices(DatabaseConnect db, int CustomerId, int StoreId, List<string> userItems, List<int> userQuantity, List<decimal> TotalPrices)
        {
            int InvoiceId = 0;
            DateTime date = DateTime.Now;

            for (int i = 0; i < userItems.Count; i++)
            {
                db.AddInvoicesTable(CustomerId, StoreId);
                InvoiceId = db.GetLatestInvoiceId();
                db.AddInvoiceHistory(InvoiceId, date);
                db.AddInvoiceList(InvoiceId, userItems[i], userQuantity[i], TotalPrices[i]);
            }


        }
    }
}
