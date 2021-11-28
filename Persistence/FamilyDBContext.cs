using Assignment1_Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment1_Server.Persistence
{
    public class FamilyDBContext : DbContext
    {
        public DbSet<Adult> Adults { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Job> Jobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = family.db");
        }
    }
}
