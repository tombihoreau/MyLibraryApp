using Microsoft.AspNetCore.Mvc;
using MyLibraryApp.Models;
using MyLibraryApp.Data;


public class BookController : Controller
{
    private readonly BookService _bookService;

    public BookController(BookService bookService)
    {
        _bookService = bookService;
    }

    public async Task<IActionResult> Index()
    {
        var books = await _bookService.GetAllBooks();
        return View(books);
    }

    public async Task<IActionResult> Details(int id)
    {
        var book = await _bookService.GetBookById(id);
        if (book == null) return NotFound();
        return View(book);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Book book)
    {
        if (!ModelState.IsValid) return View(book);
        await _bookService.AddBook(book);
        return RedirectToAction(nameof(Index));
    }
    
}
