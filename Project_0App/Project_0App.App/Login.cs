using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_0App.App
{
    public class Login
    {
        // Modify Switch statment in Dec 11, 2021
        /*
        public void LoginScreen(ref MainProgram.Mode myMode)
        {
            int input;
            bool TryAgain = false;

            do
            {
                Console.WriteLine("Please choose a number from menu:\n1. New Customer\n2. Returned Customer\n3. Manager\n4. Exit");
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    switch (input)
                    {
                        case 1: 
                            myMode = MainProgram.Mode.NewCustomer;
                            break;
                        case 2: 
                            myMode = MainProgram.Mode.ReturnedCustomer; 
                            break;
                        case 3: 
                            myMode = MainProgram.Mode.Manager; 
                            break;
                        case 4: 
                            myMode = MainProgram.Mode.Exit; 
                            break;
                        default: 
                            TryAgain = true;
                            Console.WriteLine("Your input don't mathc any menu. Please try again.\n");
                            break;
                    }
                    if (1 <= input && input <= 4) break;
                }
                else
                {
                    Console.WriteLine("Your input is not number. Please try again.\n");
                    TryAgain = true;
                }
            }
            while (TryAgain);
            
        }
        */

        public void LoginScreen(ref MainProgram.Mode myMode, ref int CustomerId)
        {
            int input;
            bool TryAgain = false;

            do
            {
                Console.WriteLine("Please choose a number from menu:\n1. New Customer\n2. Returned Customer\n3. Exit");
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    switch (input)
                    {
                        case 1:
                            myMode = MainProgram.Mode.NewCustomer;
                            break;
                        case 2:
                            CheckLogin(ref myMode, ref CustomerId);
                            break;
                        case 3:
                            myMode = MainProgram.Mode.Exit;
                            break;
                        default:
                            TryAgain = true;
                            Console.WriteLine("Your input don't mathc any menu. Please try again.\n");
                            break;
                    }
                    if (1 <= input && input <= 4) break;
                }
                else
                {
                    Console.WriteLine("Your input is not number. Please try again.\n");
                    TryAgain = true;
                }
            }
            while (TryAgain);

        }
        private static void CheckLogin(ref MainProgram.Mode myMode, ref int Id)
        {
            DatabaseConnect db = new DatabaseConnect();
            bool matching = false;
            int CustomerId = 0;
            bool IsManager = false;
            Console.WriteLine("Test in ReturnedCustomer.cs");

            do
            {
                Console.WriteLine("If you want to cancel login. Then enter \"quit\" to close the program");
                Console.Write("Enter your username: ");
                string? Username = Console.ReadLine();
                if (Username == "quit")
                {
                    myMode = MainProgram.Mode.Exit;
                    break;
                }

                Console.Write("Enter your password: ");
                string? Password = Console.ReadLine();

                matching = db.CheckUsernameAndPassword(Username, Password, ref CustomerId, ref IsManager);
                if (!matching) // if user's login doesn't matching to the database
                {
                    Console.WriteLine("Your username or password is invalid. Try again.");
                }
                
                if(matching) // if user's login is matching to the database
                {
                    if(IsManager) // if the user is manager
                    {
                        myMode = MainProgram.Mode.ManagerRequest;
                    }
                    else // if the user is customer
                    {
                        Id = CustomerId;
                        myMode = MainProgram.Mode.CustomerRequest;
                    }
                }
                Console.ReadLine();
            }
            while (!matching);

            //Console.WriteLine($"The customer 's id is {CustomerId}");
        }
    }
}
