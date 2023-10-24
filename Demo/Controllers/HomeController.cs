using Demo.Data;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Book.Include(b => b.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        [HttpGet]
        [Route("/SearchBook")]
        public IActionResult SearchBook(string searchString)
        {
            if (String.IsNullOrEmpty(searchString))
            {
                return View();
            }
            var searched_books = _context.Book.Include(prd => prd.Category)
                .Where(s => s.ProductName.Contains(searchString)); // It's always null
            ViewBag.searched_books = searched_books.ToList();
            return View();
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}