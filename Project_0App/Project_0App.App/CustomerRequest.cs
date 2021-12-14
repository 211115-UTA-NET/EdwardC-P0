using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_0App.App
{
    public class CustomerRequest
    {
        public void EnterCustomerRequest(ref MainProgram.Mode myMode)
        {
            int input;
            bool TryAgain = false;

            do
            {
                Console.WriteLine("Please choose a number from menu:\n1. Check your order hisoty\n2. See item's information" +
                                  "\n3. Check store history\n4. Ready to order items\n5. Exit");
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    switch (input)
                    {
                        case 1:
                            // Go to CustomerOrderHistory.cs
                            break;
                        case 2:
                            // Got to OrderDetail.cs
                            break;
                        case 3: 
                            // Go to StoreOrderHistory.cs
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
    }
}
