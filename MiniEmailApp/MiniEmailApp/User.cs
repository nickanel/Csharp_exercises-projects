using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEmailApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   
        public class User
        {
            #region Field & Properties
            private int _userid;
            private string _firstname;
            private string _lastname;
            private string _username;
            private string _password;
            private UserType _usertype;
            private DateTime _creationtime;

            public int Userid { get => _userid; set => _userid = value; }
            public string Firstname { get => _firstname; set => _firstname = value; }
            public string Lastname { get => _lastname; set => _lastname = value; }
            public string Username { get => _username; set => _username = value; }
            public string Password { get => _password; set => _password = value; }
            public UserType Usertype { get => _usertype; set => _usertype = value; }
            public DateTime Creationtime { get => _creationtime; set => _creationtime = value; }



            #endregion

            #region CONSTRUCTORS 

            public User(int userid, string firstname, string lastname, string username, string password,UserType usertype ,DateTime dateTime)
            {
                Userid = userid;
                Firstname = firstname;
                Lastname = lastname;
                Username = username;
                Password = password;
                Usertype = usertype;
                Creationtime = dateTime;
                // int usertype = (int)Usertype;
            }
            public User(int userid, string firstname, string lastname, string username, string password)
            {
                Userid = userid;
                Firstname = firstname;
                Lastname = lastname;
                Username = username;
                Password = password;
                Usertype = UserType.User;
                Creationtime = DateTime.Now;
                // int usertype = (int)Usertype;
            }
            public User(string username, string password)
            {
                Username = username;
                Password = password;
                Usertype = UserType.User;
            }
            public User()
            {
            //Userid = 0;
            //Firstname = "";
            //Lastname = "";
            //Username = "";
            //Password = "";
            //Usertype = UserType.User;
            //Creationtime = DateTime.Now;

        }
            #endregion

        }
    
}
