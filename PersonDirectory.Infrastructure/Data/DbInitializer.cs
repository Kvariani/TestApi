using PersonDirectory.Infrastructure.DBContexts;
using System;
using System.Linq;
using PersonDirectory.Core.Entities;

namespace PersonDirectory.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Persons.Any())
            {
                return;   // DB has been seeded
            }

            var persons = new Person[]
            {
                //new Person() { Firstname = "ბექა" , Lastname ="ქვარიანი", DateOfBirth = new DateTime(1990,08,08), Gender = Core.Enums.GenderEnum.Male, IDNumber = "01027058514"}

            };
            foreach (var s in persons)
            {
                context.Persons.Add(s);
            }
            context.SaveChanges();

        }
    }
}