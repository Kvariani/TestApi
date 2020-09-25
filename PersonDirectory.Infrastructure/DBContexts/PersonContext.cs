using Microsoft.EntityFrameworkCore;
using PersonDirectory.Core.Entities;

namespace PersonDirectory.Infrastructure.DBContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Person> Persons { get; set; }
        public DbSet<RelatedPersonToPerson> RelatedPersonToPerson { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<RelatedPersonToPerson>()
                .HasKey(bc => new { bc.PersonId, bc.RelatedPersonId });
            modelBuilder.Entity<RelatedPersonToPerson>()
                .HasOne(bc => bc.Person)
                .WithMany(b => b.ReladedPersons)
                .HasForeignKey(bc => bc.PersonId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RelatedPersonToPerson>()
                .HasOne(bc => bc.RelatedPerson)
                .WithMany(c => c.ReladedOn)
                .HasForeignKey(bc => bc.RelatedPersonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TelNumber>()
                .HasOne(x => x.Person)
                .WithMany(x => x.TelNumbers)
                .HasForeignKey(x => x.PersonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}