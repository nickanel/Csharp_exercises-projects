using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEmailApp
{
    class Program
    {
        static void Main(string[] args)
        {
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
                                successfull_login = user_manager.Login(loggedin_user.Username, loggedin_user.Password);
                                menu_manager.LoginWasSuccessfull(loggedin_user=user_manager.GetCurrentUser());                                

                            } while (!successfull_login);

                            switch (loggedin_user.Usertype)
                            {
                                case UserType.User:
                                    {

                                        UserLoginMenuOption userLoginMenuOption = menu_manager.User_LoggedInMenu();
                                        do
                                        {
                                            switch (userLoginMenuOption)
                                            {
                                                case UserLoginMenuOption.ReadMessageBox:
                                                    break;
                                                case UserLoginMenuOption.SentMessage:
                                                    break;
                                                case UserLoginMenuOption.EnterChatroom:
                                                    break;
                                                case UserLoginMenuOption.ChangePersonalInfo:
                                                    break;
                                                case UserLoginMenuOption.Logout:
                                                    break;
                                            }
                                        } while (userLoginMenuOption != UserLoginMenuOption.Logout) ;                                        
                                    }

                                    break;
                                             
                               case UserType.Admin:
                                    {
                                        AdminLoginMenuOption adminLoginMenuOption = menu_manager.Admin_LoggedInMenu();
                                        do
                                        {
                                            switch (adminLoginMenuOption)
                                            {
                                                case AdminLoginMenuOption.ReadMessageBox:
                                                    break;
                                                case AdminLoginMenuOption.SentMessage:
                                                    break;
                                                case AdminLoginMenuOption.EnterChatroom:
                                                    break;
                                                case AdminLoginMenuOption.ChangePersonalInfo:
                                                    break;
                                                case AdminLoginMenuOption.SelectUsertoViewhisChatHistory:
                                                    break;
                                                case AdminLoginMenuOption.DeleteUserMailbox:
                                                    break;
                                                case AdminLoginMenuOption.ResetUserPassword:
                                                    break;
                                                case AdminLoginMenuOption.Logout:
                                                    break;
                                            }
                                            
                                        } while (adminLoginMenuOption != AdminLoginMenuOption.Logout);
                                    }
                                    break;
                                case UserType.SuperAdmin:
                                    break;
                                case UserType.God:
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

                            } while (!successfull_register);//repeat till the whole process returns a true value of the successfull register flag
                            menu_manager.SuccessfullRegister(tempuser.Username);
                            tempuser = null;

                            break;
                        case MainMenuOption.ForgotPassword:
                            break;
                        case MainMenuOption.Exit:
                            Console.WriteLine(@"");
                            System.Threading.Thread.Sleep(3000);
                            Environment.Exit(0);
                            break;
                    }

                }
                catch (SystemException e)
                {

                }

            } while (true);

        }

    }
}