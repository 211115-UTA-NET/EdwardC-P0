namespace Project_0App.App
{
    public class MainProgram
    {
        public enum Mode { Login, NewCustomer, ReturnedCustomer, Manager, CustomerRequest, ManagerRequest, SetOrder, ProcessOrder, Logout, Exit}
        public static void Main(string[] args)
        {
            bool programRun = true;

            // Call individual Class to run each purpose
            Mode myMode = Mode.Login;
            Login myLogin = new Login();
            NewCustomer newCustomer = new NewCustomer();
            ReturnedCustomer returnedCustomer = new ReturnedCustomer();
            //Manager manager = new Manager();
            CustomerRequest customerRequest = new CustomerRequest();
            ManagerRequest managerRequest = new ManagerRequest();
            SetOrder setOrder = new SetOrder();
            ProcessOrder processOrder = new ProcessOrder();
            Logout processLogout = new Logout();

            while(programRun)
            {
                switch(myMode)
                {
                    case Mode.Login: 
                        Console.WriteLine("Log in"); 
                        myLogin.LoginScreen(ref myMode); 
                        break;
                    case Mode.NewCustomer: 
                        Console.WriteLine("\nNew Customer"); 
                        newCustomer.EnterNewCustomer(ref myMode); 
                        break;
                    case Mode.ReturnedCustomer: 
                        Console.WriteLine("\nReturned Customer"); 
                        returnedCustomer.EnterReturnedCustomer(ref myMode); 
                        break;
                    case Mode.Manager: 
                        Console.WriteLine("\nManager");
                        //manager.EnterManager();
                        break;
                    case Mode.CustomerRequest: 
                        Console.WriteLine("\nCumtomer Request"); 
                        customerRequest.EnterCustomerRequest(ref myMode);
                        break;
                    case Mode.ManagerRequest: 
                        Console.WriteLine("\nManager Request"); 
                        break;
                    case Mode.SetOrder: 
                        Console.WriteLine("\nSet Order"); 
                        break;
                    case Mode.ProcessOrder: 
                        Console.WriteLine("\nProcess Order"); 
                        break;
                    case Mode.Logout: 
                        Console.WriteLine("\nLog out"); 
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