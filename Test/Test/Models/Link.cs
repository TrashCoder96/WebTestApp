using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class Link
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Name { get; set; }
        public Link(string Action, string Controller, string Name)
        {
            this.Action = Action;
            this.Controller = Controller;
            this.Name = Name;
        }
    }
}