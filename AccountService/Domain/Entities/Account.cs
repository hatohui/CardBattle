namespace Domain.Entities;

public class Account
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? AvatarUrl { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? LastLoginAt { get; set; }
    public bool IsActive { get; set; } = true;
}
