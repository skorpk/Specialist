using Microsoft.Extensions.Configuration;

namespace Lab2_0_EntityFrame
{
    internal class Program
    {
        internal static IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                Person p1 = new Person() { Name = "Daria", Age = 29 };
                Person p2 = new Person() { Name = "Alezandra", Age = 20 };

                db.People.Add(p1);
                db.People.Add(p2);
                db.SaveChanges();
            }

            //извлекаем данные
            using (ApplicationContext db = new ApplicationContext())
            {
                var people = db.People.ToList();
                Console.WriteLine("People list:");
                foreach (Person person in people)
                    Console.WriteLine($"{person.Id}.{person.Name} - {person.Age}");

            }
        }
    }
}
