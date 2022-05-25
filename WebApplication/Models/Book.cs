using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Book
    {
        [Key]
        public int book_id { get; set; }
        public string? name { get; set; }

        public string? publisher { get; set; }

        public string? category_type { get; set; }
        public ICollection<Category>? Category { get; set; }
        public AuthorBook? AuthorBook { get; set; }

        public int stock_id { get; set; }
        public ICollection<Library>? Library { get; set; }

        public int message_id { get; set; }
        public ICollection<Message>? Message { get; set; }
    }
}
