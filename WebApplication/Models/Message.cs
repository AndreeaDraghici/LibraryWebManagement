using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Message
    {
        [Key]
        public int message_id { get; set; }
        public Book? Book { get; set; }

        public int user_id { get; set; }
        public ICollection<User>? User { get; set; }

        public string? subject { get; set; }
    }
}
