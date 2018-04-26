using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MiniEmailApp
{
    public class MenuManager
    {
        public MainMenuOption Initial_Menu()
        {
            Aux.AuxiliaryFunction.PrintProgrammHeader();
            do
            {
                Console.WriteLine("**Main Menu**");
                // menuItems = { "1.Log in ", "2.Register", "3.Forgot my Password", "4.Exit" };
                string[] menuItems = { "1.Log in ", "2.Register", "3.Exit" };
                int option = Aux.AuxiliaryFunction.Return_Choice(menuItems);
                switch (option)
                {
                    case 0:
                        return MainMenuOption.Login;
                    case 1:
                        return MainMenuOption.Register;                   
                    case 2:
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
        public string RegisterMenuEnterFirstname()
        {
            Console.Clear();
            Aux.AuxiliaryFunction.PrintProgrammHeader();
            Console.WriteLine("Please enter your Firstname (5-20 characters)");
            string firstname = Console.ReadLine();
            return firstname;
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


        #region LOGGEDIN_CHOICES_BY_USER_TYPE
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
                string[] menuItems = { "1.Read Message Box ", "2.Sent new Message", "3.Enter Chatroom", "4.Change Personal Info", "5.Log out" };
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
                    case 4:
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
                string[] menuItems = { "1.Read Message Box ", "2.Sent new Message", "3.Enter Chatroom", "4.Change Personal Info", "5.Select User to view his Mailbox", "6.Delete User's Mail,",  "7.Logout" };
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
                        return AdminLoginMenuOption.DeleteaUsersMessage;                    
                    case 6:
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
                string[] menuItems = { "1.Read Message Box ", "2.Sent new Message", "3.Enter Chatroom", "4.Change Personal Info", "5.Select User to view his Mailbox", "6.Delete User's Mail,", "7.Delete User", "8.Logout" };
                
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
                        return SuperAdmiLoginMenuOption.DeleteaUsersMessage;
                    
                    case 6:
                        return SuperAdmiLoginMenuOption.DeleteUser;
                    case 7:
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
                string[] menuItems = { "1.Read Message Box ", "2.Sent new Message", "3.Enter Chatroom", "4.Change Personal Info", "5.Select User to view his Mailbox", "6.Delete User's Mail,",  "7.Delete User", "8.Delelete All Database ", "9.Grant Super Admin Privileges", "10.Deposit one million dollars to account", "11.Logout" };
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
                        return GodLoginMenuOption.DeleteaUsersMessage;                    
                    case 6:
                        return GodLoginMenuOption.DeleteUser;
                    case 7:
                        return GodLoginMenuOption.DeleteAllDatabase;
                    case 8:
                        return GodLoginMenuOption.GrantSuperAdminPriveleges;
                    case 9:
                        return GodLoginMenuOption.DepositmillinDollars;
                    case 10:
                        Console.Beep();
                        return GodLoginMenuOption.Logout;
                }
            } while (true);
        }



        #endregion

        public void PickAReceiver(out string receiver_username)
        {
            Console.Clear();
            Aux.AuxiliaryFunction.PrintProgrammHeader();
            Console.WriteLine("Pick the user you want to sent a message to ");
            List<string> username_list = new List<string>();
            string[] username_array;

            string databaseConnectionString = @"Data Source=KANELLOV-PC\SQLEXPRESS;Initial Catalog=Project_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string query = "SELECT Username FROM Users  ORDER BY UserName";
            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string username_ = reader["UserName"].ToString();
                                username_list.Add(username_);
                            }

                        }
                    }
                }
                catch (Exception ErrorInCommunication)
                {
                    Console.WriteLine(ErrorInCommunication.Message);
                }
                connection.Close();
            }
            int choice = Aux.AuxiliaryFunction.Return_Choice(username_array = username_list.ToArray());
            receiver_username = username_array[choice];
        }

        public void SentMessage(string receiver_username,out string message)
        {
            Console.Clear();
            Aux.AuxiliaryFunction.PrintProgrammHeader();
            Console.WriteLine($"You Selected user {receiver_username} to sent a message to");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("Now write your message ");
            message = Console.ReadLine();
            if (message.Length > 250)
            {
                Console.WriteLine("Message over 250 chars please write a smaller message");
                message = Console.ReadLine();
            }


        }
    }
}