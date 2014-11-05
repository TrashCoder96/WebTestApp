using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Test.Models
{
    public class GroupDAO
    {
        public Result ReadAll(Predicate<Group> p)
        {
            bool Success = true;
            List<Group> groups = new List<Group>();
            SqlConnection connection = null;
            SqlDataReader reader = null;
            try
            {
                connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT GroupId, Name FROM [Group]", connection);
                command.ExecuteNonQuery();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Group group = new Group(reader[1].ToString());
                    groups.Add(group);
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
            groups = groups.FindAll(p);
            return new Result(Success, groups);
        }

        public Result CreateGroup(string Name)
        {
            bool Success = true;
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
            SqlCommand command = new SqlCommand();
            int n = 0;
            //try
            //
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO [Group] VALUES(NEWID(), @n)";
                command.Parameters.Add(new SqlParameter("@n", Name));
                n = command.ExecuteNonQuery();

           // }
           // catch (Exception e)
           // {
                Success = false;
          //  }
          //  finally
          //  {
                connection.Close();
          //  }
            return new Result(Success, n);
        }

        public Result UpdateGroup(string NewName, string OldName)
        {
            bool Success = true;
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
            SqlCommand command = new SqlCommand();
            int n = 0;
            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE [Group] SET [Group].Name = @n WHERE [Group].Name LIKE @o";
                command.Parameters.Add(new SqlParameter("@n", NewName));
                command.Parameters.Add(new SqlParameter("@o", OldName));
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

        public Result DeleteGroup(Predicate<Group> p)
        {
            bool Success = true;
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
            SqlCommand command = new SqlCommand();
            int n = 0;
            try
            {
                connection.Open();
                command.Connection = connection;
                List<Group> gt = (List<Group>)ReadAll(p).Value;
                foreach (Group g in (List<Group>)ReadAll(p).Value)
                {
                    command.CommandText = "DELETE FROM [Group] WHERE [Group].Name LIKE @n";
                    command.Parameters.Add(new SqlParameter("@n", g.Name));
                    n = command.ExecuteNonQuery();
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
    }
}