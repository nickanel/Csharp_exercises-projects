using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEmailApp
{
    public  class MenuManager
    {
        public  MainMenuOption Initial_Menu()
        {           
            Aux.AuxiliaryFunction.PrintProgrammHeader();
            do
            {
                Console.WriteLine("**Main Menu**");
                // menuItems = { "1.Log in ", "2.Register", "3.Forgot my Password", "4.Exit" };
                string[] menuItems= { "1.Log in ", "2.Register", "3.Forgot my Password", "4.Exit" };
                int option = Aux.AuxiliaryFunction.Return_Choice(menuItems);
                switch (option)
                {
                    case 0:
                        return MainMenuOption.Login;
                    case 1:
                        return MainMenuOption.Register;
                    case 2:
                        return MainMenuOption.ForgotPassword;
                    case 3:
                        Console.Beep();
                        return MainMenuOption.Exit;
                    default:
                        Console.Beep();
                        Console.Clear();
                        break;
                }
            } while (true);
        }

        public void LoginMenu(out string username, out string password)
        {
            Aux.AuxiliaryFunction.PrintProgrammHeader();
            Console.Write("Enter your username: ");
            username = Console.ReadLine();
            Console.Write("Enter your password: ");
            password = Console.ReadLine();
        }
        #region REGISTER   
        public string  RegisterMenuEnterFirstname()
        {
            Console.Clear();
            Aux.AuxiliaryFunction.PrintProgrammHeader();
            Console.WriteLine("Please enter your Firstname (5-20 characters)");
            string firstname = Console.ReadLine() ;
            return firstname  ;
        }
        public string RegisterMenuEnterLastname()
        {
            Console.Clear();
            Aux.AuxiliaryFunction.PrintProgrammHeader();
            Console.WriteLine("Please enter your Lastname(5-20 characters)");
            string lastname = Console.ReadLine(); 
            return lastname;
        }
        public string RegisterMenuEnterUsername()
        {
            Console.Clear();
            Aux.AuxiliaryFunction.PrintProgrammHeader();
            Console.WriteLine("Please enter your Username(5-20 characters)");
            string username = Console.ReadLine(); 
            return username;
        }
        public string RegisterMenuEnterPassword()
        {
            Console.Clear();
            Aux.AuxiliaryFunction.PrintProgrammHeader();
            Console.WriteLine("Please enter your Password");
            string password = Console.ReadLine(); 
            return password;
        }

        public void SuccessfullRegister(string username)
        {
            Console.WriteLine($"Registratation of user {username} was successfull ");
            System.Threading.Thread.Sleep(1500);
        }
        #endregion REGISTER


        #region LOGIN
        public string LoginMenuUsername()
        {
            Console.Clear();
            Aux.AuxiliaryFunction.PrintProgrammHeader();
            Console.WriteLine("Please enter your Username");
            string username = Console.ReadLine();
            return username;
        }
        public string LoginMenuEnterPassword()
        {
            Console.Clear();
            Aux.AuxiliaryFunction.PrintProgrammHeader();
            Console.WriteLine("Please enter your Password");
            string password = Console.ReadLine();
            return password;
        }
        public void LoginWasSuccessfull(User user)
        {
            Console.Clear();
            Aux.AuxiliaryFunction.PrintProgrammHeader();
            Console.WriteLine($"{user.Usertype.ToString()}  {user.Firstname} {user.Lastname}  has logged in  successfully");
            System.Threading.Thread.Sleep(2000);
        }
        public UserLoginMenuOption User_LoggedInMenu()
        {
            Aux.AuxiliaryFunction.PrintProgrammHeader();
            do
            {
                Console.WriteLine("****");
                // menuItems = { "1.Log in ", "2.Register", "3.Forgot my Password", "4.Exit" };
                string[] menuItems = { "1.Read Message Box ", "2.Sent new Message", "3.Enter Chatroom", "4.Change Personal Info","5.Log out" };
                int option = Aux.AuxiliaryFunction.Return_Choice(menuItems);
                switch (option)
                {
                    case 0:
                        return UserLoginMenuOption.ReadMessageBox;
                    case 1:
                        return UserLoginMenuOption.SentMessage;
                    case 2:
                        return UserLoginMenuOption.EnterChatroom;
                    case 3:
                        return UserLoginMenuOption.ChangePersonalInfo;
                    case 4 :
                        Console.Beep();                        
                        return UserLoginMenuOption.Logout;
                }
            } while (true);
        }
        public AdminLoginMenuOption Admin_LoggedInMenu()
        {
            Aux.AuxiliaryFunction.PrintProgrammHeader();
            do
            {
                Console.WriteLine("****");
                // menuItems = { "1.Log in ", "2.Register", "3.Forgot my Password", "4.Exit" };
                string[] menuItems = { "1.Read Message Box ", "2.Sent new Message", "3.Enter Chatroom", "4.Change Personal Info", "5.Select User to view his Mailbox","6.Delete User's Mailbox,","7.ResetUserPassword" ,"8.Logout"};
                int option = Aux.AuxiliaryFunction.Return_Choice(menuItems);
                switch (option)
                {
                    case 0:
                        return AdminLoginMenuOption.ReadMessageBox;
                    case 1:
                        return AdminLoginMenuOption.SentMessage;
                    case 2:
                        return AdminLoginMenuOption.EnterChatroom;
                    case 3:
                        return AdminLoginMenuOption.ChangePersonalInfo;
                    case 4:
                        return AdminLoginMenuOption.SelectUsertoViewhisChatHistory;
                    case 5:
                        return AdminLoginMenuOption.DeleteUserMailbox;
                    case 6:
                        return AdminLoginMenuOption.ResetUserPassword;
                    case 7:
                        Console.Beep();
                        return AdminLoginMenuOption.Logout; ;
                }
            } while (true);
        }

        public SuperAdmiLoginMenuOption SuperAdmin_LoggedInMenu()
        {
            Aux.AuxiliaryFunction.PrintProgrammHeader();
            do
            {
                Console.WriteLine("****");
                // menuItems = { "1.Log in ", "2.Register", "3.Forgot my Password", "4.Exit" };
                string[] menuItems = { "1.Read Message Box ", "2.Sent new Message", "3.Enter Chatroom", "4.Change Personal Info", "5.Select User to view his Mailbox", "6.Delete User's Mailbox,", "7.ResetUserPassword","9.Delete User", "10.Logout" };
                int option = Aux.AuxiliaryFunction.Return_Choice(menuItems);
                switch (option)
                {
                    case 0:
                        return SuperAdmiLoginMenuOption.ReadMessageBox;
                    case 1:
                        return SuperAdmiLoginMenuOption.SentMessage;
                    case 2:
                        return SuperAdmiLoginMenuOption.EnterChatroom;
                    case 3:
                        return SuperAdmiLoginMenuOption.ChangePersonalInfo;
                    case 4:
                        return SuperAdmiLoginMenuOption.SelectUsertoViewhisChatHistory;
                    case 5:
                        return SuperAdmiLoginMenuOption.DeleteUserMailbox;
                    case 6:
                        return SuperAdmiLoginMenuOption.ResetUserPassword;
                    case 7:
                        return SuperAdmiLoginMenuOption.DeleteUser;
                    case 8:
                        Console.Beep();
                        return SuperAdmiLoginMenuOption.Logout;
                }
            } while (true);
        }
        public GodLoginMenuOption God_LoggedInMenu()
        {
            Aux.AuxiliaryFunction.PrintProgrammHeader();
            do
            {
                Console.WriteLine("****");
                // menuItems = { "1.Log in ", "2.Register", "3.Forgot my Password", "4.Exit" };
                string[] menuItems = { "1.Read Message Box ", "2.Sent new Message", "3.Enter Chatroom", "4.Change Personal Info", "5.Select User to view his Mailbox", "6.Delete User's Mailbox,", "7.ResetUserPassword", "8.Delete User","9.Delelete All Database ","10.Grant Super Admin Privileges" ,"11.Deposit one million dollars to account","12.Logout" };
                int option = Aux.AuxiliaryFunction.Return_Choice(menuItems);
                switch (option)
                {
                    case 0:
                        return GodLoginMenuOption.ReadMessageBox;
                    case 1:
                        return GodLoginMenuOption.SentMessage;
                    case 2:
                        return GodLoginMenuOption.EnterChatroom;
                    case 3:
                        return GodLoginMenuOption.ChangePersonalInfo;
                    case 4:
                        return GodLoginMenuOption.SelectUsertoViewhisChatHistory;
                    case 5:
                        return GodLoginMenuOption.DeleteUserMailbox;
                    case 6:
                        return GodLoginMenuOption.ResetUserPassword;
                    case 7:
                        return GodLoginMenuOption.DeleteUser;
                    case 8:
                        return GodLoginMenuOption.DeleteAllDatabase;
                    case 9:
                        return GodLoginMenuOption.GrantSuperAdminPriveleges;
                    case 10:
                        return GodLoginMenuOption.DepositmillinDollars;
                    case 11:
                        Console.Beep();                        
                        return GodLoginMenuOption.Logout;
                }
            } while (true);
        }
        //public void 

        #endregion
    }
}
