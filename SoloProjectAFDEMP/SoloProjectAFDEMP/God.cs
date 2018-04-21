using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloProjectAFDEMP
{
    public class God:SuperAdmin
    {
        public God(int userid,string firstname, string lastname, string username, string password) : base(userid,
            firstname, lastname, username, password)
        {
            this.Usertype = UserType.God;
        }
        public God(int userid, string firstname, string lastname, string username, string password, DateTime dateTime) : base(userid,
            firstname, lastname, username, password, dateTime)
        {
            this.Usertype = UserType.God;
        }
    }
}
