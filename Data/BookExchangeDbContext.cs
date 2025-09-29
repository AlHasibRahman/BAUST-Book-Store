using System;
using BAUST_Book_Store.Models.Domain;
using Microsoft.EntityFrameworkCore;
namespace BAUST_Book_Store.Data;

public class BookExchangeDbContext : DbContext
{
    public BookExchangeDbContext(DbContextOptions<BookExchangeDbContext> options) : base(options)
    {

    }

    public DbSet<Book> Books { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Image> Images { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Book>()
        .HasOne(b => b.Owner)
        .WithMany(u => u.Books)
        .HasForeignKey(b => b.OwnerId)
        .OnDelete(DeleteBehavior.Cascade); // Ef default behavior

        modelBuilder.Entity<Transaction>()
        .HasOne(t => t.Buyer)
        .WithMany(u => u.Transactions)
        .HasForeignKey(t => t.BuyerId)
        .OnDelete(DeleteBehavior.Restrict); // or NoAction */



      /*  var books = new List<Book>()
        {
            new Book
            {
                Id = 1, book_Name = "Harry Poter", author_Name = "XYZ", edition = "4th edition", Description = "Abcdefg-abcfged-abcdeg",
                img_Url = "Localhost://123.jpg", condition = "Good", bookPrice = 120.25, rentPrice = 25.25, isAvilable = true
            },
            new Book
            {
                Id = 2, book_Name = "Harry Wolf", author_Name = "XYZ", edition = "4th edition", Description = "Abcdefg-abcfged-abcdeg",
                img_Url = "Localhost://123.jpg", condition = "Good", bookPrice = 120.25, rentPrice = 25.25, isAvilable = true
            },
            new Book
            {
                Id = 3, book_Name = "Harry Big", author_Name = "XYZ", edition = "4th edition", Description = "Abcdefg-abcfged-abcdeg",
                img_Url = "Localhost://123.jpg", condition = "Good", bookPrice = 120.25, rentPrice = 25.25, isAvilable = true
            },
            new Book
            {
                Id = 4, book_Name = "Harry Karl", author_Name = "XYZ", edition = "4th edition", Description = "Abcdefg-abcfged-abcdeg",
                img_Url = "Localhost://123.jpg", condition = "Good", bookPrice = 120.25, rentPrice = 25.25, isAvilable = true
            },
            new Book
            {
                Id = 5, book_Name = "Harry Gen", author_Name = "XYZ", edition = "4th edition", Description = "Abcdefg-abcfged-abcdeg",
                img_Url = "Localhost://123.jpg", condition = "Good", bookPrice = 120.25, rentPrice = 25.25, isAvilable = true
            }

        };
        modelBuilder.Entity<Book>().HasData(books); */
    }
}
