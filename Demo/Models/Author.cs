namespace Demo.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string? AuthorName { get; set; }

        // Navigation properties
        public ICollection<Book>? Books { get; set; }
    }
}
