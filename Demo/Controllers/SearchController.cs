using Demo.Data;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Demo.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var applicationDbContext = _context.Book.Include(b => b.Category);

            if (_context.Book == null)
            {
                return Problem("Entity set 'applicationDbContext.Book'  is null.");
            }

            var books = from m in _context.Book
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.ProductName.Contains(searchString));
                return View(await books.ToListAsync());
            }
            return View(await applicationDbContext.ToListAsync());

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
    }
}
