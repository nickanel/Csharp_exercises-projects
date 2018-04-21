using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data.SqlClient;


namespace SoloProjectAFDEMP
{
    public static class Menu
    {

        static List<User> users;
        static List<Admin> admins;
        static List<SuperAdmin> superadmins;
        static List<God> gods;

        public static User temp_user;
        public static Admin temp_admin;
        static SuperAdmin temp_superadmin;
        static God temp_god;
        public static void PrintProgrammHeader()
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string welcome = ("**  Bootcamp Email App** ");
            string welcome2 = ("This Application is Designed to offer basic email and/or chat capabilities ");
            string welcome3 = ("in windows console platform enviroment with user authentication intergration");
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (welcome.Length / 2)) + "}", welcome));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (welcome2.Length / 2)) + "}", welcome2));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (welcome3.Length / 2)) + "}", welcome3));
            Console.WriteLine(" \n \n \n ");


        }
        public static void PrintSignedInProgrammHeader(UserType userType, string firstname)
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string welcome = ("**  Bootcamp Email App** ");
            string welcome2 = ("This Application is Designed to offer basic email and/or chat capabilities ");
            string welcome3 = ("in windows console platform enviroment with user authentication intergration");
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (welcome.Length / 2)) + "}", welcome));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (welcome2.Length / 2)) + "}", welcome2));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (welcome3.Length / 2)) + "}", welcome3));
            Console.WriteLine(" \n \n \n ");
            Console.WriteLine(($"Welcome " + userType.ToString() +" "+ firstname).PadLeft(20, '*'));
        }

        public static void InitialMenuPrint()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string welcome = ("**  Bootcamp Email App** ");
            string welcome2 = ("This Application is Designed to offer basic email and/or chat capabilities ");
            string welcome3 = ("in windows console platform enviroment with user authentication intergration");
            string welcome4 = ("Thank you for Using our Application ! Hope you liked it !");
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (welcome.Length / 2)) + "}", welcome));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (welcome2.Length / 2)) + "}", welcome2));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (welcome3.Length / 2)) + "}", welcome3));
            Console.WriteLine(" \n \n \n ");
            Console.WriteLine("***************");
            Console.WriteLine("** MAIN MENU **");
            Console.WriteLine("***************" + "\n \n \n ");
            short curItem = 0, c;
            ConsoleKeyInfo key;
            do
            {
                // Clear the screen.  One could easily change the cursor position,
                // but that won't work out well with tabbing out menu items.
                Console.Clear();

                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (welcome.Length / 2)) + "}", welcome));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (welcome2.Length / 2)) + "}", welcome2));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (welcome3.Length / 2)) + "}", welcome3));
                Console.WriteLine(" \n \n \n ");
                Console.WriteLine("***************");
                Console.WriteLine("** MAIN MENU **");
                Console.WriteLine("***************" + "\n \n \n ");

                // Replace this with whatever you want.
                Console.WriteLine("Pick an option . . .");
                string[] menuItems = { "1.Sign in ", "2.Register", "3.Forgot my Password", "4.Exit" };

                // The loop that goes through all of the menu items.
                for (c = 0; c < menuItems.Length; c++)
                {
                    // If the current item number is our variable c, tab out this option.
                    // You could easily change it to simply change the color of the text.
                    if (curItem == c)
                    {
                        Console.Write(">>");
                        Console.WriteLine(menuItems[c]);
                    }
                    // Just write the current option out if the current item is not our variable c.
                    else
                    {
                        Console.WriteLine(menuItems[c]);
                    }
                }

                // Waits until the user presses a key, and puts it into our object key.
                Console.Write("Select your choice with the arrow keys. \n");
                key = Console.ReadKey(true);

                // Simply put, if the key the user pressed is a "DownArrow", the current item will deacrease.
                // Likewise for "UpArrow", except in the opposite direction.
                // If curItem goes below 0 or above the maximum menu item, it just loops around to the other end.
                if (key.Key.ToString() == "DownArrow")
                {
                    curItem++;
                    if (curItem > menuItems.Length - 1) curItem = 0;
                }
                else if (key.Key.ToString() == "UpArrow")
                {
                    curItem--;
                    if (curItem < 0) curItem = Convert.ToInt16(menuItems.Length - 1);
                }
                // Loop around until the user presses the enter go.
            } while (key.KeyChar != 13);
            switch (curItem)
            {
                case 0:
                    Console.Clear();
                    SigninMenu();
                    break;

                case 1:
                    Console.Clear();
                    RegisterMenuPrint();
                    break;
                case 2:
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (welcome.Length / 2)) + "}", welcome));
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (welcome2.Length / 2)) + "}", welcome2));
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (welcome3.Length / 2)) + "}", welcome3));
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (welcome4.Length / 2)) + "}", welcome4));

                    System.Threading.Thread.Sleep(1000);

                    break;



                default:
                    break;
            }


            //System.Threading.Thread.Sleep(3000);
            //Console.Clear();
            //LoginMenu.SignIn(); 

            Console.WriteLine("\n \n \n ");
            string textToEnter = "Designed & Developed By Nikolaos Kanellopoulos , version 0.01";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));

            System.Threading.Thread.Sleep(1000);
            //Console.Read();
        }

        public static void RegisterMenuPrint()
        {
            string firstname_sg;
            string lastname_sg;
            string username_sg;
            string password_sg;            


            PrintProgrammHeader();

            //Entering firstname
            Console.WriteLine("Great News , We are excited you want to join our ChatApp. \n Please " +
                "provide us  with your Firstaname from 5 up to 20 characters:");
            bool IsValidString = ValidateName(firstname_sg = Console.ReadLine());
            while (IsValidString != true)
            {
                PrintProgrammHeader();
                Console.WriteLine("Carefull there,Please provide us  with your Firstaname from 5 up to 20 characters:");
                IsValidString = ValidateName(firstname_sg = Console.ReadLine());
            }
            IsValidString = false;

            //entering lastname
            Console.WriteLine("Please provide us  with your Lastname from 5 up to 20 characters:");
            IsValidString = ValidateName(lastname_sg = Console.ReadLine());
            while (IsValidString != true)
            {
                PrintProgrammHeader();
                Console.WriteLine("Carefull there,Please provide us  with your Lastname from 5 up to 20 characters:");
                IsValidString = ValidateName(lastname_sg = Console.ReadLine());
            }
            IsValidString = false;

            //entering username
            Console.WriteLine("Now choose a Username of your desire from 5 up to 20 characters: ");
            IsValidString = ValidateName(username_sg = Console.ReadLine());            
            while ((UsernameExistsinDatabase(username_sg) == true || (IsValidString == false)))
            {
                PrintProgrammHeader();
                Console.WriteLine("Carefull there,Please provide us  with your Username from 5 up to 20 characters of your  choice :");
                IsValidString = ValidateName(username_sg = Console.ReadLine());
            }
            IsValidString = false;

            //entering  Password
            Console.WriteLine("Now choose your password with of 5 to 20 chars with at least 3 letters of your choice:");
            IsValidString = ValidatePassword(password_sg = Console.ReadLine());
            while (IsValidString != true)
            {
                PrintProgrammHeader();
                Console.WriteLine("Carefull there,Please provide us  your password with of 5 to 20 chars with at least 3 letters of your choice:");
                IsValidString = ValidatePassword(password_sg = Console.ReadLine());
            }
            IsValidString = false;

            CreateUserinDb(firstname_sg, lastname_sg, username_sg, password_sg);

            InitialMenuPrint();

        }

        public static void SigninMenu()
        {

            PrintProgrammHeader();
            string username_sn;
            string password_sn;
            Console.WriteLine("Please enter your username:");
            bool username_exists = UsernameExistsinDatabase(username_sn = Console.ReadLine());
            while (username_exists == false)
            {
                PrintProgrammHeader();
                Console.WriteLine("The username you gave doesnt exist.Please enter your username:");
                username_exists = UsernameExistsinDatabase(username_sn = Console.ReadLine());
            }
            PrintProgrammHeader();
            Console.WriteLine("Please enter your password:");
            bool password_is_correct = IsPasswordCorrect(username_sn, password_sn = Console.ReadLine());
            while (password_is_correct == false)
            {
                PrintProgrammHeader();
                Console.WriteLine("Your password is wrong.Please enter your password:");
                password_is_correct = IsPasswordCorrect(username_sn, password_sn = Console.ReadLine());
            }
            Console.WriteLine("You are now Signed in");
            int usertype=CreateUserInProgramm(username_sn);
            SignedInMenuUser(temp_user);

            //Create the item USER or ADMIN or GOD or SUPERADMIN
            //PrintSignedInProgrammHeader(temp_user.Usertype,temp_user.Firstname);




            System.Threading.Thread.Sleep(500);

            Console.ReadLine();

        }

        public static void SignedInMenuUser(User user)
        {
            PrintSignedInProgrammHeader(user.Usertype, user.Firstname);

        }
        public static bool ValidateName(string name)
        {
            bool IsValidString = false;
            if (name.Length >= 5 && name.Length <= 20)
            {
                IsValidString = true;
            }


            return IsValidString;
        }

        public static bool ValidatePassword(string password)
        {
            //Using a regular expression to check if the given string contains chars
            bool IsValidString = false;
            int LetterCounter = Regex.Matches(password, @"[a-zA-Z]").Count;
            if (password.Length >= 7 && password.Length <= 20 && LetterCounter >= 3)
            {
                IsValidString = true;
            }


            return IsValidString;
        }

        public static bool UsernameExistsinDatabase(string username)
        {
            bool username_exists = true;
            {
                string databaseConnectionString = @"Data Source=KANELLOV-PC\SQLEXPRESS;Initial Catalog=Project_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                string query = "SELECT COUNT (*) FROM Users "
                             + "WHERE UserName = @username ";
                // + "ORDER BY OrderID ";
                int counter = 0;

                using (SqlConnection connection = new SqlConnection(databaseConnectionString))
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.Add(new SqlParameter("username", username));

                            counter = (int)command.ExecuteScalar();
                            if (counter > 0)
                            {
                                Console.WriteLine("Your username exists");
                                username_exists = true;
                                System.Threading.Thread.Sleep(50);
                            }
                            else
                            {
                                username_exists = false;
                                Console.WriteLine("I didnt find any others username like yours");
                                System.Threading.Thread.Sleep(50);
                            }
                        }
                    }
                    catch (Exception ErrorInCommunication)
                    {
                        Console.WriteLine(ErrorInCommunication.Message);

                    }
                    connection.Close();
                }

            }
            return username_exists;
        }

        public static bool IsPasswordCorrect(string username, string password)
        {
            bool IsPasswordCorrect = false;
            string databaseConnectionString = @"Data Source=KANELLOV-PC\SQLEXPRESS;Initial Catalog=Project_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string query = "SELECT COUNT (*) FROM Users "
                         + "WHERE UserName = @username AND Password=@password ";
            // + "ORDER BY OrderID ";
            int counter = 0;
            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("username", username));
                        command.Parameters.Add(new SqlParameter("password", password));

                        counter = (int)command.ExecuteScalar();
                        if (counter == 0)
                        {
                            Console.WriteLine("Wrong Password");
                            IsPasswordCorrect = false;
                            System.Threading.Thread.Sleep(1000);
                        }
                        else
                        {
                            IsPasswordCorrect = true;
                            Console.WriteLine("Your password is correct");
                            System.Threading.Thread.Sleep(1000);
                        }

                    }
                }
                catch (Exception ErrorInCommunication)
                {
                    Console.WriteLine(ErrorInCommunication.Message);

                }
                connection.Close();
            }



            return IsPasswordCorrect;

        }
        public static void CreateUserinDb(string firstname, string lastname, string username, string password)
        {
            try
            {   // εισάγουμε τη database
                using (SqlConnection conn = new SqlConnection(@"Data Source=KANELLOV-PC\SQLEXPRESS;Initial Catalog=Project_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                {
                    // την ανοίγουμε
                    conn.Open();
                    // string insertCommand = "Insert Into Users(Username,Password) Values(@usrn, @paswr)"; //FistName,'@firstn',
                    string insertCommand = "Insert Into Users(FirstName,LastName,UserName,Password,UserType,CreationDate) Values(@firstn,@lastn,@usrn, @paswr,@usert,@creationd)";
                    using (SqlCommand cmd = new SqlCommand(insertCommand, conn))
                    {   // παίρνει τις τιμές που έβαλε ο χρήστης και τις αναθέτει στα αντίστοιχα κομμάτια του πίνακα
                        cmd.Parameters.Add(new SqlParameter("firstn", firstname));
                        cmd.Parameters.Add(new SqlParameter("lastn", lastname));
                        cmd.Parameters.Add(new SqlParameter("usrn", username));
                        cmd.Parameters.Add(new SqlParameter("paswr", password));
                        cmd.Parameters.Add(new SqlParameter("usert", (int)UserType.User));
                        cmd.Parameters.Add(new SqlParameter("creationd", DateTime.Now));
                        int rows = cmd.ExecuteNonQuery();//το cmd.ExecuteNonQuery() είναι για εντολές που δεν επηρεάζει το table της βάσης
                        Console.WriteLine($"{rows} rows affected");
                    }
                }

            }
            catch (SqlException e)
            {

                Console.WriteLine("Exception" + e);
            }
            Console.WriteLine("User Created Successfully !");
            System.Threading.Thread.Sleep(1000);

        }

        public static  int  CreateUserInProgramm(string username)
        {

            string databaseConnectionString = @"Data Source=KANELLOV-PC\SQLEXPRESS;Initial Catalog=Project_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string query = "SELECT * FROM Users WHERE UserName = @username";

            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("username", username));


                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                
                                int usertype = (int)reader["UserType"];
                                

                                switch (usertype)
                                {
                                    case 1:
                                        temp_user = new User((int)reader["UserID"], reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["UserName"].ToString(), reader["Password"].ToString(), (DateTime)reader["CreationDate"]);
                                        Console.WriteLine("A simple user item was created");
                                        return (int)temp_user.Usertype;
                                        
                                    case 2:
                                        temp_admin = new Admin((int)reader["UserID"], reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["UserName"].ToString(), reader["Password"].ToString(), (DateTime)reader["CreationDate"]);
                                        
                                        return (int)temp_admin.Usertype;
                                    case 3:
                                        temp_superadmin = new SuperAdmin((int)reader["UserID"], reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["UserName"].ToString(), reader["Password"].ToString(), (DateTime)reader["CreationDate"]);
                                        return (int)temp_superadmin.Usertype;
                                        
                                    case 4:
                                        temp_god = new God((int)reader["UserID"], reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["UserName"].ToString(), reader["Password"].ToString(), (DateTime)reader["CreationDate"]);
                                        return (int)temp_god.Usertype;
                                    default:
                                        break;
                                        
                                }

                            }
                        }
                    }
                }
                catch (Exception ErrorInCommunication)
                {
                    Console.WriteLine(ErrorInCommunication.Message);

                }
                connection.Close();
                return 0;
            }

        }
    }


}
