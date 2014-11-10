using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Security;
using System.Data.Objects;

namespace Test.Models
{
    public class RequestDAO
    {
        public Result ReadAllRequests(Func<Request, bool> p, ModelContainer data)
        {
            bool Success = true;
            IEnumerable<Request> requests = null;
            try
            {
                requests = data.Requests.Select(row => row).Where(p);
            }
            catch (Exception e)
            {
                Success = false;
            }
           
            return new Result(Success, requests);
        }

        public Result SatisfyRequest(Func<Request, bool> p, ModelContainer data)
        {
            bool Success = true;
            IEnumerable<Request> requests = null;
            try
            {
                requests = data.Requests.Select(row => row).Where(p);
                foreach(Request r in requests)
                {
                    r.aspnet_Users.aspnet_Roles.Add(r.aspnet_Roles);
                    data.Requests.Remove(r);
                }
                data.SaveChanges();
            }
            catch (Exception e)
            {
                Success = false;
            }
            
            return new Result(Success, requests);
        }

        public Result RejectRequest(Func<Request, bool> p, ModelContainer data)
        {
            bool Success = true;
            IEnumerable<Request> requests = null;
            try
            {
                requests = data.Requests.Select(row => row).Where(p);
                foreach (Request r in requests)
                {
                    data.Requests.Remove(r);
                }
                data.SaveChanges();
            }
            catch (Exception e)
            {
                Success = false;
            }
            
            return new Result(Success, requests);
        }

        public Result CreateRequest(aspnet_Users user, string role, string Message, ModelContainer data)
        {
            bool Success = true;
            Request request = null;
            try
            {
                request = data.Requests.Add(data.Requests.Create<Request>());
                aspnet_Roles ROLE = data.aspnet_Roles.Select(row => row).First(row => row.RoleName == role);
                request.RequestId = Guid.NewGuid();
                request.aspnet_Roles = ROLE;
                request.aspnet_Users = user;
                request.Message = Message;
                data.SaveChanges();
            }
            catch (Exception e)
            {
                Success = false;
            }
            finally
            {
                
            }
            return new Result(Success, request);
        }

    }
}