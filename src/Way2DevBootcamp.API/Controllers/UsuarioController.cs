using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Way2DevBootcamp.Application.Interfaces;
using Way2DevBootcamp.Application.ViewModels;

namespace Way2DevBootcamp.API.Controllers;
[ApiController]
[Route("v1/usuarios")]
public class UsuariosController : ControllerBase {
    private readonly IIdentityService _identityService;

    public UsuariosController(IIdentityService identityService) =>
        _identityService = identityService;

    [HttpPost("cadastro")]
    public async Task<ActionResult<UsuarioViewModelOutput>> Cadastrar(UsuarioViewModelInput usuarioCadastro) {
        if (!ModelState.IsValid)
            return BadRequest();

        var resultado = await _identityService.CadastrarUsuario(usuarioCadastro);
        if (resultado.Sucesso)
            return Ok(resultado);
        else if (resultado.Erros.Count > 0)
            return BadRequest(resultado);

        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpPost("login")]
    public async Task<ActionResult<UsuarioLoginViewModelOutput>> Login(UsuarioLoginViewModelInput usuarioLogin) {
        if (!ModelState.IsValid)
            return BadRequest();

        var resultado = await _identityService.Login(usuarioLogin);
        if (resultado.Sucesso)
            return Ok(resultado);

        return Unauthorized(resultado);
    }

    [Authorize]
    [HttpPost("refresh-login")]
    public async Task<ActionResult<UsuarioViewModelOutput>> RefreshLogin() {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        var usuarioId = identity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (usuarioId is null)
            return BadRequest();

        var resultado = await _identityService.LoginSemSenha(usuarioId);
        if (resultado.Sucesso)
            return Ok(resultado);

        return Unauthorized(resultado);
    }
}