using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_commerce_System.model;
using Microsoft.EntityFrameworkCore;
namespace E_commerce_System.Dbcontext
{
    internal class ShopDbContect : DbContext
    {
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ShopDb;Integrated Security=True");
        }
        public DbSet<Category> Categories  { get; set; }
        public DbSet<product> Products { get; set; }
        public DbSet<custmer> Customers { get; set; }
        public DbSet<orders> Orders { get; set; }
        public DbSet<orderdetail> OrderDetails { get; set; }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<orderdetail>().HasKey(od => new { od.OrderId, od.ProductId });
            modelBuilder.Entity<orderdetail>()
                .HasOne(od => od.order)
                .WithMany(o => o.orderdetails)
                .HasForeignKey(od => od.OrderId);
            modelBuilder.Entity<orderdetail>()
                .HasOne(od => od.products)
                .WithMany(p => p.orderdetails)
                .HasForeignKey(od => od.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            //==================================

            modelBuilder.Entity<product>()
                .HasOne(p => p.Cat1)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.categoryId)
                .OnDelete(DeleteBehavior.Restrict);
            //==================================
            //==================================
            modelBuilder.Entity<orders>()
                .HasOne(o => o.Cus1)
                .WithMany(c => c.Order)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            //===================================

         



        }
    }
}
