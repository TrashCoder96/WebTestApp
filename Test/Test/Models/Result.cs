using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class Result
    {
        public bool Success { get; set; }
        public object Value { get; set; }

        public Result(bool Success, object Value)
        {
            this.Success = Success;
            this.Value = Value;
        }
    }
}