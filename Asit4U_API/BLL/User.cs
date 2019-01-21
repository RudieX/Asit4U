using Asit4U_API.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asit4U_API.BLL
{
    public class User
    {
        public int UserID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public User(int userId, string username, string password)
        {
            this.UserID = userId;
            this.Username = username;
            this.Password = password;
        }

        public User( string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
        public User()
        {

        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.UserID, this.Username, this.Password);
        }

        
    }
}