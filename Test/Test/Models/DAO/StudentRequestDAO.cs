using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Security;

namespace Test.Models
{
    public class StudentRequestDAO
    {
        public Result ReadAllStudentRequests(Func<StudentRequest, bool> p, ModelContainer data)
        {
            bool Success = true;
            IEnumerable<StudentRequest> requests = null;
            try
            {
                requests = data.StudentRequests.Select(row => row).Where(p);
            }
            catch (Exception e)
            {
                Success = false;
            }

            return new Result(Success, requests);
        }

        public Result SatisfyRequest(Func<StudentRequest, bool> p, ModelContainer data)
        {
            bool Success = true;
            IEnumerable<StudentRequest> requests = null;
           // try
          //  {
                requests = data.StudentRequests.Select(row => row).Where(p);
                foreach (StudentRequest r in requests)
                {
                    //удаляем пользователя из всех групп, в которых он состоит
                    foreach (Group g in r.aspnet_Users.Groups)
                        g.aspnet_Users.Remove(r.aspnet_Users);
                    //удаляем пользовательский запрос на вступление
                    data.StudentRequests.Remove(r);
                    //добавляем пользователя в группу
                    r.Group.aspnet_Users.Add(r.aspnet_Users);
                }
                data.SaveChanges();
         //   }
         //   catch (Exception e)
         //   {
         //       Success = false;
          //  }

            return new Result(Success, requests);
        }

        public Result RejectRequest(Func<StudentRequest, bool> p, ModelContainer data)
        {
            bool Success = true;
            IEnumerable<StudentRequest> requests = null;
          //  try
          //  {
                requests = data.StudentRequests.Select(row => row).Where(p);
                foreach (StudentRequest r in requests)
                {
                    //удаляем пользовательский запрос на вступление
                    data.StudentRequests.Remove(r);
                }
                data.SaveChanges();
         //   }
          //  catch (Exception e)
          //  {
        //        Success = false;
          //  }

            return new Result(Success, requests);
        }

        public Result CreateRequest(aspnet_Users user, Group group, ModelContainer data)
        {
            bool Success = true;
            IEnumerable<StudentRequest> requests = null;
            //try
           // {
                StudentRequest request = data.StudentRequests.Create();
                request.StudentRequestId = Guid.NewGuid();
                request.aspnet_Users = user;
                request.Message = "m";
                request.Group = group;
                data.StudentRequests.Add(request);
                data.SaveChanges();
           // }
           // catch (Exception e)
           // {
                //Success = false;
           // }

            return new Result(Success, requests);
        }

    }
}