using Application.Dtos;
using Application.Interfaces;

namespace Application.Services;

public class PermissionService : IPermissionService
{
    public Task<PermissionCheckResult> CheckPermissionAsync(PermissionCheckRequest request)
    {
        var allowed = string.Equals(request.Action, "read", StringComparison.OrdinalIgnoreCase);
        var reason = allowed ? "allowed by default policy" : "action not allowed";

        return Task.FromResult(new PermissionCheckResult { Allowed = allowed, Reason = reason });
    }
}
