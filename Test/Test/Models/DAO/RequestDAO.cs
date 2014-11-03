using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Test.Models
{
    public class RequestDAO
    {
        public Result ReadAll()
        {
            bool Success = true;
            List<Request> requests = new List<Request>();
            SqlConnection connection = null;
            SqlDataReader reader = null;
            try
            {
                connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT aspnet_Users.UserName, aspnet_Roles.RoleName, Request.Message, aspnet_Membership.Email FROM Request, aspnet_Membership, aspnet_Roles, aspnet_Users WHERE Request.UserId = aspnet_Membership.UserId AND aspnet_Membership.UserId = aspnet_Users.UserId AND Request.RoleId = aspnet_Roles.RoleId", connection);
                command.ExecuteNonQuery();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Request request = new Request(new User("f", "l", reader[3].ToString(), reader[0].ToString()), reader[1].ToString(), reader[2].ToString());
                    requests.Add(request);
                }
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

        public Result Insert(Request request)
        {
            bool Success = true;
            SqlConnection connection = null;
            int n = 0;
            try
            {
                connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Request VALUES((SELECT aspnet_Users.UserId FROM aspnet_Users WHERE aspnet_Users.UserName = @u), (SELECT aspnet_Roles.RoleId FROM aspnet_Roles WHERE aspnet_Roles.RoleName = @r), @m)", connection);
                command.Parameters.Add(new SqlParameter("@u", request.User.Login));
                command.Parameters.Add(new SqlParameter("@r", request.Role));
                command.Parameters.Add(new SqlParameter("@m", request.Message));
                n = command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Success = false;
            }
            finally
            {
                connection.Close();
            }
            return new Result(Success, n);
        }

        public Result Delete(Request request)
        {
            bool Success = true;
            SqlConnection connection = null;
            Int32 n = 0;
            try
            {
                connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Request WHERE Request.RoleId = (SELECT aspnet_Roles.RoleId FROM aspnet_Roles WHERE aspnet_Roles.RoleName = @role) AND Request.UserId = (SELECT aspnet_Users.UserId FROM aspnet_Users WHERE aspnet_Users.UserName = @login)", connection);
                command.Parameters.Add(new SqlParameter("@login", request.User.Login));
                command.Parameters.Add(new SqlParameter("@role", request.Role));
                n = command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Success = false;
            }
            finally
            {
                connection.Close();
            }
            return new Result(Success, n);
        }

        public Result Delete(string User, string Role)
        {
            bool Success = true;
            SqlConnection connection = null;
            Int32 n = 0;
            try
            {
                connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Request WHERE Request.RoleId = (SELECT aspnet_Roles.RoleId FROM aspnet_Roles WHERE aspnet_Roles.RoleName = @role) AND Request.UserId = (SELECT aspnet_Users.UserId FROM aspnet_Users WHERE aspnet_Users.UserName = @login)", connection);
                command.Parameters.Add(new SqlParameter("@login", User));
                command.Parameters.Add(new SqlParameter("@role", Role));
                n = command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Success = false;
            }
            finally
            {
                connection.Close();
            }
            return new Result(Success, n);
        }
    }
}