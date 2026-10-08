using Library_System.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Library_System.Dbcontext
{
    internal class LibraryDbContext : DbContext
    {
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Library;Trusted_Connection=True;");
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Berrower> Borrowers { get; set; }
        public DbSet<Laon> Loans { get; set; }
        override protected void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Laon>().HasKey(l => new { l.BorrowerId, l.BookId });
            mb.Entity<Laon>()
                .HasOne(l => l.books)
                .WithMany(b => b.Laons)
                .HasForeignKey(l => l.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            mb.Entity<Laon>()
                .HasOne(l => l.Berrowers)
                .WithMany(b => b.Laons)
                .HasForeignKey(l => l.BorrowerId)
                .OnDelete(DeleteBehavior.Restrict);

             mb.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);



        }
    }
}