//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Discipline
    {
        public Discipline()
        {
            this.TestSets = new HashSet<TestSet>();
        }
    
        public System.Guid DisciplineId { get; set; }
        public string DisciplineName { get; set; }
    
        public virtual aspnet_Users aspnet_Users { get; set; }
        public virtual ICollection<TestSet> TestSets { get; set; }
    }
}
