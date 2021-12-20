using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_0App.App
{
    public class ManagerRequest
    {
        public void EnterRequest(ref MainProgram.Mode myMode)
        {
            DatabaseConnect db = new DatabaseConnect();
            int userInput = 0;
            Console.WriteLine("Hello Manager, How we can help you?\n");

            do
            {
                Console.WriteLine("Enter the number followed by the menu:\n1 - Check Store Inventory\n2 - Check Store Invoice\n3 - Exit");
                if(int.TryParse(Console.ReadLine(), out userInput))
                {
                    switch(userInput)
                    {
                        case 1:
                            DisplayStoreInventory(db);
                            break;
                        case 2: 
                            DisplayStoreHistory(db);
                            break;
                        case 3:
                            myMode = MainProgram.Mode.Exit;
                            break;
                        default: 
                            Console.WriteLine("Your input is invalid. Pleas try again"); 
                            break;
                    }
                }
            } 
            while (true);

        }

        private static void DisplayStoreInventory(DatabaseConnect db)
        {
            int input = 0;
            do
            {
                Console.WriteLine("Choose a store location or all location");
                db.getStoreLocation();
                Console.WriteLine("4) All of the Adove");
                if (int.TryParse((Console.ReadLine()), out input))
                {
                    if (1 <= input && input <= 3)
                    {
                        db.RetrieveStoreItems(input);
                        break;
                    }
                    else if (input == 4)
                    {
                        db.RetrieveAllStoreItems();
                        break;
                    }
                    else
                        Console.WriteLine("Your input is invalid due to number.");
                }
                else
                {
                    Console.WriteLine("Your input is invalid due to not whole number");
                }
            }
            while (true);
        }

        private static void DisplayStoreHistory(DatabaseConnect db)
        {
            int input = 0;
            do
            {
                Console.WriteLine("Choose a store location or all location");
                db.getStoreLocation();
                Console.WriteLine("4) All of the Adove");
                if (int.TryParse((Console.ReadLine()), out input))
                {
                    if (1 <= input && input <= 3)
                    {
                        db.DisplayStoreOrderHistory(input);
                        break;
                    }
                    else if (input == 4)
                    {
                        db.DisplayALLStoreOrderHistory();
                        break;
                    }
                    else
                        Console.WriteLine("Your input is invalid due to number.");
                }
                else
                {
                    Console.WriteLine("Your input is invalid due to not whole number");
                }
            }
            while (true);
        }

    }
}
