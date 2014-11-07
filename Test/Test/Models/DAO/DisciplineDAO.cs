using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Security;

namespace Test.Models
{
    public class DisciplineDAO
    {
        //методы, выполняющиеся отдельно
        public Result ReadAllDisciplines(Predicate<Discipline> p)
        {
            bool Success = true;
            List<Discipline> disciplines = new List<Discipline>();
            SqlConnection connection = null;
            SqlDataReader reader = null;
            UserDAO userdao = new UserDAO();
            try
            {
                connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
                connection.Open();
                string[] LectorNames = Roles.GetUsersInRole("Lector");
                Result result = userdao.ReadAll(x => (LectorNames.Contains(x.Login)));
                if (result.Success)
                {
                    List<User> lectors = (List<User>)result.Value;
                    SqlCommand command = new SqlCommand("SELECT aspnet_Users.LoweredUserName, aspnet_Membership.Email, Discipline.Name FROM Discipline, aspnet_Membership, aspnet_Users WHERE Discipline.UserId = aspnet_Membership.UserId AND aspnet_Membership.UserId = aspnet_Users.UserId", connection);
                    command.ExecuteNonQuery();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        User lector = lectors.Find(x => (x.Login.ToString().ToLower() == reader[0].ToString().ToLower()));
                        Discipline discipline = new Discipline(reader[2].ToString(), lector);
                        disciplines.Add(discipline);
                    }
                }
                else
                    throw new Exception();
            }
            catch (Exception e)
            {
                Success = false;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                connection.Close();
            }
            disciplines = disciplines.FindAll(p);
            return new Result(Success, disciplines);
        }

        public Result CreateDiscipline(string Name, string LectorLogin)
        {
            bool Success = true;
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
            SqlCommand command = new SqlCommand();
            int n = 0;
            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO [Discipline] VALUES(NEWID(), @n, (SELECT aspnet_Users.UserId FROM aspnet_Users WHERE aspnet_Users.LoweredUserName LIKE @l))";
                command.Parameters.Add(new SqlParameter("@n", Name) { SqlDbType = System.Data.SqlDbType.NChar });
                command.Parameters.Add(new SqlParameter("@l", LectorLogin.ToLower()) { SqlDbType = System.Data.SqlDbType.NChar });
                n = command.ExecuteNonQuery();
                if (n == 0) throw new Exception();
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

        public Result RenameDiscipline(string NewName, string OldName)
        {
            bool Success = true;
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
            SqlCommand command = new SqlCommand();
            int n = 0;
            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE [Discipline] SET [Discipline].Name = @n WHERE [Discipline].Name LIKE @o";
                command.Parameters.Add(new SqlParameter("@n", NewName) { SqlDbType = System.Data.SqlDbType.NChar });
                command.Parameters.Add(new SqlParameter("@o", OldName) { SqlDbType = System.Data.SqlDbType.NChar });
                n = command.ExecuteNonQuery();
                if (n == 0) throw new Exception();

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

        public Result DeleteDiscipline(Predicate<Discipline> p)
        {
            bool Success = true;
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
            SqlCommand command = new SqlCommand();
            int n = 0;
            try
            {
                connection.Open();
                command.Connection = connection;
                foreach (Discipline g in (List<Discipline>)ReadAllDisciplines(p).Value)
                {
                    command.CommandText = "DELETE FROM [Discipline] WHERE [Discipline].Name LIKE @n";
                    command.Parameters.Add(new SqlParameter("@n", g.Name));
                    n = command.ExecuteNonQuery();
                    
                }
                if (n == 0) throw new Exception();
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


        //методы, которые могут быть включены в транзакцию
        public Result ReadAllDisciplines(Predicate<Discipline> p, SqlConnection connection)
        {
            bool Success = true;
            List<Discipline> disciplines = new List<Discipline>();
            SqlDataReader reader = null;
            try
            {
                connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
                SqlCommand command = new SqlCommand("SELECT aspnet_Users.LoweredUserName, aspnet_Membership.Email, Discipline.Name FROM Discipline, aspnet_Membership, aspnet_Users WHERE Discipline.UserId = aspnet_Membership.UserId AND aspnet_Membership.UserId = aspnet_Users.UserId", connection);
                command.ExecuteNonQuery();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Discipline discipline = new Discipline(reader[2].ToString(), new User("f", "l", reader[1].ToString(), reader[0].ToString()));
                    disciplines.Add(discipline);
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
            }
            disciplines = disciplines.FindAll(p);
            return new Result(Success, disciplines);
        }

        public Result CreateDiscipline(string Name, string LectorLogin, SqlConnection connection)
        {
            bool Success = true;
            SqlCommand command = new SqlCommand();
            int n = 0;
            try
            {
                command.Connection = connection;
                command.CommandText = "INSERT INTO [Discipline] VALUES(NEWID(), @n, (SELECT aspnet_Users.UserId FROM aspnet_Users WHERE aspnet_Users.LoweredUserName LIKE @l))";
                command.Parameters.Add(new SqlParameter("@n", Name) { SqlDbType = System.Data.SqlDbType.NChar });
                command.Parameters.Add(new SqlParameter("@l", LectorLogin.ToLower()) { SqlDbType = System.Data.SqlDbType.NChar });
                n = command.ExecuteNonQuery();
                if (n == 0) throw new Exception();
            }
            catch (Exception e)
            {
                Success = false;
            }
            return new Result(Success, n);
        }

        public Result RenameDiscipline(string NewName, string OldName, SqlConnection connection)
        {
            bool Success = true;
            SqlCommand command = new SqlCommand();
            int n = 0;
            try
            {
                command.Connection = connection;
                command.CommandText = "UPDATE [Discipline] SET [Discipline].Name = @n WHERE [Discipline].Name LIKE @o";
                command.Parameters.Add(new SqlParameter("@n", NewName) { SqlDbType = System.Data.SqlDbType.NChar });
                command.Parameters.Add(new SqlParameter("@o", OldName) { SqlDbType = System.Data.SqlDbType.NChar });
                n = command.ExecuteNonQuery();
                if (n == 0) throw new Exception();

            }
            catch (Exception e)
            {
                Success = false;
            }
            return new Result(Success, n);
        }

        public Result DeleteDiscipline(Predicate<Discipline> p, SqlConnection connection)
        {
            bool Success = true;
            SqlCommand command = new SqlCommand();
            int n = 0;
            try
            {
                command.Connection = connection;
                foreach (Discipline g in (List<Discipline>)ReadAllDisciplines(p).Value)
                {
                    command.CommandText = "DELETE FROM [Discipline] WHERE [Discipline].Name LIKE @n";
                    command.Parameters.Add(new SqlParameter("@n", g.Name));
                    n = command.ExecuteNonQuery();

                }
                if (n == 0) throw new Exception();
            }
            catch (Exception e)
            {
                Success = false;
            }
            return new Result(Success, n);
        }
    }
}