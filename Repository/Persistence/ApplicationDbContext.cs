using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;

namespace Repository.Persistence;

public class ApplicationDbContext : IdentityDbContext <User,IdentityRole<int>,int>
{
    public ApplicationDbContext() { }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    //Only uncomment this section when adding migrations to database only. DO NOT use this for production.
    /******************************************************************************/
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        optionsBuilder
            .UseSqlServer("Server=localhost;Database=ASM_3;uid=sa;pwd=1234567890;TrustServerCertificate=True;MultipleActiveResultSets=True");
    }
    /******************************************************************************/
    public DbSet<Category>? Categories{ get; set; }
    public DbSet<Order>? Orders { get; set; }
    public DbSet<OrderDetail>? OrderDetails { get; set; }
    public DbSet<Product>? Products { get; set; }    
    public DbSet<User>? Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}