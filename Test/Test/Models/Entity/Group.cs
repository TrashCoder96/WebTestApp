using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models.Entity
{
    public class Group
    {
        public string Name { get; set; }
        public List<User> students { get; set; }
        public Group(string Name)
        {
            students = new List<User>();
            this.Name = Name;
        }
    }
}