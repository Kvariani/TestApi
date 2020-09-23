using Microsoft.EntityFrameworkCore;
using PersonDirectory.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Infrastructure.DBContexts
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {



        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Person>().ToTable(nameof(Person));

            modelBuilder.Entity<Person>().Property(x => x.Firstname).IsRequired();
            modelBuilder.Entity<Person>().Property(x => x.Lastname).IsRequired();
            

            modelBuilder.Entity<Person>()
            //.HasRequired<FirstName>(s => s.CurrentGrade)
            .HasMany(g => g.ReladedPersons).WithOne(x => x.Person).OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<RelatedPersonToPerson>().HasOne(x => x.RelatedPerson);
            //.HasRequired<FirstName>(s => s.CurrentGrade)
            //.HasMany(g => g.ReladedPersons).WithOne(x => x.Person);
        }
    }
}
