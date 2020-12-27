using Microsoft.EntityFrameworkCore;

using shop.DAL.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.DAL.Connect
{
    public class ProductContext : DbContext
    {
        public ProductContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Order { get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite("Data Source=Shop.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Color)
                .WithMany(b => b.Product)
                .HasForeignKey(p=>p.ColorID)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(b => b.Product)
                .HasForeignKey(p => p.CategoryID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
