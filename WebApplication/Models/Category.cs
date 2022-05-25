using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Category
    {
        [Key]
        public string? category_type { get; set; }
        public int category_id { get; set; }
        public Book? Book { get; set; }
    }
}
