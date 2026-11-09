using CapstoneProject.Areas.Identity.Data;
using CapstoneProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CapstoneProject.Data;

public class CapstoneProjectDbContext : IdentityDbContext<CapstoneProjectUser>
{
    public CapstoneProjectDbContext(DbContextOptions<CapstoneProjectDbContext> options)
        : base(options)
    {
    }

    public DbSet<Purchasing> Purchases { get; set; }
    public DbSet<Donation> Donations { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Liability> LiabilityForms { get; set; }
    public DbSet<ResourceRequest> ResourceRequests { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<TransactionLineItem> TransactionLineItems { get; set; }
    //public DbSet<UserApplication> UserApplications { get; set; }
    public DbSet<UserSurvey> UserSurveys { get; set; }
    public DbSet<ItemCategory> ItemCategories { get; set; }
    public DbSet<ItemSubcategory> ItemSubcategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // configure Quantity property in the Item entity
        modelBuilder.Entity<Item>()
            .Property(i => i.Quantity)
            .HasColumnType("decimal(6, 2)");
        modelBuilder.Entity<CapstoneProjectUser>()
            .HasIndex(x=>x.StudentId).IsUnique();
    }
}
