using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Security;
using System.Data.Linq;
using System.Data.Entity;

namespace Test.Models
{
    public class DisciplineDAO
    {
        //методы, выполняющиеся отдельно
        public Result ReadAllDisciplines(Func<Discipline, bool> p, ModelContainer data)
        {
            bool Success = true;
            IEnumerable<Discipline> disciplines = null;
            try
            {
                disciplines = data.Disciplines.Select(row => row).Where(p);
            }
            catch (Exception e)
            {
                Success = false;
            }
            
            return new Result(Success, disciplines);
        }

        public Result CreateDiscipline(string Name, aspnet_Users user, ModelContainer data)
        {
            bool Success = true;
            Discipline d = null;
            try
            {
                d = data.Disciplines.Create();
                d.DisciplineId = Guid.NewGuid();
                d.aspnet_Users = user;
                d.DisciplineName = Name;
                data.Disciplines.Add(d);
                data.SaveChanges();
            }
            catch (Exception e)
            {
                Success = false;
            }
  
            return new Result(Success, d);
        }

        public Result RenameDiscipline(string NewName, string OldName, ModelContainer data)
        {
            bool Success = true;
            Discipline d = null;
            try
            {
                d = data.Disciplines.First(row => (row.DisciplineName == OldName));
                d.DisciplineName = NewName;
                data.SaveChanges();
            }
            catch (Exception e)
            {
                Success = false;
            }
            
            return new Result(Success, d);
        }

        public Result DeleteDiscipline(Func<Discipline, bool> p, ModelContainer data)
        {
            bool Success = true;
            Discipline d = null;
            try
            {
                IEnumerable<Discipline> disciplines = data.Disciplines.Select(row => row).Where(p);
                foreach (Discipline di in disciplines)
                    data.Disciplines.Remove(di);
                data.SaveChanges();
            }
            catch (Exception e)
            {
                Success = false;
            }
            
            return new Result(Success, d);
        }

    }
        
}