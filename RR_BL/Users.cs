using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR_BL
{
    public class Users
    {
        public Users() { }
        public Users(string username)
        {
            this.uname = username;
        }
        public Users(int id, string username, string password, bool admin) : this(username)
        {
            this.ID = id;
            this.pass = password;
            this.Admin = admin;
        }
        public int ID { get; set; }
        public string uname { get; set; }
        public string pass { get; set; }
        public bool Admin { get; set; }
    }
}
