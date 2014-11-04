using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models.Entity
{
    public class Student
    {
        public User User { get; set; }
        public Group Group { get; set; }

     
    }
}