using Application.Dtos;

namespace Application.Interfaces;

public interface IPermissionService
{
    Task<PermissionCheckResult> CheckPermissionAsync(PermissionCheckRequest request);
}
