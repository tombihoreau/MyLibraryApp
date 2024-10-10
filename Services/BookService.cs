using Microsoft.AspNetCore.Mvc;
using MyLibraryApp.Models;
using MyLibraryApp.Data;
using Microsoft.EntityFrameworkCore;

public class BookService
{
    private readonly LibraryContext _context;

    public BookService(LibraryContext context)
    {
        _context = context;
    }

    public async Task<Book> GetBookById(int id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task<IEnumerable<Book>> GetAllBooks()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task AddBook(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
    }
    
}



