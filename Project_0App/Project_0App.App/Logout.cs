using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_0App.App
{
    public class Logout
    {
        public void SignoutOrOrderMore(ref MainProgram.Mode myMode) // For Customer
        {
            string? input;
            // prompt user to sign out or continue order other item
            Console.WriteLine("Your order is complete.\nWant to log out or continure order more item?\nEnter '1' to Log out or '2' to continue order");
            input = Console.ReadLine();
            if (input == "1")
                myMode = MainProgram.Mode.Login;
            else if (input == "2")
                myMode = MainProgram.Mode.SetOrder;

        }

        public void SignOut() // For Manager
        {

        }
    }
}
