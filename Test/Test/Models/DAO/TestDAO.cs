using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models.DAO
{

    public class TestDAO
    {
        public Res ReadAllResults(Func<Result, bool> p, ModelContainer data)
        {
            bool Success = true;
            IEnumerable<Result> results = null;
            try
            {
                results = data.Results.Select(row => row).Where(p);
            }
            catch (Exception e)
            {
                Success = false;
            }

            return new Res(Success, results);
        }


        public Res Check(Test t, ModelContainer data, aspnet_Users user)
        {
            int c = 0;
            bool Success = true;
            try
            {
                Test test = (ReadTests(x => x.TestId == t.TestId, data).Value as IEnumerable<Test>).First();
                //сравнение вопросов у тестов
                for(int i = 0; i < test.Quastions.ToList().Count; i++)
                {
                    int b = 1;
                    for(int j = 0; j < test.Quastions.ToList()[i].Variants.Count; j++)
                    {
                        if (test.Quastions.ToList()[i].Variants.ToList()[j].IsValid != t.Quastions.ToList()[i].Variants.ToList()[j].IsValid)
                        {
                            b = 0;
                        }
                    }
                    c += b;

                }

                //сохранение результатов, только если не уже не был пройден этот тест
                if (data.Results.FirstOrDefault(x => x.aspnet_Users.UserId == user.UserId && x.TestId == t.TestId) != null)
                    return new Res(Success, data.Results.FirstOrDefault(x => x.aspnet_Users.UserId == user.UserId && x.TestId == t.TestId).Result1);
                Result r = data.Results.Create();
                r.TestId = t.TestId;
                r.Test = test;
                r.Result1 = c;
                r.aspnet_Users = user;
                r.aspnet_Users_UserId = user.UserId;
                data.Results.Add(r);
                data.SaveChanges();
            }
            catch (Exception e)
            {
                Success = false;
            }

            return new Res(Success, c);
        }



        public Res Bind(Test t, Group g, ModelContainer data)
        {
            bool Success = true;
            try
            {
                g.Tests.Add(t);
                data.Tests.First(tt => tt.TestId == t.TestId).Groups.Add(g);
                data.SaveChanges();

            }
            catch (Exception e)
            {
                Success = false;
            }

            return new Res(Success, null);
        }

        public Res ReadTests(Func<Test, bool> p, ModelContainer data)
        {
            bool Success = true;
            IEnumerable<Test> tests = null;
            try
            {
                tests = data.Tests.Select(row => row).Where(p);
            }
            catch (Exception e)
            {
                Success = false;
            }

            return new Res(Success, tests);
        }

        public Res ReadQuastions(Func<Quastion, bool> p, ModelContainer data)
        {
            bool Success = true;
            IEnumerable<Quastion> quastions = null;
            try
            {
                quastions = data.Quastions.Select(row => row).Where(p);
            }
            catch (Exception e)
            {
                Success = false;
            }

            return new Res(Success, quastions);
        }

        public Res ReadVariants(Func<Variant, bool> p, ModelContainer data)
        {
            bool Success = true;
            IEnumerable<Variant> variants = null;
            try
            {
                variants = data.Variants.Select(row => row).Where(p);
            }
            catch (Exception e)
            {
                Success = false;
            }

            return new Res(Success, variants);
        }

        public Res CreateTests(string TestName, Discipline discipline, ModelContainer data)
        {
            bool Success = true;
            IEnumerable<Test> tests = null;
            try
            {
                Test test = data.Tests.Create();
                test.TestId = Guid.NewGuid();
                test.Name = TestName;
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
            try
            {
                tests = data.Tests.Select(row => row).Where(p);
                foreach (Test t in tests.ToList())
                {
                    data.Tests.Remove(t);

                }
                data.SaveChanges();
            }
            catch (Exception e)
            {
                Success = false;
            }

            return new Res(Success, tests);
        }

        public Res CreateQuastion(Test test, string text, ModelContainer data)
        {
            bool Success = true;
            IEnumerable<Quastion> quastions = null;
            try
            {
                Quastion q = data.Quastions.Create();
                q.QuastionId = Guid.NewGuid();
                q.Text = text;
                q.Test = data.Tests.First(x => x.TestId == test.TestId);
                data.Quastions.Add(q);
                data.SaveChanges();
            }
            catch (Exception e)
            {
                Success = false;
            }

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
            try
            {
                Quastion quastion = data.Quastions.First(x => x.QuastionId == q.QuastionId);
                Variant v = data.Variants.Create();
                v.VariantId = Guid.NewGuid();
                v.IsValid = isValid;
                v.Text = Text;
                v.Quastion = q;
                data.Variants.Add(v);
                data.SaveChanges();
            }
            catch (Exception e)
            {
                Success = false;
            }
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