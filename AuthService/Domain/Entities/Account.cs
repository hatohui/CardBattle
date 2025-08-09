public class Account
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? AvatarUrl { get; set; }
    public string Email { get; set; }
    public string PasswordHashed { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? LastLoginAt { get; set; }
}
