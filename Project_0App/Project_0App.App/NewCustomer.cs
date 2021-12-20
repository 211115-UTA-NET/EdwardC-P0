using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_0App.App
{
    public class NewCustomer
    {
        DatabaseConnect database = new DatabaseConnect();
        // Add Method in Dec 11, 2021
        public void EnterNewCustomer(ref MainProgram.Mode mymode, ref int CustomerId)
        {
            List<string> inputs = new List<string>();
            string? input;

            Console.WriteLine("Please enter the information");
            for(int i = 0; i < 6; i++)
            {
                switch(i)
                {
                    case 0: 
                        Console.Write("First Name: "); 
                        break;
                    case 1: 
                        Console.Write("Last Name: "); 
                        break;
                    case 2: 
                        Console.Write("Phone Number: "); 
                        break;
                    case 3: 
                        Console.Write("Home Address: ");
                        break;
                    
                    case 4:
                        Console.Write("Username: ");
                        break;
                    case 5:
                        Console.Write("Password: ");
                        break;
                }
                input = Console.ReadLine();
                if (input != null)
                    inputs.Add(input);
            }

            database.AddCustomerToDatabase(inputs, ref CustomerId);
             mymode = MainProgram.Mode.CustomerRequest;
        }
    }
}
