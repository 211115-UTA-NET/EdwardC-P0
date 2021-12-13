using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_0App.App
{
    public class ReturnedCustomer : Person
    {
        public string? _Username { get; set; }
        public string? _Password { get; set; }
        public int _ID { get; set; }



        // Add Method in Dec 11, 2021
        public void EnterReturnedCustomer()
        {
            Console.WriteLine("Test in ReturnedCustomer.cs");
            throw new NotImplementedException();
        }

        public void DisplayStoreOrderHistory()
        {

        }
    }
}
