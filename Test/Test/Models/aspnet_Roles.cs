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
    
    public partial class aspnet_Roles
    {
        public aspnet_Roles()
        {
            this.Requests = new HashSet<Request>();
            this.aspnet_Users = new HashSet<aspnet_Users>();
        }
    
        public System.Guid ApplicationId { get; set; }
        public System.Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public string LoweredRoleName { get; set; }
        public string Description { get; set; }
    
        public virtual aspnet_Applications aspnet_Applications { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<aspnet_Users> aspnet_Users { get; set; }
    }
}
