using HomeBudget.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.Models;

public class HomeBudgetContext: DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlite("Data Source=./App_Data/HomebudgetDB.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(e => e.Transactions)
            .WithOne(e => e.User)
            .HasForeignKey(e=> e.UserId)
            .HasPrincipalKey(e=> e.Id);
        
        modelBuilder.Entity<Category>()
            .HasMany(e => e.Transactions)
            .WithOne(e => e.Category)
            .HasForeignKey(e=> e.CategoryId)
            .HasPrincipalKey(e=> e.Id);
        
    }
}