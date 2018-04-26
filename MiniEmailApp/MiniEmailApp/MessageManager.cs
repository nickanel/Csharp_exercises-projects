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
        public bool SentMessage(User loggedin_user, string message, string receiver_username)
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
        public List<string> ViewMessages(User loggedin_user)
        {
            Console.Clear();
            List<string> Messages = new List<string>();
            string databaseConnectionString = @"Data Source=KANELLOV-PC\SQLEXPRESS;Initial Catalog=Project_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string query = "SELECT * FROM Messages WHERE Receiver_Username=@receiver  ORDER BY DateCreated";

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
                                string senderusername = reader["Sender_Username"].ToString();
                                DateTime datecreated = (DateTime)reader["DateCreated"];
                                string Message = $"User {senderusername} sent {message_data} on {datecreated.ToShortDateString()}";
                                Console.WriteLine($"{Message}");
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
            Console.ReadKey();
            return Messages;
        }
        public void Chatroom(User loggedin_user)
        {           
            
            do {
                
                
                Console.Clear();
                Console.WriteLine("THE CHATROOM");
                ViewChatRoom(out List<string> Chat_Messages);
                //Console.WriteLine("Do you want to send a message to the Chatroom");
                //string[] choices = { "Yes", "No go Back" };
                //choice = Aux.AuxiliaryFunction.Return_Choice_for_Chat(choices);
                //if (choice == 0)
                //{
                    Console.WriteLine("Write your Message:");
                
                    string message = Console.ReadLine();
                    SendaChatMessage(loggedin_user, message);
                ViewChatRoom(out List<string> Chat_Messages2);
                 
                //}
                //Console.Clear();
            } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);

        }
        public bool SendaChatMessage (User loggedin_user, string message)
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
                        mycommand.Parameters.Add(new SqlParameter("receiverusername_", "chatroom"));
                        mycommand.Parameters.Add(new SqlParameter("messagedata_", message));
                        mycommand.Parameters.Add(new SqlParameter("readstatus_", readstatus));
                        mycommand.Parameters.Add(new SqlParameter("datecreated_", date = DateTime.Now));
                        int rows = mycommand.ExecuteNonQuery();//το cmd.ExecuteNonQuery() είναι για εντολές που δεν επηρεάζει το table της βάσης
                        
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
        public void ViewChatRoom(out List<string>Chat_Messages)
        {
            
            List<string> Messages = new List<string>();
            string databaseConnectionString = @"Data Source=KANELLOV-PC\SQLEXPRESS;Initial Catalog=Project_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string query = "SELECT * FROM Messages WHERE Receiver_Username=@receiver  ORDER BY DateCreated";

            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                try
                {
                    connection.Open();


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("receiver", "chatroom"));
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string message_data = reader["Message_Data"].ToString();
                                string senderusername = reader["Sender_Username"].ToString();
                                DateTime datecreated = (DateTime)reader["DateCreated"];
                                string Message = $"User {senderusername} wrote : {message_data} on {datecreated.ToShortDateString()}".PadLeft(300);
                                Console.WriteLine($"{Message}");
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
            Console.ReadKey();
            Chat_Messages = Messages;
        }

        public void DeleteAUsersMail()
        {
            Console.Clear();
            Pick_A_User(out string choosen_username, out int choosen_user_curent_authority);
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("You will know view the users mailbox and will have to pick mail to delete");
            System.Threading.Thread.Sleep(2000);
            List<Message> users_messages=ViewaUsersMailbox( choosen_username);
            List<int> messageidlist = new List<int>(200);
            List<string> sender = new List<string>(200);
            List<string> messagedata = new List<string>(200);
            List<string>complete_message= new List<string>(200);
            foreach (Message element in users_messages)
            {
                messageidlist.Add(element.MessageID);
                sender.Add(element.Sender_Username);
                messagedata.Add(element.Message_Data);
                string message = $"{element.MessageID}||{element.Sender_Username} wrote : {element.Message_Data} ";
                complete_message.Add(message);
            }
            int choice = Aux.AuxiliaryFunction.Return_Choice(complete_message.ToArray());
            Console.Clear();
            Console.WriteLine($"You decided to delete message {complete_message[choice]}");
            System.Threading.Thread.Sleep(3000);
            DeletemailbyID(messageidlist[choice]);

        }
        public void DeletemailbyID(int message_id)
        {
            try
            {
                string connectionString = @"Data Source=KANELLOV-PC\SQLEXPRESS;Initial Catalog=Project_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd =new SqlCommand("DELETE FROM Messages " +
                            "WHERE MessageID=@message_id", conn))
                    {
                        cmd.Parameters.AddWithValue("@message_id", message_id);

                        int rows = cmd.ExecuteNonQuery();

                        //rows number of record got deleted
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine("The message was deleted successfully");
            Console.ReadKey();
        }
    
        public void Pick_A_User(out string choosen_username, out int choosen_user_curent_authority)
        {

            Console.Clear();
            Aux.AuxiliaryFunction.PrintProgrammHeader();
            Console.WriteLine("Pick the user you want to view his message box ");
            List<string> username_list = new List<string>();
            List<int> authority_list = new List<int>(100);
            string[] username_array;


            string databaseConnectionString = @"Data Source=KANELLOV-PC\SQLEXPRESS;Initial Catalog=Project_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string query = "SELECT Username,UserType FROM Users  ORDER BY UserName";
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
                                int authority = (int)reader["UserType"];
                                authority_list.Add(authority);
                            }

                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                connection.Close();
            }
            int choice = Aux.AuxiliaryFunction.Return_Choice(username_array = username_list.ToArray());
            choosen_username = username_array[choice];
            choosen_user_curent_authority = authority_list[choice];

        }
        public List<Message> ViewaUsersMailbox(string selected_username)
        {
            Console.Clear();
            List<string> Messages = new List<string>();
            List<Message> Messages_List = new List<Message>();
            string databaseConnectionString = @"Data Source=KANELLOV-PC\SQLEXPRESS;Initial Catalog=Project_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string query = "SELECT * FROM Messages WHERE Receiver_Username=@receiver  ORDER BY DateCreated";

            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                try
                {
                    connection.Open();


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("receiver", selected_username));
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                bool isread=(bool)reader["ReadStatus"]; 
                                int message_id = (int)reader["MessageID"];
                                string message_data = reader["Message_Data"].ToString();
                                string senderusername = reader["Sender_Username"].ToString();
                                string receiversusername = reader["Receiver_Username"].ToString();
                                DateTime datecreated = (DateTime)reader["DateCreated"];
                                string Message = $"User {senderusername} sent {message_data} on {datecreated.ToShortDateString()}";
                                Console.WriteLine($"{Message}");
                                Messages.Add(Message);
                                Messages_List.Add(new Message(message_id, senderusername, receiversusername, message_data, isread, datecreated));

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
            Console.ReadKey();
            return Messages_List;
        }

        public void AdminWantstoSeeYourMailBox()
        {
            Pick_A_User(out string choosen_username, out int choosen_user_curent_authority);
             ViewaUsersMailbox(choosen_username);
            Console.ReadKey();
        }
    }    
}
