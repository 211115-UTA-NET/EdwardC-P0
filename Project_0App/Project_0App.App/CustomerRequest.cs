using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_0App.App
{
    public class CustomerRequest
    {
        public void EnterCustomerRequest(ref MainProgram.Mode myMode, int CustomerId, ref int StoreId)
        {
            DatabaseConnect db = new DatabaseConnect();
            int input;
            bool TryAgain = true;

            GetStoreLocation(db, ref StoreId);

            do
            {
                Console.WriteLine("\nPlease choose a number from menu:\n1. Check your order hisoty\n2. See item's information" +
                                  "\n3. Check store history\n4. Ready to order items\n5. Exit");
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    switch (input)
                    {
                        case 1:
                            db.DisplayCustomerOrderHistory(CustomerId);
                            break;
                        case 2:
                            // Got to OrderDetail.cs
                            db.DisplayOrderDetail();
                            break;
                        case 3: 
                            db.DisplayStoreOrderHistory(StoreId);
                            break;
                        case 4:
                            // Go to SetOrder.cs
                            myMode = MainProgram.Mode.SetOrder;
                            break;
                        case 5:
                            // Exit
                            myMode = MainProgram.Mode.Exit;
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

        static void GetStoreLocation(DatabaseConnect db, ref int storeId)
        {
            bool IsChoose = false;
            Console.WriteLine("Pick a location followed: ");
            db.getStoreLocation();

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
