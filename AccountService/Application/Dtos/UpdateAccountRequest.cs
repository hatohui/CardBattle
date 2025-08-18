namespace Application.Dtos;

public class UpdateAccountRequest
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? AvatarUrl { get; set; }
}
