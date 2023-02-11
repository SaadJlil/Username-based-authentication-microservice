using Microsoft.EntityFrameworkCore;
using Domain.Models;


namespace Infrastructure;


public class theDbContext: DbContext
{
    public theDbContext()
    {
    }
    public theDbContext(DbContextOptions<theDbContext> options): base(options)
    {}

    public DbSet<Users> user {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Users>().HasIndex(b => b.id).IsUnique();
        modelBuilder.Entity<Users>().HasIndex(b => b.Username).IsUnique();
    }

}