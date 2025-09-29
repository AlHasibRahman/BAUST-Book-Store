using System;
using BAUST_Book_Store.Models.Domain;

namespace BAUST_Book_Store.Repositories;

public interface IBookRepository
{
    Task<List<Book>> GetAllBookAsync();
    Task<Book?> GetBookByIdAsync(int id);
    Task<Book> CreateBookAsync(Book book);
    Task<Book?> UpdateBookAsync(int id, Book book);
    Task DeleteBookByIdAsync(int id);
}
