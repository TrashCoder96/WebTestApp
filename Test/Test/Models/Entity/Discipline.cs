using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class Discipline
    {
        public string Name { get; set; }
        public User Lector { get; set; }

        public Discipline(string Name, User Lector)
        {
            this.Lector = Lector;
            this.Name = Name;
        }
    }
}