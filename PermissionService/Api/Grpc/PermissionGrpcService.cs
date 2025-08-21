using Application.Interfaces;
using Grpc.Core;

namespace Api.Grpc;

public class PermissionGrpcService(IPermissionService permissionService)
    : PermissionService.PermissionServiceBase
{
    private readonly IPermissionService _permissionService = permissionService;

    public override async Task<PermissionCheckResult> Check(
        PermissionCheckRequest request,
        ServerCallContext context
    )
    {
        var id = Guid.TryParse(request.SubjectId, out var parsedId) ? parsedId : Guid.Empty;

        if (id == Guid.Empty)
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid SubjectId"));

        var dto = new Application.Dtos.PermissionCheckRequest
        {
            SubjectId = id,
            Resource = request.Resource,
            Action = request.Action,
        };

        var result = await _permissionService.CheckPermissionAsync(dto);

        return new PermissionCheckResult { Allowed = result.Allowed, Reason = result.Reason };
    }
}
