using System;
using System.ComponentModel.DataAnnotations;

namespace Bag.It.Models
{
    public class User
    {
        public string Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string Username { get; set; }
        [Required]
        [MaxLength(256)]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}