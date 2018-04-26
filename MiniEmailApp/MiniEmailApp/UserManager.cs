using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace MiniEmailApp
{
    class UserManager
    {
        private User currentUser;        

        private static UserManager _instance = null;
        public static UserManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserManager();
                }
                return _instance;
            }
        }

        private UserManager()
        {
            currentUser = new User();
        }
        




        public void Change_Personal_Info(User user)
        {
            string[] choices = { "1.Change First Name", "2.Change Lastname","3.Go Back" };
            
            bool correct_firstname=false, correct_lastname=false,exit=false;
            do
            {
                int choice = Aux.AuxiliaryFunction.Return_Choice(choices);
                string firstname, lastname;
                switch (choice)
                {
                    case 0:
                        do
                        {
                            Console.WriteLine("Change a new FirstName");
                            firstname = Console.ReadLine();
                            correct_firstname = Instance.ValidateRegisteringFirstname(firstname);
                        } while (!correct_firstname);
                        Update_First_Name(user, firstname,out int rows);
                        Console.WriteLine($"{rows} Firstname was succesfully updated");
                        System.Threading.Thread.Sleep(200);
                        break;
                    case 1:
                        do
                        {
                            Console.WriteLine("Change a new Lastname");
                            lastname = Console.ReadLine();
                            correct_lastname = Instance.ValidateRegisteringFirstname(lastname);
                        } while (!correct_lastname);
                        Update_Last_Name(user, lastname, out int rows_);
                        Console.WriteLine($"{rows_} Firstname was succesfully updated");
                        System.Threading.Thread.Sleep(200);
;                        break;
                    case 2:
                        exit = true;
                        break;
                }
            } while (!exit);
        }
        public void Update_First_Name(User user,string new_name,out int rows)
        {

            string databaseConnectionString = @"Data Source=KANELLOV-PC\SQLEXPRESS;Initial Catalog=Project_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string query = "UPDATE Users SET FirstName=@new_name" +
                    " WHERE UserID=@user_id";
            rows = 0;

            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("new_name", new_name));
                        command.Parameters.Add(new SqlParameter("user_id", user.Userid));
                        rows = command.ExecuteNonQuery();
                    }
                }
                catch (Exception ErrorInCommunication)
                {
                    Console.WriteLine(ErrorInCommunication.Message);

                }
                connection.Close();
            }

        }
        public void Update_Last_Name(User user, string new_name, out int rows)
        {

            string databaseConnectionString = @"Data Source=KANELLOV-PC\SQLEXPRESS;Initial Catalog=Project_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string query = "UPDATE Users SET LastName=@new_name" +
                    " WHERE UserID=@user_id";
            rows = 0;

            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("new_name", new_name));
                        command.Parameters.Add(new SqlParameter("user_id", user.Userid));
                        rows = command.ExecuteNonQuery();
                    }
                }
                catch (Exception ErrorInCommunication)
                {
                    Console.WriteLine(ErrorInCommunication.Message);

                }
                connection.Close();
            }

        }

        public void Delete_User()
        {
            Console.WriteLine("Select a user to delete :");
            ViewAllUsers(out List<string> users_usernames,out int count);
            Console.WriteLine($"{count} users will be  shown");
            Console.ReadKey();
            string[] users_usernames_array = users_usernames.ToArray();
            int choice = Aux.AuxiliaryFunction.Return_Choice(users_usernames_array);
            Console.WriteLine($"Are you sure you want to delete user{users_usernames_array[choice]}");
            Console.ReadKey();
            string[] yes_or_no = { "Yes", "No" };
            int choice2 = Aux.AuxiliaryFunction.Return_Choice(yes_or_no);
            string username = users_usernames_array[choice];
            switch (choice2)
            {
                case 0:
                    DeleteUserFromDatabase(username, out int rows);
                    Console.WriteLine($"User {users_usernames_array[choice]} wass successfully deleted");
                    Console.WriteLine($"{rows} row(s) affected in Database");
                    Console.WriteLine("You will be redirected to options menu after 2 seconds");
                    System.Threading.Thread.Sleep(2000);


                    break;
                case 1:
                    Console.WriteLine($"User {users_usernames_array[choice]} will bot be deleted");
                    Console.WriteLine("You will be redirected to options menu after 2 seconds");
                    System.Threading.Thread.Sleep(2000);
                    break;
            }



        }
        public void DeleteUserFromDatabase(string username,out int rows)
        {
            rows = 0;
            try
            {
                string databaseConnectionString = @"Data Source=KANELLOV-PC\SQLEXPRESS;Initial Catalog=Project_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                using (SqlConnection conn =
                    new SqlConnection(databaseConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd =
                        new SqlCommand("DELETE FROM Users " +
                            "WHERE UserName=@username_", conn))
                    {
                        cmd.Parameters.AddWithValue("@username_", username);

                         rows = cmd.ExecuteNonQuery();

                        //rows number of record got deleted
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }

        }

        public void ViewAllUsers(out List<string> users_usernames,out int count)
        {
            List<string> users_usernames1234= new List<string>();
            string databaseConnectionString = @"Data Source=KANELLOV-PC\SQLEXPRESS;Initial Catalog=Project_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string query = "SELECT * FROM Users " ;
             count = 0;
            
                

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
                                users_usernames1234.Add(username_);
                                count++;
                            }
                        }
                    }
                }
                catch (Exception ErrorInCommunication)
                {
                    Console.WriteLine(ErrorInCommunication.Message);

                }
                users_usernames = users_usernames1234;
                connection.Close();
            }

        }

        #region REGISTER VALIDATIONS
        public bool ValidateRegisteringFirstname(string firstname)
        {
            bool firstnameisvadid = Aux.AuxiliaryFunction.ValidateName(firstname);       

            return firstnameisvadid;
        }
        
        public bool ValidateRegisteringLastname(string lastname)
        {
            bool lastnameisvalid = Aux.AuxiliaryFunction.ValidateName(lastname);
            return lastnameisvalid;            
        }
        public bool ValidateRegisteringUsername(string username)
        {
            bool usernameisvalid = Aux.AuxiliaryFunction.ValidateName(username)&& !UserManager.Instance.UsernameExistsinDatabase(username); //UsernameExistsinDatabase(username)
            return usernameisvalid;
            
        }
        public bool ValidateRegisteringPassword(string password, out string ErrorMessage)
        {
           // bool passwordisvalid = Aux.AuxiliaryFunction.ValidatePassword(password);
            
                var input = password;
                ErrorMessage = string.Empty;

                if (string.IsNullOrWhiteSpace(input))
                {
                ErrorMessage = "Password should not be empty";
                return false;
                
                    //throw new Exception("Password should not be empty");
                }

                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasMiniMaxChars = new Regex(@".{5,12}");
                var hasLowerChar = new Regex(@"[a-z]+");
               // string legitpassword = new Regex(@"(? !^[0 - 9] *$)(?!^[a - zA - Z] *$) ^ ([a - zA - Z0 - 9]{ 8,15})");
            
                //bool istrue= hasNumbers.
                //var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

                if (!hasLowerChar.IsMatch(input))
                {
                    ErrorMessage = "Password should contain At least one lower case letter";
                    return false;
                }
                else if (!hasUpperChar.IsMatch(input))
                {
                    ErrorMessage = "Password should contain At least one upper case letter";
                    return false;
                }
            else if (!hasMiniMaxChars.IsMatch(input))
                {
                    ErrorMessage = "Password should not be less than 5 or greater than 12 characters";
                    return false;
                }
                else if (!hasNumber.IsMatch(input))
                {
                    ErrorMessage = "Password should contain At least one numeric value";
                    return false;
                }

                //else if (!hasSymbols.IsMatch(input))
                //{
                //    ErrorMessage = "Password should contain At least one special case characters";
                //    return false;
                //}
                else
                {
                    return true;
                }
            
        }
        #endregion

        #region DATABASE_OPERATIONS

        public  bool UsernameExistsinDatabase(string username)
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
                                System.Threading.Thread.Sleep(150);
                            }
                            else
                            {
                                username_exists = false;
                                Console.WriteLine("I didnt find any others username like yours");
                                System.Threading.Thread.Sleep(150);
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
        public  bool IsPasswordCorrect(string username, string password)
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
                            System.Threading.Thread.Sleep(1500);
                        }
                        else
                        {
                            IsPasswordCorrect = true;
                            Console.WriteLine("Your password is correct");
                            System.Threading.Thread.Sleep(1500);
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
        public bool RegisterUserinDatabase(string firstname, string lastname, string username, string password)
        {
            bool successfull_register = false;
            DateTime date;
            try
            {   // εισάγουμε τη database
                using (SqlConnection myconnection = new SqlConnection(@"Data Source=KANELLOV-PC\SQLEXPRESS;Initial Catalog=Project_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                {
                    // την ανοίγουμε
                    myconnection.Open();
                    // string insertCommand = "Insert Into Users(Username,Password) Values(@usrn, @paswr)"; //FistName,'@firstn',
                    string insertCommand = "Insert Into Users(FirstName,LastName,UserName,Password,UserType,CreationDate) Values(@firstn,@lastn,@usrn, @paswr,@usert,@creationd)";
                    using (SqlCommand mycommand = new SqlCommand(insertCommand, myconnection))
                    {   // παίρνει τις τιμές που έβαλε ο χρήστης και τις αναθέτει στα αντίστοιχα κομμάτια του πίνακα
                        mycommand.Parameters.Add(new SqlParameter("firstn", firstname));
                        mycommand.Parameters.Add(new SqlParameter("lastn", lastname));
                        mycommand.Parameters.Add(new SqlParameter("usrn", username));
                        mycommand.Parameters.Add(new SqlParameter("paswr", password));
                        mycommand.Parameters.Add(new SqlParameter("usert", (int)UserType.User));
                        mycommand.Parameters.Add(new SqlParameter("creationd", date = DateTime.Now));
                        int rows = mycommand.ExecuteNonQuery();//το cmd.ExecuteNonQuery() είναι για εντολές που δεν επηρεάζει το table της βάσης
                        Console.WriteLine($"{rows} rows affected");
                        successfull_register = true;
                    }
                }

            }
            catch (SqlException e)
            {

                Console.WriteLine("Exception" + e);
            }
            Console.WriteLine("User Created Successfully !");
            System.Threading.Thread.Sleep(20);
            return successfull_register;


        }
        #endregion

        public User GetCurrentUser()
        {
            return currentUser;
        }


        //public bool Login(string username, string password)
        //{
        //    using (var db = new DbContext())
        //    {
        //        currentUser = db.Users.Where(x => x.Username == username && x.Password == password).SingleOrDefault();
        //        return IsLoggedIn();
        //    }
        //}
        public bool Login(string username,string password)
        {
            bool successful_login = false;
            {
                string databaseConnectionString = @"Data Source=KANELLOV-PC\SQLEXPRESS;Initial Catalog=Project_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                string query = "SELECT * FROM Users "
                             + "WHERE UserName = @username AND Password = @password ";                

                using (SqlConnection connection = new SqlConnection(databaseConnectionString))
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.Add(new SqlParameter("username", username));
                            command.Parameters.Add(new SqlParameter("password", password));

                            
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                
                                    int usertype = (int)reader["UserType"];
                                    int userid = (int)reader["UserId"];
                                    string firstname = reader["FirstName"].ToString();
                                    string lastname = reader["LastName"].ToString();
                                    string username_ = reader["UserName"].ToString();
                                    string password_ = reader["Password"].ToString();
                                    DateTime creationdate = (DateTime)reader["CreationDate"];
                                    currentUser = new User(userid,firstname,lastname,username_,password_,(UserType)usertype,creationdate);
                                    successful_login = true;
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

            }
            return successful_login;
        }
        public bool IsLoggedIn()
        {
            if (currentUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Logout()
        {
            currentUser = new User();
        }

        //    do {
        //    //ektupose epiloges


        //    //diabase epilogi

        //    swtich(choice)
        //    {
        //        case1:return kati

        //        case 2 : retun kati allo;

        //        default break;
        //        Console.Beep();
        //        Console.Clear();
        //    }
        //    }while (true)

        //    //out public void LoginMenu(out string username ,out string password)

        ////gia na xrisimopoisw to using se antikeimeno prepei na ilopoisw to idisposable  ka tin dispose 
    }
}
