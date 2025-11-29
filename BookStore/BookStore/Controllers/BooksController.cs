using BookStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index(string category, string search)
        {
            var books = _context.Books.AsQueryable();

            // Filter by category if provided
            if(!string.IsNullOrEmpty(category))
            {
                books = books.Where(b => b.Category == category);
            }

            // Search by title or author
            if(!string.IsNullOrEmpty(search))
            {
                books = books.Where(b => b.Title.Contains(search) || b.Author.Contains(search));
            }

            ViewBag.Categories = await _context.Books
                                        .Select(b => b.Category)
                                        .Distinct()
                                        .ToListAsync();

            ViewData["CurrentCategory"] = category;
            ViewData["CurrentSearch"] = search;

            return View(await books.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
    }
}
