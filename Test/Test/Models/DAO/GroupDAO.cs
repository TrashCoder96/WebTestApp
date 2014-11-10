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
        public Result ReadAll(Func<Group, bool> p, ModelContainer data)
        {
            bool Success = true;
            IEnumerable<Group> groups = null;
            try
            {
                groups = data.Groups.Select(row => row).Where(p);
            }
            catch (Exception e)
            {
                Success = false;
            }
            return new Result(Success, groups);
        }

        public Result CreateGroup(string Name, ModelContainer data)
        {
            bool Success = true;
            Group g = null;
            try
            {
                g = data.Groups.Create();
                g.GroupId = Guid.NewGuid();
                g.GroupName = Name;
                data.Groups.Add(g);
                data.SaveChanges();
            }
            catch (Exception e)
            {
                Success = false;
            }
            return new Result(Success, g);
        }

        public Result UpdateGroup(string NewName, string OldName, ModelContainer data)
        {
            bool Success = true;
            Group g = null;
            try
            {
                g = data.Groups.First(row => (row.GroupName == OldName));
                g.GroupName = NewName;
                data.SaveChanges();
            }
            catch (Exception e)
            {
                Success = false;
            }
            return new Result(Success, g);
        }

        public Result DeleteGroup(Func<Group, bool> p, ModelContainer data)
        {
            bool Success = true;
            IEnumerable<Group> groups = null;
            try
            {
                groups = data.Groups.Select(row => row).Where(p);
                foreach (Group g in groups)
                    data.Groups.Remove(g);
                data.SaveChanges();
            }
            catch (Exception e)
            {
                Success = false;
            }
            return new Result(Success, groups);
        }

        public Result AddStudent(aspnet_Users student, Group group, ModelContainer data)
        {
            bool Success = true;
            IEnumerable<Group> groups = null;
            try
            {
                foreach (Group g in student.Groups)
                    g.aspnet_Users.Remove(student);
                group.aspnet_Users.Add(student);
                data.SaveChanges();
            }
            catch (Exception e)
            {
                Success = false;
            }
            return new Result(Success, groups);
        }
    }
}