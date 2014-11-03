using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string Login { get; set; }

        public User(string FirstNAme, string LastName, string EMail, string Login)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.EMail = EMail;
            this.Login = Login;
        }
    }
}