using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class Group
    {
        public string Name { get; set; }
        public List<User> Students { get; set; }

        public Group(string Name)
        {
            Students = new List<User>();
            this.Name = Name;
        }
    }
}