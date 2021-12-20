namespace Project_0App.App
{
    public class MainProgram
    {
        public enum Mode { Login, NewCustomer, ReturnedCustomer, Manager, CustomerRequest, ManagerRequest, SetOrder, ProcessOrder, Logout, Exit}
        public static void Main(string[] args)
        {
            bool programRun = true;
            int CustomerId = 0;
            int StoreId = 0;

            
            Mode myMode = Mode.Login;
            
            // Call individual Class to run each purpose
            Login myLogin = new Login();
            NewCustomer newCustomer = new NewCustomer();
            //ReturnedCustomer returnedCustomer = new ReturnedCustomer();
            //Manager manager = new Manager();
            CustomerRequest customerRequest = new CustomerRequest();
            ManagerRequest managerRequest = new ManagerRequest();
            SetOrder setOrder = new SetOrder();
            //ProcessOrder processOrder = new ProcessOrder();
            Logout processLogout = new Logout();

            while(programRun)
            {
                switch(myMode)
                {
                    case Mode.Login: 
                        Console.WriteLine("Log in"); 
                        myLogin.LoginScreen(ref myMode, ref CustomerId); 
                        break;
                    case Mode.NewCustomer: 
                        Console.WriteLine("\nNew Customer"); 
                        newCustomer.EnterNewCustomer(ref myMode, ref CustomerId); 
                        break;
                    //case Mode.ReturnedCustomer: 
                    //    Console.WriteLine("\nReturned Customer"); 
                    //    returnedCustomer.EnterReturnedCustomer(ref myMode); 
                    //    break;
                    //case Mode.Manager: 
                    //    Console.WriteLine("\nManager");
                    //    //manager.EnterManager();
                    //    break;
                    case Mode.CustomerRequest: 
                        Console.WriteLine("\nCumtomer Request"); 
                        customerRequest.EnterCustomerRequest(ref myMode, CustomerId, ref StoreId);
                        break;
                    case Mode.ManagerRequest: 
                        Console.WriteLine("\nManager Request"); 
                        break;
                    case Mode.SetOrder: 
                        Console.WriteLine("\nSet Order");
                        setOrder.StartOrding(ref myMode, CustomerId, StoreId);
                        break;
                    //case Mode.ProcessOrder: 
                    //    Console.WriteLine("\nProcess Order"); 
                    //    break;
                    case Mode.Logout: 
                        Console.WriteLine("\nLog out");
                        processLogout.SignoutOrOrderMore(ref myMode);
                        break;
                    case Mode.Exit: 
                        Console.WriteLine("\nExit"); 
                        programRun = false; 
                        break;
                }
                //programRun = false;
            }
        }
    }
}