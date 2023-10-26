using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Cart
    {
        [Key]
        public int CartDetailID { get; set; }
        public int Quantity { get; set; }

        // Foreign keys
        public int ProductID { get; set; }

        // Navigation properties
        [ForeignKey("ProductID")]
        public Book? Book { get; set; }

    }
}
