using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEmailApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MessageManager message_manager = new MessageManager();
            MenuManager menu_manager = new MenuManager();
            UserManager user_manager = UserManager.Instance;
            DatabaseManager database_manager = DatabaseManager.Instance;
            do
            {
                try
                {
                    MainMenuOption _mainMenuOption = menu_manager.Initial_Menu();
                    switch (_mainMenuOption)
                    {
                        case MainMenuOption.Login:
                            bool successfull_login;
                            User loggedin_user = user_manager.GetCurrentUser();

                            //create a loggedin user in order to user his properties in the next menu after successfull login
                            do
                            {
                                bool correct_username, correct_password;
                                do
                                {                                    
                                    loggedin_user.Username = menu_manager.LoginMenuUsername();
                                    correct_username = user_manager.UsernameExistsinDatabase(loggedin_user.Username);

                                } while (!correct_username);
                                do
                                {
                                    loggedin_user.Password = menu_manager.LoginMenuEnterPassword();
                                    correct_password = user_manager.IsPasswordCorrect(loggedin_user.Username, loggedin_user.Password);

                                } while (!correct_password);
                                successfull_login = user_manager.Login(loggedin_user.Username, loggedin_user.Password);//pairnei ola ta stoixeia o current user otan ginetai i epikoinwnia me ti basi
                                menu_manager.LoginWasSuccessfull(loggedin_user = user_manager.GetCurrentUser());

                            } while (!successfull_login);

                            switch (loggedin_user.Usertype)
                            {
                                case UserType.User:
                                    {
                                        UserLoginMenuOption userLoginMenuOption;
                                        do
                                        {                                            
                                            userLoginMenuOption = menu_manager.User_LoggedInMenu();
                                            switch (userLoginMenuOption)
                                            {
                                                case UserLoginMenuOption.ReadMessageBox:
                                                    List<string> messages = new List<string>();
                                                    messages = message_manager.ViewMessages(loggedin_user);
                                                    foreach(string element in messages)
                                                    {
                                                        Console.WriteLine($"{element}");
                                                    }
                                                    Console.WriteLine("Press a key to go to back");

                                                    break;
                                                case UserLoginMenuOption.SentMessage:
                                                    bool sent;
                                                    do
                                                    {
                                                        menu_manager.PickAReceiver(out string receiver_username);
                                                        menu_manager.SentMessage(receiver_username, out string message);
                                                        sent = message_manager.SentMessage(loggedin_user, message, receiver_username);
                                                        Console.WriteLine($"Sent is {sent}");
                                                        Console.ReadKey();
                                                    } while (!sent);
                                                    break;
                                                case UserLoginMenuOption.EnterChatroom:
                                                    message_manager.Chatroom(loggedin_user);
                                                    break;
                                                case UserLoginMenuOption.ChangePersonalInfo:
                                                    user_manager.Change_Personal_Info(loggedin_user);
                                                    break;
                                                case UserLoginMenuOption.Logout:
                                                    Console.Beep();
                                                    successfull_login = false;
                                                    break;
                                            }
                                            
                                        } while ( successfull_login);           
                                        
                                    }                                    
                                    break;

                                case UserType.Admin:
                                    {
                                        AdminLoginMenuOption adminLoginMenuOption;
                                        do
                                        {
                                            adminLoginMenuOption = menu_manager.Admin_LoggedInMenu();
                                            switch (adminLoginMenuOption)
                                            {
                                                case AdminLoginMenuOption.ReadMessageBox:
                                                    List<string> messages = new List<string>();
                                                    messages = message_manager.ViewMessages(loggedin_user);
                                                    foreach (string element in messages)
                                                    {
                                                        Console.WriteLine($"{element}");
                                                    }
                                                    Console.WriteLine("Press a key to go to back");

                                                    break;
                                                case AdminLoginMenuOption.SentMessage:
                                                    bool sent;
                                                    do
                                                    {
                                                        menu_manager.PickAReceiver(out string receiver_username);
                                                        menu_manager.SentMessage(receiver_username, out string message);
                                                        sent = message_manager.SentMessage(loggedin_user, message, receiver_username);
                                                        Console.WriteLine($"Sent is {sent}");
                                                        Console.ReadKey();
                                                    } while (!sent);
                                                    break;
                                                case AdminLoginMenuOption.EnterChatroom:
                                                    message_manager.Chatroom(loggedin_user);
                                                    break;
                                                case AdminLoginMenuOption.ChangePersonalInfo:
                                                    user_manager.Change_Personal_Info(loggedin_user);
                                                    break;
                                                case AdminLoginMenuOption.SelectUsertoViewhisChatHistory:
                                                    message_manager.AdminWantstoSeeYourMailBox();
                                                    break;
                                                case AdminLoginMenuOption.DeleteaUsersMessage:
                                                    message_manager.DeleteAUsersMail();
                                                    break;
                                                case AdminLoginMenuOption.Logout:
                                                    Console.Beep();
                                                    successfull_login = false;
                                                    break;
                                            }

                                        } while (successfull_login);
                                    }
                                    user_manager.Logout();
                                    break;
                                case UserType.SuperAdmin:
                                    {
                                        SuperAdmiLoginMenuOption superAdmiLoginMenuOption;
                                        do
                                        {
                                            superAdmiLoginMenuOption = menu_manager.SuperAdmin_LoggedInMenu();
                                            switch (superAdmiLoginMenuOption)
                                            {
                                                case SuperAdmiLoginMenuOption.ReadMessageBox:
                                                    List<string> messages = new List<string>();
                                                    messages = message_manager.ViewMessages(loggedin_user);
                                                    foreach (string element in messages)
                                                    {
                                                        Console.WriteLine($"{element}");
                                                    }
                                                    Console.WriteLine("Press a key to go to back");

                                                    break;
                                                case SuperAdmiLoginMenuOption.SentMessage:
                                                    bool sent;
                                                    do
                                                    {
                                                        menu_manager.PickAReceiver(out string receiver_username);
                                                        menu_manager.SentMessage(receiver_username, out string message);
                                                        sent = message_manager.SentMessage(loggedin_user, message, receiver_username);
                                                        Console.WriteLine($"Sent is {sent}");
                                                        Console.ReadKey();
                                                    } while (!sent);
                                                    break;
                                                case SuperAdmiLoginMenuOption.EnterChatroom:
                                                    message_manager.Chatroom(loggedin_user);
                                                    break;
                                                case SuperAdmiLoginMenuOption.ChangePersonalInfo:
                                                    user_manager.Change_Personal_Info(loggedin_user);
                                                    break;
                                                case SuperAdmiLoginMenuOption.AddPrivileges:
                                                    user_manager.Add_Privileges();
                                                    break;
                                                case SuperAdmiLoginMenuOption.DeleteaUsersMessage:
                                                    message_manager.DeleteAUsersMail();
                                                    break;                                                
                                                case SuperAdmiLoginMenuOption.DeleteUser:
                                                    user_manager.Delete_User();
                                                    break;
                                                case SuperAdmiLoginMenuOption.Logout:
                                                    Console.Beep();
                                                    successfull_login = false;
                                                    break;
                                            }
                                        } while (successfull_login);
                                    }
                                    user_manager.Logout();
                                    break;
                                case UserType.God:

                                    GodLoginMenuOption godLoginMenuOption ;
                                    do
                                    {
                                        godLoginMenuOption = menu_manager.God_LoggedInMenu();
                                        switch (godLoginMenuOption)
                                        {
                                            case GodLoginMenuOption.ReadMessageBox:
                                                List<string> messages = new List<string>();
                                                messages = message_manager.ViewMessages(loggedin_user);
                                                foreach (string element in messages)
                                                {
                                                    Console.WriteLine($"{element}");
                                                }
                                                Console.WriteLine("Press a key to go to back");

                                                break;
                                            case GodLoginMenuOption.SentMessage:
                                                bool sent;
                                                do
                                                {
                                                    menu_manager.PickAReceiver(out string receiver_username);
                                                    menu_manager.SentMessage(receiver_username, out string message);
                                                    sent = message_manager.SentMessage(loggedin_user, message, receiver_username);
                                                    Console.WriteLine($"Sent is {sent}");
                                                    Console.ReadKey();
                                                } while (!sent);
                                                break;
                                            case GodLoginMenuOption.EnterChatroom:
                                                message_manager.Chatroom(loggedin_user);
                                                break;
                                            case GodLoginMenuOption.ChangePersonalInfo:
                                                user_manager.Change_Personal_Info(loggedin_user);
                                                break;
                                            case GodLoginMenuOption.SelectUsertoViewhisChatHistory:
                                                message_manager.AdminWantstoSeeYourMailBox();
                                                break;
                                            case GodLoginMenuOption.DeleteaUsersMessage:
                                                message_manager.DeleteAUsersMail();
                                                break;                                            
                                            case GodLoginMenuOption.DeleteUser:
                                                user_manager.Delete_User();
                                                break;
                                            case GodLoginMenuOption.DeleteAllDatabase:
                                                database_manager.DeleteAllDatabases();
                                                break;
                                            case GodLoginMenuOption.GrantSuperAdminPriveleges:
                                                user_manager.Add_Privileges();
                                                break;
                                            case GodLoginMenuOption.DepositmillinDollars:
                                                user_manager.DepositOneMillionDollars();
                                                break;
                                            case GodLoginMenuOption.Logout:
                                                Console.Beep();
                                                successfull_login = false;
                                                break;
                                        }
                                    } while (successfull_login);
                                    user_manager.Logout();
                                    break;
                            }
                            break;


                        case MainMenuOption.Register:

                            User tempuser = user_manager.GetCurrentUser();
                            bool successfull_register;
                            do
                            {
                                bool correct_firstname, correct_lastname, correct_username, correct_password;
                                //One by one insertion +check  of first name lastname username and password 
                                do
                                {
                                    tempuser.Firstname = menu_manager.RegisterMenuEnterFirstname();
                                    correct_firstname = user_manager.ValidateRegisteringFirstname(tempuser.Firstname);

                                } while (!correct_firstname);
                                do
                                {
                                    tempuser.Lastname = menu_manager.RegisterMenuEnterLastname();
                                    correct_lastname = user_manager.ValidateRegisteringLastname(tempuser.Lastname);
                                } while (!correct_lastname);
                                do
                                {
                                    tempuser.Username = menu_manager.RegisterMenuEnterUsername();
                                    correct_username = user_manager.ValidateRegisteringUsername(tempuser.Username);
                                } while (!correct_username);
                                do
                                {
                                    tempuser.Password = menu_manager.RegisterMenuEnterPassword();
                                    correct_password = user_manager.ValidateRegisteringPassword(tempuser.Password, out string errormessage);
                                    Console.WriteLine($"{errormessage}");
                                    System.Threading.Thread.Sleep(1000);
                                } while (!correct_password);

                                successfull_register = user_manager.RegisterUserinDatabase(tempuser.Firstname, tempuser.Lastname, tempuser.Username, tempuser.Password);
                                user_manager.Logout();
                                tempuser = user_manager.GetCurrentUser();

                            } while (!successfull_register);//repeat till the whole process returns a true value of the successfull register flag
                            menu_manager.SuccessfullRegister(tempuser.Username);
                            

                            break;                        
                        case MainMenuOption.Exit:
                            Console.Clear();
                            Console.WriteLine("BYE BYE");
                            System.Threading.Thread.Sleep(2000);
                            Environment.Exit(0);
                            break;
                    }

                }


                catch (SystemException e)
                {
                    Console.WriteLine(e );
                }

            } while (true);
        }
    }
}