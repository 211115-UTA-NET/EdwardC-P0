using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_0App.App
{
    public class Logout
    {
        /// <summary>
        /// Ask customer to log out or continue shopping
        /// </summary>
        /// <param name="myMode"></param>
        public void SignoutOrOrderMore(ref MainProgram.Mode myMode) // For Customer
        {
            string? input;
            // prompt user to sign out or continue order other item
            Console.WriteLine("Want to log out or continure shopping?\nEnter '1' to Log out or '2' to continue order");
            input = Console.ReadLine();
            if (input == "1")
                myMode = MainProgram.Mode.Login;
            else if (input == "2")
                myMode = MainProgram.Mode.CustomerRequest;

            Console.WriteLine();
        }
    }
}
