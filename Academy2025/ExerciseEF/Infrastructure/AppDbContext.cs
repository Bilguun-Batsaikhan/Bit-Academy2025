using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Extensions;

namespace Infrastructure
{
    //The EF Core context. It represents your database session and is where you map entities to tables.
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameList> GameList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=localhost;Database=EFGameList;User Id=sa;Password=bitspa.1;TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedData();
        }
    }
}
