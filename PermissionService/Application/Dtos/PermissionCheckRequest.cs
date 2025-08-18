namespace Application.Dtos;

public class PermissionCheckRequest
{
    public Guid SubjectId { get; set; }
    public string Resource { get; set; } = string.Empty;
    public string Action { get; set; } = string.Empty;
}
