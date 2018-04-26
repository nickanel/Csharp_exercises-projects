using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MiniEmailApp
{

    public class DatabaseManager
    {
        private static DatabaseManager _instance = null;
        public static DatabaseManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DatabaseManager();
                }
                return _instance;
            }
        }

        private DatabaseManager() { }
        public void DeleteAllDatabases()
        {
            bool success=false;
            string databaseConnectionString = @"Data Source=KANELLOV-PC\SQLEXPRESS;Initial Catalog=Project_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {
                SqlConnection con = new SqlConnection(databaseConnectionString);
                con.Open();
                string sql = @"DELETE*FROM Users;";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();

                SqlConnection con2 = new SqlConnection(databaseConnectionString);
                con.Open();
                string sql2 = @"DELETE*FROM Messages;";
                SqlCommand cmd2 = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                success = true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("The entire database was deleted both Users and Messages ,Good Luck");
            Console.ReadKey();
        }

        
    }
}
