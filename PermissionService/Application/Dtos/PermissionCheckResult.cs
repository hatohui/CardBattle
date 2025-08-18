namespace Application.Dtos;

public class PermissionCheckResult
{
    public bool Allowed { get; set; }
    public string Reason { get; set; } = string.Empty;
}
