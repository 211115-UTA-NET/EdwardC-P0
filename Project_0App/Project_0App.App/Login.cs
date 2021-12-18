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
    }
}
