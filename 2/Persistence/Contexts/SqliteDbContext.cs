using Application.Common.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public sealed class SqliteDbContext : DbContext, IDbContext
    {
        public SqliteDbContext(DbContextOptions<SqliteDbContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Item> Items { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Name = "feugiat in" },
                new Item { Id = 2, Name = "nec tincidunt" },
                new Item { Id = 3, Name = "cursus vitae" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}