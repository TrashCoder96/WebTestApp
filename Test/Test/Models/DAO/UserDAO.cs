using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Test.Models
{
    public class UserDAO
    {
        public Res ReadAll(Func<aspnet_Users, bool> p, ModelContainer data)
        {
            bool Success = true;
            IEnumerable<aspnet_Users> users = null;
            //try
           // {
                users = data.aspnet_Users.Select(row => row).Where(p);
          //  }
          //  catch (Exception e)
           // {
                Success = false;
           // }
           // finally
           // {
                
           // }
            return new Res(Success, users);
        }
        

       
    }
}