using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class StudentRequest
    {
        public string Message { get; set; }
        public Group Group { get; set; }
        public User User { get; set; }

        public StudentRequest(User User, Group Group, string Message)
        {
            this.Message = Message;
            this.Group = Group;
            this.User = User;
        }
    }
}