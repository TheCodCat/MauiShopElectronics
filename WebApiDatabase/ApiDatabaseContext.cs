using Microsoft.EntityFrameworkCore;
using Models.models;

namespace WebApiDatabase
{
    public class ApiDatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Categorie> Categories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=data.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
