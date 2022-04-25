using System.ComponentModel.DataAnnotations;

namespace AuthenticationService.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

    }
}