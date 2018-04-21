using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloProjectAFDEMP
{
    public class SuperAdmin:Admin
    {
         public SuperAdmin()
        {

        }
        public SuperAdmin(int userid,string firstname, string lastname, string username, string password): base(userid,
            firstname, lastname, username, password)
        {
            this.Usertype = UserType.SuperAdmin;
        }
        public SuperAdmin(int userid, string firstname, string lastname, string username, string password, DateTime dateTime) : base(userid,
            firstname, lastname, username, password, dateTime)
        {
            this.Usertype = UserType.SuperAdmin;
        }


    }
}
