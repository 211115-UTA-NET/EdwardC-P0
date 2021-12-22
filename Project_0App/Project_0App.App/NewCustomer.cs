using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_0App.App
{
    public class NewCustomer
    {
        /// <summary>
        /// Get the information for new customer, then add to database (Customers and Login Table)
        /// Then Change Customer RequestMode to myMode and return CustomerId too
        /// </summary>
        /// <param name="myMode"></param>
        /// <param name="CustomerId"></param>
        public void EnterNewCustomer(ref MainProgram.Mode myMode, ref int CustomerId)
        {
            ModifyDatabaseRecords db = new ModifyDatabaseRecords();
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
                if(i == 4)
                {
                    if(input?.Length >= 11)
                    {
                        Console.WriteLine("You enter more than 10 digit. Try again");
                        input = null;
                        i--;
                    }
                }
                if (input != null)
                    inputs.Add(input);
            }

            db.AddCustomerToDatabase(inputs, ref CustomerId);
            myMode = MainProgram.Mode.CustomerRequest;
        }
    }
}
