using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_0App.App
{
    public class ManagerRequest : Search
    {
        /// <summary>
        /// For Manager to check the store's inventory and Invoices
        /// Also, search customer's name
        /// </summary>
        /// <param name="myMode"></param>
        public void EnterRequest(ref MainProgram.Mode myMode)
        {
            RetrieveDatabaseRecords retrieve = new RetrieveDatabaseRecords();
            CheckDatabaseRecords check = new CheckDatabaseRecords();
            int userInput = 0;
            Console.WriteLine("Hello Manager, How we can help you?");

            do
            {
                Console.WriteLine("\nEnter the number followed by the menu:\n1 - Check Store Inventory\n2 - Check Store Invoice\n3 - Search Customer \n4 - Exit");
                if(int.TryParse(Console.ReadLine(), out userInput))
                {
                    switch(userInput)
                    {
                        case 1:
                            DisplayStoreInventory(retrieve);
                            break;
                        case 2: 
                            DisplayStoreHistory(retrieve);
                            break;
                        case 3:
                            SearchName(check);
                            break;
                        case 4:
                            myMode = MainProgram.Mode.Login;
                            break;
                        default: 
                            Console.WriteLine("Your input is invalid. Pleas try again"); 
                            break;
                    }
                    if (userInput == 4)
                        break;
                }
            } 
            while (true);

        }

        private static void DisplayStoreInventory(RetrieveDatabaseRecords retrieve)
        {
            int input = 0;
            do
            {
                Console.WriteLine("Choose a store location or all location");
                retrieve.RetrieveStoreLocation();
                Console.WriteLine("4) All of the Adove");
                if (int.TryParse((Console.ReadLine()), out input))
                {
                    if (1 <= input && input <= 3)
                    {
                        retrieve.RetrieveStoreItems(input);
                        break;
                    }
                    else if (input == 4)
                    {
                        retrieve.RetrieveAllStoreItems();
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

        private static void DisplayStoreHistory(RetrieveDatabaseRecords retrieve)
        {
            int input = 0;
            do
            {
                Console.WriteLine("Choose a store location or all location");
                retrieve.RetrieveStoreLocation();
                Console.WriteLine("4) All of the Adove");
                if (int.TryParse((Console.ReadLine()), out input))
                {
                    if (1 <= input && input <= 3)
                    {
                        retrieve.RetrieveStoreInvoices(input);
                        break;
                    }
                    else if (input == 4)
                    {
                        retrieve.RetrieveALLStoreInvoices();
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

        private static void SearchName(CheckDatabaseRecords check)
        {
            string? searchName = "";
            bool Found = false;

            do
            {
                Console.WriteLine("Enter a customer's first name: ");
                searchName = Console.ReadLine();

                if (searchName != null)
                {
                    if (searchName != "")
                    {
                        Found = check.SearchCustomers(searchName);
                        break;
                    }
                    else
                        Console.WriteLine("Your input is  empty");
                }   
            }
            while (true);

            if (Found)
            {
                Console.WriteLine("The name that you enter is found.");
            }
            else
                Console.WriteLine("The name that you enter is not found.");

        }

    }
}
