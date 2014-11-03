using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class Request
    {
        public string Message { get; set; }
        public string Role { get; set; }
        public User User { get; set; }

        public Request(User User, string Role, string Message)
        {
            this.Message = Message;
            this.Role = Role;
            this.User = User;
        }
    }
}