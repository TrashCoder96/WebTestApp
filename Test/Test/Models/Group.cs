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
    
    public partial class Group
    {
        public Group()
        {
            this.StudentRequests = new HashSet<StudentRequest>();
            this.TestSets = new HashSet<TestSet>();
            this.aspnet_Users = new HashSet<aspnet_Users>();
        }
    
        public System.Guid GroupId { get; set; }
        public string GroupName { get; set; }
    
        public virtual ICollection<StudentRequest> StudentRequests { get; set; }
        public virtual ICollection<TestSet> TestSets { get; set; }
        public virtual ICollection<aspnet_Users> aspnet_Users { get; set; }
    }
}
