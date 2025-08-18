using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("permissions")]
public class PermissionController : ControllerBase
{
    private readonly IPermissionService _permissionService;

    public PermissionController(IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }

    [HttpPost("check")]
    public async Task<IActionResult> Check([FromBody] PermissionCheckRequest request)
    {
        var result = await _permissionService.CheckPermissionAsync(request);
        return Ok(new { allowed = result.Allowed, reason = result.Reason });
    }
}
