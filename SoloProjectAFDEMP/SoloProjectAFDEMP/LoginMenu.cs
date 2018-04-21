using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SoloProjectAFDEMP
{
    class LoginMenu
    {
        public static void  SignIn()
        {

            //ζητάμε τις μεταβλητές από το χρήστη !! προσοχή στους τύπους! string int, decimal, καλό θα είναι να είναι αντίστοιχα με τη βάση μας
            Console.WriteLine("Give me a username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Give me a password: ");
            int password = int.Parse(Console.ReadLine());


            try
            {   // εισάγουμε τη database
                using (SqlConnection conn = new SqlConnection(@"Data Source=KANELLOV-PC\SQLEXPRESS;Initial Catalog=Project_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                {
                    // την ανοίγουμε
                    conn.Open();
                    string insertCommand = "Insert Into Users(Username,Password) Values(@usrn, @paswr)";
                    using (SqlCommand cmd = new SqlCommand(insertCommand, conn))
                    {   // παίρνει τις τιμές που έβαλε ο χρήστης και τις αναθέτει στα αντίστοιχα κομμάτια του πίνακα
                        cmd.Parameters.Add(new SqlParameter("usrn", username));
                        cmd.Parameters.Add(new SqlParameter("paswr", password));
                        int rows = cmd.ExecuteNonQuery();//το cmd.ExecuteNonQuery() είναι για εντολές που δεν επηρεάζει το table της βάσης
                        Console.WriteLine($"{rows} rows affected");
                    }
                }

            }
            catch (SqlException e)
            {

                Console.WriteLine( e);
            }
            Console.ReadKey();

        }
    }
}
