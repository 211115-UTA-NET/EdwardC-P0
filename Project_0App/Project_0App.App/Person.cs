using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_0App.App
{
    interface Person
    {
        //Properties
        public string? _Username { get; }
        public string? _Password { get; }
        public int _Id { get; }

        // Methods
        public void DisplayStoreOrderHistory();

    }
}
