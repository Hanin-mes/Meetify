namespace Meetify.DTOs.Users;

public class UsersDTO
{
    public long Id { get; set; }               // match your PK type
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string? Phone { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; }
}
