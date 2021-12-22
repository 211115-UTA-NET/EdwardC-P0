using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_0App.App
{
    public class ReturnedCustomer
    {
        public string? _Username { get; set; }
        public string? _Password { get; set; }
        public int _Id { get; set; }

        public void EnterReturnedCustomer(ref MainProgram.Mode myMode)
        {
            CheckDatabaseRecords check = new CheckDatabaseRecords();
            bool matching = false;
            int CustomerId = 0;
            bool IsManager = false;
            Console.WriteLine("Test in ReturnedCustomer.cs");

            do
            {
                Console.WriteLine("If you want to cancel login. Then enter \"quit\"");
                Console.Write("Enter your username: ");
                _Username = Console.ReadLine();
                if(_Username == "quit")
                {
                    myMode = MainProgram.Mode.Exit;
                    break;
                }

                Console.Write("Enter your password: ");
                _Password = Console.ReadLine();

                matching = check.CheckUsernameAndPassword(_Username, _Password, ref CustomerId, ref IsManager);
                if(!matching)
                {
                    Console.WriteLine("Your username or password is invalid. Try again.");
                }
            }
            while (!matching);

            if(!IsManager)
            {
                myMode = MainProgram.Mode.CustomerRequest;
            }
            else
            {
                myMode = MainProgram.Mode.ManagerRequest;
            }
        }
    }
}
