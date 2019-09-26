using System.ComponentModel.DataAnnotations;

namespace Bag.It.Auth.Models
{
    public class RegisterUserRequest
    {
        [Required]
        [StringLength(255)]
        public string Username { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }
    }
}