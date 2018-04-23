using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MiniEmailApp
{
    public class MessageManager
    {
        public bool SentMessage(User loggedin_user,string message,string receiver_username)
        {
           bool successfull_sent = false;
            bool readstatus = false;
            DateTime date;
            try
            {   // εισάγουμε τη database
                using (SqlConnection myconnection = new SqlConnection(@"Data Source=KANELLOV-PC\SQLEXPRESS;Initial Catalog=Project_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                {
                    // την ανοίγουμε
                    myconnection.Open();                    
                    string insertCommand = "Insert Into Messages(Sender_Username,Receiver_Username,Message_Data,ReadStatus,DateCreated) Values(@senderusername_,@receiverusername_,@messagedata_, @readstatus_,@datecreated_)";
                    using (SqlCommand mycommand = new SqlCommand(insertCommand, myconnection))
                    {   // παίρνει τις τιμές που έβαλε ο χρήστης και τις αναθέτει στα αντίστοιχα κομμάτια του πίνακα
                        mycommand.Parameters.Add(new SqlParameter("senderusername_", loggedin_user.Username));
                        mycommand.Parameters.Add(new SqlParameter("receiverusername_", receiver_username));
                        mycommand.Parameters.Add(new SqlParameter("messagedata_", message));
                        mycommand.Parameters.Add(new SqlParameter("readstatus_", readstatus));                        
                        mycommand.Parameters.Add(new SqlParameter("datecreated_", date = DateTime.Now));
                        int rows = mycommand.ExecuteNonQuery();//το cmd.ExecuteNonQuery() είναι για εντολές που δεν επηρεάζει το table της βάσης
                        Console.WriteLine($"{rows} message(s) sent");
                        System.Threading.Thread.Sleep(1000);
                        successfull_sent = true;
                    }
                }

            }
            catch (SqlException e)
            {

                Console.WriteLine("Exception" + e);
                Console.ReadKey();
            }
            return successfull_sent;
        }
        public List<string> ViewMessages(User loggedin_user )
        {

            List<string> Messages = new List<string>();
            string databaseConnectionString = @"Data Source=KANELLOV-PC\SQLEXPRESS;Initial Catalog=Project_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string query = "SELECT (*) FROM Messages WHERE Receiver_Username=@receiver  ORDER BY DateCreated";
            
            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                try
                {
                    connection.Open();
                    

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("receiver", loggedin_user.Username));
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string message_data = reader["Message_Data"].ToString();
                                string senderusername = reader["SenderUsername"].ToString();
                                DateTime datecreated = (DateTime)reader["DateCreated"];
                                string Message = $"User {senderusername} sent {message_data} on {datecreated.ToShortDateString()}";
                                Messages.Add(Message);
                                
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

            return Messages;
        }
    }
}
