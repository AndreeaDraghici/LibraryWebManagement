using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Library
    {
        [Key]
        public int stock_id { get; set; }

        public Book? Book { get; set; }

        public int total_nr_of_books { get; set; }

        public int borrowed_books { get; set; }
    }
}
