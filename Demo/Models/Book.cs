using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    public class Book
    {
        [Key]
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ShortDescription { get; set; }
        public double Price { get; set; }
        public string? ImageURL { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        // Foreign key
        public int? CategoryID { get; set; }

        // Navigation properties
        [ForeignKey("CategoryID")]
        public Category? Category { get; set; }

    }
}
