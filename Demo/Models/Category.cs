namespace Demo.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }

        // Navigation properties
        public ICollection<Book>? Books { get; set; }
    }
}
