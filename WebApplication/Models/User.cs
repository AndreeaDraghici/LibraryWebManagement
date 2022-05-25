using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [NotMapped]
    public class User : IdentityUser
    {
        [Key]
        public int user_id { get; set; }

        public string? username { get; set; }
        public string? password { get; set; }

        public string? email { get; set; }

        public bool? is_admin { get; set; }

        public Message? Message { get; set; }

        [NotMapped]
        public object Ida { get; internal set; }
        [NotMapped]
        public object PasswordHasha
        {
            get; internal set;
        }
    }
}
