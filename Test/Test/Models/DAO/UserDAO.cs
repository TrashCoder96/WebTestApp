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
        public Result ReadAll()
        {
            bool success = true;
            List<User> users = new List<User>();
            SqlConnection connection = null;
            SqlDataReader reader = null;
            try
            {
                connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT EMail, UserName FROM aspnet_Users, aspnet_Membership WHERE aspnet_Users.UserId = aspnet_Membership.UserId", connection);
                command.ExecuteNonQuery();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User("fname", "lname", reader[0].ToString(), reader[1].ToString());
                    users.Add(user);
                }
            }
            catch (SqlException e)
            {
                success = false;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                connection.Close();
            }
            return new Result(success, users);
        }
    }
}