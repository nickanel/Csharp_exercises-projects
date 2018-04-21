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

        private UserManager() { }




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
                                    string lastname = reader["FirstName"].ToString();
                                    string username_ = reader["FirstName"].ToString();
                                    string password_ = reader["FirstName"].ToString();
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
            currentUser = null;
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
