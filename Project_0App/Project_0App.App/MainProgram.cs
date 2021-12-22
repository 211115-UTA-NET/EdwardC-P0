namespace Project_0App.App
{
    public class MainProgram
    {
        public enum Mode { Login, NewCustomer, CustomerRequest, ManagerRequest, SetOrder, Logout, Exit}
        public static void Main(string[] args)
        {
            bool programRun = true;
            int CustomerId = 0;
            int StoreId = 0;

            
            Mode myMode = Mode.Login;
            
            // Call individual Class to run each purpose
            Login myLogin = new Login();
            NewCustomer newCustomer = new NewCustomer();
            CustomerRequest customerRequest = new CustomerRequest();
            ManagerRequest managerRequest = new ManagerRequest();
            SetOrder setOrder = new SetOrder();
            Logout processLogout = new Logout();

            while(programRun)
            {
                switch(myMode)
                {
                    case Mode.Login:
                        CustomerId = 0;
                        StoreId = 0;
                        Console.WriteLine("Log in"); 
                        myLogin.LoginScreen(ref myMode, ref CustomerId); 
                        break;
                    case Mode.NewCustomer: 
                        Console.WriteLine("\nNew Customer"); 
                        newCustomer.EnterNewCustomer(ref myMode, ref CustomerId); 
                        break;
                    case Mode.CustomerRequest: 
                        Console.WriteLine("\nCumtomer Request"); 
                        customerRequest.EnterCustomerRequest(ref myMode, CustomerId, ref StoreId);
                        break;
                    case Mode.ManagerRequest: 
                        Console.WriteLine("\nManager Request");
                        managerRequest.EnterRequest(ref myMode);
                        break;
                    case Mode.SetOrder: 
                        Console.WriteLine("\nSet Order");
                        setOrder.StartOrding(ref myMode, CustomerId, StoreId);
                        break;
                    case Mode.Logout: 
                        Console.WriteLine("\nLog out");
                        processLogout.SignoutOrOrderMore(ref myMode);
                        break;
                    case Mode.Exit: 
                        Console.WriteLine("\nExit"); 
                        programRun = false; 
                        break;
                }
            }
        }
    }
}

