using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Way2DevBootcamp.Application.Usuarios.Commands;
using Way2DevBootcamp.Application.ViewModels;
using Way2DevBootcamp.Identity.Interfaces;

namespace Way2DevBootcamp.API.Controllers;
[ApiController]
[Route("v1/usuarios")]
public class UsuariosController : ControllerBase {
    private readonly IIdentityService _identityService;
    private readonly ISender _sender;

    public UsuariosController(IIdentityService identityService, ISender sender) { 
        _identityService = identityService;
        _sender = sender;
    }

    [HttpPost("create")]
    public async Task<ActionResult> Post([FromBody] CreateUsuarioCommand command) {
        var response = await _sender.Send(command);

        if (response.Errors.Any())
            return BadRequest(response.Errors);

        return Ok(response.Result);
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginViewModel>> Login([FromBody] LoginUsuarioCommand command) {
        var response = await _sender.Send(command);

        if (response.Errors.Any())
            return Unauthorized(response.Errors);

        return Ok(response.Result);
    }

    [Authorize]
    [HttpPost("refresh-login")]
    public async Task<ActionResult<LoginViewModel>> RefreshLogin() {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        var usuarioId = identity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (usuarioId is null)
            return BadRequest();

        var response = await _sender.Send(new RefreshLoginUsuarioCommand(usuarioId));

        if (response.Errors.Any())
            return Unauthorized(response.Errors);

        return Ok(response.Result);
    }
}