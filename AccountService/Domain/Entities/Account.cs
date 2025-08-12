using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Account
{
    [Key]
    public required string Id { get; set; }

    [Required, MaxLength(100)]
    public required string Name { get; set; }

    [Url]
    public string? AvatarUrl { get; set; }

    [Required, EmailAddress, MaxLength(255)]
    public required string Email { get; set; }

    [Required]
    public required string PasswordHash { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? LastLoginAt { get; set; }

    [Required]
    public bool IsActive { get; set; } = true;

    public void UpdateTimestamps()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}
