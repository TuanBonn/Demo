using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Demo.Models;

namespace Demo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Demo.Models.Book> Book { get; set; } = default!;
        public DbSet<Demo.Models.Category> Category { get; set; } = default!;
        public DbSet<Demo.Models.Cart> Cart { get; set; } = default!;
    }
}