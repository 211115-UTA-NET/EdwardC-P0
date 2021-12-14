using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_0App.App
{
    public class Manager : Person
    {
        public string? _Username { get; }
        public string? _Password { get; }
        public int _ID { get; set; }

        public Manager(string username, string password)
        {
            _Username = username;
            _Password = password;
        }

        // Add in Dec 11, 2021
        public void EnterManager()
        {
            Console.WriteLine("Test in Manager.cs");
            throw new NotImplementedException();
        }

        static void matchUserPass(string? userName, string? password)
        {
            if(userName != null && password != null)
            {
                //if(userName.Equals(_Username) )
                //{

                //}

            }
            else
            {
                Console.WriteLine("Your username or password are empty");
            }

        }

        public void DisplayStoreOrderHistory()
        {

        }
    }
}
