using System;
using BAUST_Book_Store.Data;
using BAUST_Book_Store.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BAUST_Book_Store.Repositories;

public class SQLBookRepository : IBookRepository
{
    private readonly BookExchangeDbContext dbContext;

    public SQLBookRepository(BookExchangeDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<Book> CreateBookAsync(Book book)
    {
        dbContext.Add(book);
        await dbContext.SaveChangesAsync();
        return book;        
    }
    Task<List<Book>> IBookRepository.GetAllBookAsync()
    {
        var booksQuery = dbContext.Books.Include(x=>x.Owner).ToListAsync();
        return booksQuery;
    }

    public async Task DeleteBookByIdAsync(int id)
    {
        var book = await dbContext.Books.FirstOrDefaultAsync(c => c.Id == id);
        if (book is null)
        {
            throw new KeyNotFoundException($"Book with id {id} not found");
        }
        dbContext.Books.Remove(book);
        await dbContext.SaveChangesAsync();
    }
    public async Task<Book?> GetBookByIdAsync(int id)
    {
        var book = await dbContext.Books.Include(x=>x.Owner).FirstOrDefaultAsync(c => c.Id == id);
        if (book is null)
        {
            return null;
        }
        return book;
    }

    public async Task<Book?> UpdateBookAsync(int id, Book book)
    {
        var existingbook = await dbContext.Books.FirstOrDefaultAsync(c => c.Id == id);
        if (book is null)
        {
            return null;
        }

        existingbook.book_Name = book.book_Name;
        existingbook.author_Name = book.author_Name;
        existingbook.edition = book.edition;
        existingbook.Description = book.Description;
        existingbook.img_Url = book.img_Url;
        existingbook.condition = book.condition;
        existingbook.bookPrice = book.bookPrice;
        existingbook.rentPrice = book.rentPrice;
        existingbook.isAvilable = book.isAvilable;
        await dbContext.SaveChangesAsync();
        return existingbook;
    }
}
