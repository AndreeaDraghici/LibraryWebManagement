using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class AuthorBook
    {
        [Key]
        public int id { get; set; }
        public int author_id { get; set; }
        public ICollection<Author>? Authors { get; set; }

        public int book_id { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
