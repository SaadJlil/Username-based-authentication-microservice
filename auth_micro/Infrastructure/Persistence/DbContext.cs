using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infrastructure.Persistence;

public class TheContext: DbContext
{
    public TheContext()
    {}
    public TheContext(DbContextOptions<TheContext> options): base(options)
    {}

    public DbSet<Users> user {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Users>().HasIndex(b => b.Username).IsUnique();
    }

}