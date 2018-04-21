using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloProjectAFDEMP
{
    public class Admin:User
    {
        #region CONSTRUCTORS
        public Admin()
        {

        }
        public Admin(int userid,string firstname, string lastname, string username, string password):base(userid,
            firstname,lastname,username,password)
        {
            this.Usertype = UserType.Admin;
        }
        public Admin(int userid, string firstname, string lastname, string username, string password, DateTime dateTime) : base(userid,
            firstname, lastname, username, password, dateTime)
        {
            this.Usertype = UserType.Admin;
        }
        #endregion
    }
}
