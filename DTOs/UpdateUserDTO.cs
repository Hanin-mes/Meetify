using System.ComponentModel.DataAnnotations;

namespace Meetify.DTOs
{
    public class UpdateUserDTO
    {
        public long Id { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Role { get; set; }

        public bool IsActive { get; set; }
    }
}
