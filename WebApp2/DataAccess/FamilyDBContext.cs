using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;
using WebApp2.Models;

namespace WebApp2.DataAccess
{
    public class FamilyDBContext : DbContext
    {
        public DbSet<Family> Families { get; set; }
        public DbSet<Adult> Adults { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Family.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
//            modelBuilder.Entity<ChildInterestTable>().HasKey(cit =>
//                new
//                {
//                    cit.Id,
//                    cit.InterestId
//                });

//            modelBuilder.Entity<ChildInterestTable>()
//                .HasOne(cit => cit.ChildInterest)
//                .WithMany(childInterest => childInterest.ChildInterestTables)
//                .HasForeignKey(cit => cit.InterestId);

//            modelBuilder.Entity<ChildInterestTable>()
//                .HasOne(cit => cit.Child)
//                .WithMany(child => child.ChildInterestTables)
//                .HasForeignKey(cit => cit.Id);
        }
    }
}