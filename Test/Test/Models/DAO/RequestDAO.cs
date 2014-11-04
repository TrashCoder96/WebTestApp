﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Test.Models
{
    public class RequestDAO
    {
        public Result ReadAllRequests(Predicate<Request> p)
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

        public Result SatisfyRequest(Predicate<Request> p)
        {
            bool Success = true;
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
            SqlCommand command = new SqlCommand();
            Int32 n = 0;
            try
            {
                connection.Open();
                command.Connection = connection;
                foreach (Request r in (List<Request>)ReadAllRequests(p).Value)
                {
                    command.Transaction = connection.BeginTransaction("Transaction");
                    try
                    {
                        command.Parameters.Add(new SqlParameter("@login", r.User.Login));
                        command.Parameters.Add(new SqlParameter("@role", r.Role));
                        command.CommandText = "DELETE FROM Request WHERE Request.RoleId = (SELECT aspnet_Roles.RoleId FROM aspnet_Roles WHERE aspnet_Roles.RoleName = @role) AND Request.UserId = (SELECT aspnet_Users.UserId FROM aspnet_Users WHERE aspnet_Users.UserName = @login)";
                        n = command.ExecuteNonQuery();
                        if (r.Role == "Admin")
                        {
                            command.CommandText = "INSERT INTO aspnet_UsersInRoles VALUES((SELECT aspnet_Users.UserId FROM aspnet_Users WHERE aspnet_Users.UserName = @login), (SELECT aspnet_Roles.RoleId FROM aspnet_Roles WHERE aspnet_Roles.RoleName = @role))";
                            command.ExecuteNonQuery();
                            
                        }
                        if (r.Role == "Student")
                        {
                            command.CommandText = "INSERT INTO aspnet_UsersInRoles VALUES((SELECT aspnet_Users.UserId FROM aspnet_Users WHERE aspnet_Users.UserName = @login), (SELECT aspnet_Roles.RoleId FROM aspnet_Roles WHERE aspnet_Roles.RoleName = @role))";
                            command.ExecuteNonQuery();
                           
                        }
                        if (r.Role == "Lector")
                        {
                            command.CommandText = "INSERT INTO aspnet_UsersInRoles VALUES((SELECT aspnet_Users.UserId FROM aspnet_Users WHERE aspnet_Users.UserName = @login), (SELECT aspnet_Roles.RoleId FROM aspnet_Roles WHERE aspnet_Roles.RoleName = @role))";
                            command.ExecuteNonQuery();
                        }
                        command.Transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        command.Transaction.Rollback("Transaction");
                        throw new Exception();
                    }
                }

            }
            catch (Exception e)
            {
                Success = false;
            }
            finally
            {
                connection.Close();
            }
            return new Result(Success, n);
        }

        public Result RejectRequest(Predicate<Request> p)
        {
            bool Success = true;
            SqlConnection connection = null;
            Int32 n = 0;
            try
            {
                connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
                connection.Open();
                foreach (Request r in (List<Request>)ReadAllRequests(p).Value)
                {
                    SqlCommand command = new SqlCommand("DELETE FROM Request WHERE Request.RoleId = (SELECT aspnet_Roles.RoleId FROM aspnet_Roles WHERE aspnet_Roles.RoleName = @role) AND Request.UserId = (SELECT aspnet_Users.UserId FROM aspnet_Users WHERE aspnet_Users.UserName = @login)", connection);
                    command.Parameters.Add(new SqlParameter("@login", r.User.Login));
                    command.Parameters.Add(new SqlParameter("@role", r.Role));
                    n = command.ExecuteNonQuery();
                }
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

        public Result CreateRequest(string Login, string Role, string Message)
        {
            bool Success = true;
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
            SqlCommand command = new SqlCommand();
            int n = 0;
            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO Request VALUES((SELECT aspnet_Users.UserId FROM aspnet_Users WHERE aspnet_Users.UserName = @u), (SELECT aspnet_Roles.RoleId FROM aspnet_Roles WHERE aspnet_Roles.RoleName = @r), @m)";
                command.Parameters.Add(new SqlParameter("@u", Login));
                command.Parameters.Add(new SqlParameter("@r", Role));
                command.Parameters.Add(new SqlParameter("@m", Message));
                n = command.ExecuteNonQuery();
            }
            catch (Exception e)
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