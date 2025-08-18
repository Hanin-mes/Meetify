using System.ComponentModel.DataAnnotations;

namespace Meetify.DTOs.Users;

public class CreateUsersDTO
{
    [Required, MaxLength(100)]
    public string FirstName { get; set; } = default!;

    [Required, MaxLength(100)]
    public string LastName { get; set; } = default!;

    [Required, EmailAddress, MaxLength(200)]
    public string Email { get; set; } = default!;
    public string? PasswordHash { get; set; }

    public string? Role { get; set; } // Admin, Employee, Guest

    [Phone]
    public string? Phone { get; set; }
}
