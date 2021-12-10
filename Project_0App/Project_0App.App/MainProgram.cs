namespace Project_0App.App
{
    public class MainProgram
    {
        enum Mode { Login, NewCustomer, ReturnedCustomer, Manager, CustomerRequest, ManagerRequest, SetOrder, ProcessOrder, Logout, Exit}
        public static void Main(string[] args)
        {
            bool programRun = true;
            Mode myMode = Mode.Login;
            Login myLogin = new Login();

            while(programRun)
            {
                switch(myMode)
                {
                    case Mode.Login: Console.WriteLine("Log in"); myLogin.LoginScreen(); break;
                    case Mode.NewCustomer: Console.WriteLine("New Customer"); break;
                    case Mode.ReturnedCustomer: Console.WriteLine("Returned Customer"); break;
                    case Mode.Manager: Console.WriteLine("Manager"); break;
                    case Mode.CustomerRequest: Console.WriteLine("Cumtomer Request"); break;
                    case Mode.ManagerRequest: Console.WriteLine("Manager Request"); break;
                    case Mode.SetOrder: Console.WriteLine("Set Order"); break;
                    case Mode.ProcessOrder: Console.WriteLine("Process Order"); break;
                    case Mode.Logout: Console.WriteLine("Log out"); break;
                    case Mode.Exit: Console.WriteLine("Exit"); programRun = false; break;
                }
                programRun = false;
            }
        }
    }
}