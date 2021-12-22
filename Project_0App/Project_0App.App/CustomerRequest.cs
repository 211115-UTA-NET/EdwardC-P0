using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_0App.App
{
    public class CustomerRequest
    {
        /// <summary>
        /// Pick a location of store,
        /// Give the menu choices to customer, then run code based on customer's choice
        /// Menu: Order History, Item's Information, Store History, Ready to Order, and Exit
        /// </summary>
        /// <param name="myMode"></param>
        /// <param name="CustomerId"></param>
        /// <param name="StoreId"></param>
        public void EnterCustomerRequest(ref MainProgram.Mode myMode, int CustomerId, ref int StoreId)
        {
            //DatabaseConnect db = new DatabaseConnect();
            RetrieveDatabaseRecords retrieve = new RetrieveDatabaseRecords();
            int input;
            bool TryAgain = true;

            GetStoreLocation(retrieve, ref StoreId);

            do
            {
                Console.WriteLine("\nPlease choose a number from menu:\n1. Check your order hisoty\n2. See item's information" +
                                  "\n3. Check store history\n4. Ready to order items\n5. Exit");
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    switch (input)
                    {
                        case 1:
                            Console.WriteLine("------------------------------ \nYour Invoices: ");
                            retrieve.RetrieveCustomerInvoices(CustomerId);
                            //db.DisplayCustomerOrderHistory(CustomerId);
                            Console.WriteLine("------------------------------");
                            break;
                        case 2:
                            // Got to OrderDetail.cs
                            //db.DisplayOrderDetail();
                            Console.WriteLine("------------------------------\nItem's Detail: \n");
                            retrieve.RetrieveItemDetails();
                            Console.WriteLine("------------------------------");
                            break;
                        case 3:
                            //db.DisplayStoreOrderHistory(StoreId);
                            Console.WriteLine("------------------------------\nStore's Invoices: ");
                            retrieve.RetrieveStoreInvoices(StoreId);
                            Console.WriteLine("------------------------------");
                            break;
                        case 4:
                            // Go to SetOrder.cs
                            myMode = MainProgram.Mode.SetOrder;
                            break;
                        case 5:
                            // Exit
                            myMode = MainProgram.Mode.Login;
                            break;
                        default:
                            TryAgain = true;
                            Console.WriteLine("Your input don't mathc any menu. Please try again.\n");
                            break;
                    }
                    if (input == 4 || input == 5)
                        TryAgain = false;
                }
                else
                {
                    Console.WriteLine("Your input is not number. Please try again.\n");
                    TryAgain = true;
                }
            }
            while(TryAgain);
        }

        static void GetStoreLocation(RetrieveDatabaseRecords retrieve, ref int storeId)
        {
            bool IsChoose = false;
            Console.WriteLine("Pick a location followed: ");
            retrieve.RetrieveStoreLocation();

            while(!IsChoose)
            {
                if(int.TryParse(Console.ReadLine(), out storeId))
                {
                    IsChoose = true;
                }
                else
                {
                    Console.WriteLine("Your input is invalid. Try again.");
                }
            }


        }
    }
}
