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
        public Result ReadAllStudentRequests(Predicate<StudentRequest> p)
        {
            bool Success = true;
            List<StudentRequest> studentrequests = new List<StudentRequest>();
            SqlConnection connection = null;
            SqlDataReader reader = null;


            connection.Open();
            UserDAO userdao = new UserDAO();
            GroupDAO groupdao = new GroupDAO();
            Result result1 = userdao.ReadAll(x => (true));
            Result result2 = groupdao.ReadAll(x => (true));

            if (result1.Success)
            {
                List<User> users = (List<User>)result1.Value;
                List<Group> groups = (List<Group>)result2.Value;
                SqlCommand command = new SqlCommand("SELECT aspnet_Users.LoweredUserName, StudentRequest.GroupId, StudentRequest.Message FROM StudentRequest, aspnet_Membership, aspnet_Users WHERE StudentRequest.UserId = aspnet_Membership.UserId AND aspnet_Membership.UserId = aspnet_Users.UserId", connection);
                command.ExecuteNonQuery();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User user = users.Find(x => (x.Login.ToString().ToLower() == reader[0].ToString().ToLower()));
                    Group group = groups.Find(x => (x.Name == ))
                    StudentRequest studentrequest = new StudentRequest(user, null, reader[2].ToString());
                    studentrequests.Add(studentrequest);
                }
                studentrequests = studentrequests.FindAll(p);






            try
            {
                connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT aspnet_Users.UserName, StudentRequest.GroupId, StudentRequest.Message FROM StudentRequest, aspnet_Membership, aspnet_Users WHERE StudentRequest.UserId = aspnet_Membership.UserId AND aspnet_Membership.UserId = aspnet_Users.UserId", connection);
                command.ExecuteNonQuery();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    StudentRequest request = new StudentRequest(new User("f", "l", "f", "df"), new Group("daf"), "sf");
                    requests.Add(request);
                }
                requests = requests.FindAll(p);
            }
            catch (SqlException e)
            {
                Success = false;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                connection.Close();
            }
            return new Result(Success, requests);
        }

        //public Result SatisfyRequest(Predicate<Request> p)
        //{
        //    bool Success = true;
        //    SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
        //    SqlCommand command = new SqlCommand();
        //    Int32 n = 0;
        //    try
        //    {
        //        connection.Open();
        //        command.Connection = connection;
        //        RequestDAO requestdao = new RequestDAO();
        //        foreach (Request r in (List<Request>)requestdao.ReadAllRequests(p).Value)
        //        {
        //            command.Transaction = connection.BeginTransaction("Transaction");
        //            try
        //            {
        //                command.Parameters.Add(new SqlParameter("@login", r.User.Login.ToLower()) { SqlDbType = System.Data.SqlDbType.NVarChar });
        //                command.Parameters.Add(new SqlParameter("@role", r.Role.ToLower()) { SqlDbType = System.Data.SqlDbType.NVarChar });
        //                command.CommandText = "DELETE FROM Request WHERE Request.RoleId = (SELECT aspnet_Roles.RoleId FROM aspnet_Roles WHERE aspnet_Roles.RoleName LIKE @role) AND Request.UserId = (SELECT aspnet_Users.UserId FROM aspnet_Users WHERE aspnet_Users.LoweredUserName LIKE @login)";
        //                n = command.ExecuteNonQuery();
        //                if (r.Role == "Admin")
        //                {
        //                    command.CommandText = "INSERT INTO aspnet_UsersInRoles VALUES((SELECT aspnet_Users.UserId FROM aspnet_Users WHERE aspnet_Users.LoweredUserName LIKE @login), (SELECT aspnet_Roles.RoleId FROM aspnet_Roles WHERE aspnet_Roles.RoleName LIKE @role))";
        //                    command.ExecuteNonQuery();

        //                }
        //                if (r.Role == "Student")
        //                {
        //                    command.CommandText = "INSERT INTO aspnet_UsersInRoles VALUES((SELECT aspnet_Users.UserId FROM aspnet_Users WHERE aspnet_Users.LoweredUserName LIKE @login), (SELECT aspnet_Roles.RoleId FROM aspnet_Roles WHERE aspnet_Roles.RoleName LIKE @role))";
        //                    command.ExecuteNonQuery();

        //                }
        //                if (r.Role == "Lector")
        //                {
        //                    command.CommandText = "INSERT INTO aspnet_UsersInRoles VALUES((SELECT aspnet_Users.UserId FROM aspnet_Users WHERE aspnet_Users.LoweredUserName LIKE @login), (SELECT aspnet_Roles.RoleId FROM aspnet_Roles WHERE aspnet_Roles.RoleName LIKE @role))";
        //                    command.ExecuteNonQuery();
        //                }
        //                if (n == 0) throw new Exception();
        //                command.Transaction.Commit();
        //            }
        //            catch (Exception e)
        //            {
        //                command.Transaction.Rollback("Transaction");
        //                throw new Exception();
        //            }
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        Success = false;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //    return new Result(Success, n);
        //}

        //public Result RejectRequest(Predicate<Request> p)
        //{
        //    bool Success = true;
        //    SqlConnection connection = null;
        //    Int32 n = 0;
        //    try
        //    {
        //        connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
        //        connection.Open();

        //        foreach (Request r in (List<Request>)ReadAllRequests(p).Value)
        //        {
        //            SqlCommand command = new SqlCommand("DELETE FROM Request WHERE Request.RoleId = (SELECT aspnet_Roles.RoleId FROM aspnet_Roles WHERE aspnet_Roles.RoleName LIKE @role) AND Request.UserId = (SELECT aspnet_Users.UserId FROM aspnet_Users WHERE aspnet_Users.UserName LIKE @login)", connection);
        //            command.Parameters.Add(new SqlParameter("@login", r.User.Login) { SqlDbType = System.Data.SqlDbType.NVarChar });
        //            command.Parameters.Add(new SqlParameter("@role", r.Role) { SqlDbType = System.Data.SqlDbType.NVarChar });
        //            n = command.ExecuteNonQuery();
        //            if (n == 0) throw new Exception();
        //        }
        //    }
        //    catch (SqlException e)
        //    {
        //        Success = false;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //    return new Result(Success, n);
        //}

        //public Result CreateRequest(string Login, string Role, string Message)
        //{
        //    bool Success = true;
        //    SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
        //    SqlCommand command = new SqlCommand();
        //    int n = 0;
        //    try
        //    {
        //        connection.Open();
        //        command.Connection = connection;
        //        command.CommandText = "IF NOT (SELECT aspnet_Users.UserId FROM aspnet_Users WHERE aspnet_Users.LoweredUserName LIKE @u) IN (SELECT aspnet_UsersInRoles.UserId FROM aspnet_UsersInRoles WHERE aspnet_UsersInRoles.RoleId LIKE @r) BEGIN INSERT INTO Request VALUES((SELECT aspnet_Users.UserId FROM aspnet_Users WHERE aspnet_Users.LoweredUserName LIKE @u), (SELECT aspnet_Roles.RoleId FROM aspnet_Roles WHERE aspnet_Roles.RoleName LIKE @r), @m) END";
        //        command.Parameters.Add(new SqlParameter("@u", Login.ToLower()) { SqlDbType = System.Data.SqlDbType.NVarChar });
        //        command.Parameters.Add(new SqlParameter("@r", Role) { SqlDbType = System.Data.SqlDbType.NVarChar });
        //        command.Parameters.Add(new SqlParameter("@m", Message) { SqlDbType = System.Data.SqlDbType.NChar });
        //        n = command.ExecuteNonQuery();
        //        if (n == 0) throw new Exception();
        //    }
        //    catch (Exception e)
        //    {
        //        Success = false;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //    return new Result(Success, n);
        //}

    }
}