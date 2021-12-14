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
        public MainProgram.Mode LoginScreen(MainProgram.Mode myMode)
        {
            int input;
            bool TryAgain;

            do
            {
                Console.WriteLine("Please choose a number from menu:\n1. New Customer\n2. Returned Customer\n3. Manager\n4. Exit");
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    switch (input)
                    {
                        case 1: return MainProgram.Mode.NewCustomer;
                        case 2: return MainProgram.Mode.ReturnedCustomer;
                        case 3: return MainProgram.Mode.Manager;
                        case 4: return MainProgram.Mode.Exit;
                        default: 
                            TryAgain = true;
                            Console.WriteLine("Your input don't mathc any menu. Please try again.\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Your input is not number. Please try again.\n");
                    TryAgain = true;
                }
            }
            while (TryAgain);
            return MainProgram.Mode.Exit;
        }
    }
}
