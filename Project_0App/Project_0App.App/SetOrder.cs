using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_0App.App
{
    public class SetOrder
    {
        private static void DisplayListofItems(DatabaseConnect db, int StoreId)
        {
            // Get Display items list that are avaiable in store location
            db.RetrieveStoreItems(StoreId);
        }

        private static void getItemName()
        {

        }

        public void StartOrding(ref MainProgram.Mode myMode, int CustomerId, int StoreId)
        {
            // Access Class file
            DatabaseConnect db = new DatabaseConnect();
            ProcessOrder pOrder = new ProcessOrder();

            bool IsApproved = false;
            bool OrderMore = true;
            string? Answer = "";
            int tempNum1;
            int tempNum2;

            List<string> userItem = new List<string>(); // user's item
            List<int> userQuantity = new List<int>(); // user's Quantity

            List<string> itemNames = new List<string>(); // Store item name in list
            db.AssignItemNameToList(ref itemNames, StoreId);

            do
            {
                // prompt user to select item and how many quanity(s)
                Console.WriteLine("Chose the items followed by list");
                DisplayListofItems(db, StoreId);

                do
                {
                    Console.Write("Chose a item you want by number: ");
                    if(int.TryParse(Console.ReadLine(), out tempNum1))
                    {
                        if(tempNum1 > itemNames.Count || tempNum1 <= 0)
                        {
                            Console.WriteLine("The number you enter is invalid");
                        }
                        else
                        {
                            break;
                        }  
                    }
                    else
                    {
                        Console.WriteLine("Your input is invalid. Try Again.");
                    }
                } while (true);

                do
                {
                    Console.Write("How many quantity you want by number: ");
                    if (int.TryParse(Console.ReadLine(), out tempNum2))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Your input is invalid. Try Again.");
                    }
                } while (true);

                IsApproved = db.CheckItemQuantity(StoreId, tempNum2, itemNames[tempNum1 - 1]);
                if(IsApproved)
                {
                    Console.WriteLine("Your order is approved and add to you cart\n");

                    //FIXME: need to check if same item. If it is true, then update quantity instead add new list
                    userItem.Add(itemNames[tempNum1 - 1]);
                    userQuantity.Add(tempNum2);

                    do
                    {
                        Console.WriteLine("Want start process your order? or order more item?\nEnter 'process' to pay or 'add' to continue");
                        Answer = Console.ReadLine();
                        if (Answer == "process")
                        {
                            OrderMore = false;
                            break;
                        }
                        else if (Answer == "add")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Your input is invalid. Please enter your input again.");
                        }
                    }
                    while (true);
                }
                else
                    Console.WriteLine("Your order is reject due to lack of quantity we have. Our apologies for the inconvenience. Please enter with different quanity");
            }
            while (OrderMore);

            pOrder.StartProcessOrder(ref myMode, CustomerId, StoreId, userItem, userQuantity);
        }
    }
}
