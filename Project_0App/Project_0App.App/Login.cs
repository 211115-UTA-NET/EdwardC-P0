using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_0App.App
{
    public class Login
    {
        private string? _username { get; set; }
        private string? _password { get; set; }

        public void LoginScreen()
        {
            int input;
            Console.WriteLine("Please choose a number from menu:\n1. New Customer\n2. Returned Customer\n3. Manager");
            if(int.TryParse(Console.ReadLine(), out input))
            {
                switch (input)
                {
                    case 1: break;
                    case 2: break;
                    case 3: break;
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
