using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models.DAO
{
    public class TestDAO
    {
        public Res ReadTests(Func<Test, bool> p, ModelContainer data)
        {
            bool Success = true;
            IEnumerable<Test> tests = null;
           // try
           // {
                tests = data.Tests.Select(row => row).Where(p);
         //   }
          //  catch (Exception e)
          //  {
                Success = false;
          //  }

            return new Res(Success, tests);
        }

        public Res ReadQuastions(Func<Quastion, bool> p, ModelContainer data)
        {
            bool Success = true;
            IEnumerable<Quastion> quastions = null;
            // try
            // {
            quastions = data.Quastions.Select(row => row).Where(p);
            //   }
            //  catch (Exception e)
            //  {
            Success = false;
            //  }

            return new Res(Success, quastions);
        }

        public Res ReadVariants(Func<Variant, bool> p, ModelContainer data)
        {
            bool Success = true;
            IEnumerable<Variant> variants = null;
            // try
            // {
            variants = data.Variants.Select(row => row).Where(p);
            //   }
            //  catch (Exception e)
            //  {
            Success = false;
            //  }

            return new Res(Success, variants);
        }

        public Res CreateTests(string TestName, Discipline discipline, string GroupId, ModelContainer data)
        {
            bool Success = true;
            IEnumerable<Test> tests = null;
            try
            {
                Group g = ((new GroupDAO()).ReadAll(x => x.GroupId.ToString() == GroupId, data).Value as IEnumerable<Group>).First();
                Test test = data.Tests.Create();
                test.TestId = Guid.NewGuid();
                test.Name = TestName;
                test.Groups.Add(g);
                test.Discipline = discipline;
                data.Tests.Add(test);
                data.SaveChanges();
            }
            catch (Exception e)
            {
                Success = false;
            }

            return new Res(Success, tests);
        }

        public Res DeleteTests(Func<Test, bool> p, ModelContainer data)
        {
            bool Success = true;
            IEnumerable<Test> tests = null;
            IEnumerable<Models.Quastion> questions = null;
            IEnumerable<Variant> variants = null;
            //try
            //{
                tests = data.Tests.Select(row => row).Where(p);
                    

                foreach (Test t in tests)
                {
                    foreach(Quastion q in t.Quastions)
                    {
                        foreach(Variant v in q.Variants)
                        {

                            data.Variants.Remove(v);
                            
                        }
                        data.Quastions.Remove(q);
                        
                    }
                    data.Tests.Remove(t);
                   
                }
                data.SaveChanges();
           // }
          //  catch (Exception e)
          //  {
                Success = false;
          //  }

            return new Res(Success, tests);
        }

        public Res CreateQuastion(Test test, string text, ModelContainer data)
        {
            bool Success = true;
            IEnumerable<Quastion> quastions = null;
            //try
           // {
                Quastion q = data.Quastions.Create();
                q.QuastionId = Guid.NewGuid();
                q.Text = text;
                q.Test = data.Tests.First(x => x.TestId == test.TestId);
                data.Quastions.Add(q);
                data.SaveChanges();
           // }
           // catch (Exception e)
           // {
                Success = false;
           // }

            return new Res(Success, quastions);
        }

        public Res ChangeTextQuastion(Func<Quastion, bool> p, string text, ModelContainer data)
        {
            bool Success = true;
            IEnumerable<Quastion> quastions = null;
            try
            {
                quastions = data.Quastions.Select(row => row).Where(p);
                foreach(Quastion q in quastions)
                    q.Text = text;
                data.SaveChanges();
            }
            catch (Exception e)
            {
                Success = false;
            }

            return new Res(Success, quastions);
        }

        public Res DeleteQuastions(Func<Quastion, bool> p, ModelContainer data)
        {
            bool Success = true;
            IEnumerable<Quastion> quastions = null;
            try
            {
                quastions = data.Quastions.Select(row => row).Where(p);
                foreach (Quastion q in quastions)
                    data.Quastions.Remove(q);
                data.SaveChanges();
            }
            catch (Exception e)
            {
                Success = false;
            }
            return new Res(Success, quastions);
        }

        public Res CreateVariant(Quastion q, string Text, bool isValid, ModelContainer data)
        {
            bool Success = true;
            IEnumerable<Quastion> quastions = null;
           // try
           // {
                Quastion quastion = data.Quastions.First(x => x.QuastionId == q.QuastionId);
                Variant v = data.Variants.Create();
                v.VariantId = Guid.NewGuid();
                v.IsValid = isValid;
                v.Text = Text;
                v.Quastion = q;
                data.Variants.Add(v);
                data.SaveChanges();
           // }
           // catch (Exception e)
           // {
                Success = false;
         //   }
            return new Res(Success, quastions);
        }

        public Res ChangeVariant(Func<Variant, bool> p, string Text, bool isValid, ModelContainer data)
        {
            bool Success = true;
            IEnumerable<Variant> variants = null;
            try
            {
                variants = data.Variants.Select(row => row).Where(p);
                foreach (Variant v in variants)
                {
                    v.IsValid = isValid;
                    v.Text = Text;
                }
                data.SaveChanges();
            }
            catch (Exception e)
            {
                Success = false;
            }
            return new Res(Success, variants);
        }

        public Res DeleteVariant(Func<Variant, bool> p, ModelContainer data)
        {
            bool Success = true;
            IEnumerable<Variant> variants = null;
            try
            {
                variants = data.Variants.Select(row => row).Where(p);
                foreach (Variant v in variants)
                {
                    data.Variants.Remove(v);
                }
                data.SaveChanges();
            }
            catch (Exception e)
            {
                Success = false;
            }
            return new Res(Success, variants);
        }

    }
}