using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Way2DevBootcamp.Application.Commands;
using Way2DevBootcamp.Application.Queries;
using Way2DevBootcamp.Application.ViewModels;

namespace Way2DevBootcamp.API.Controllers;
[Authorize]
[ApiController]
[Route("v1/vendas")]
public class VendasController : ControllerBase {
    private readonly ISender _sender;

    public VendasController(ISender sender)
        => _sender = sender;

    /// <summary>
    /// Retorna todas as vendas.
    /// </summary>
    /// <returns>Response com todas as vendas</returns>
    /// <response code="200">Retorna todas as vendas</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<VendaViewModel>))]
    public async Task<ActionResult<IEnumerable<VendaViewModel>>> Get() {
        var query = new GetVendasQuery();
        return Ok(await _sender.Send(query));
    }

    /// <summary>
    /// Retorna uma venda por Id
    /// </summary>
    /// <param name="id">Id da venda</param>
    /// <returns>Response com a venda</returns>
    /// <response code="200">Retorna a venda</response>
    /// <response code="404">Caso não encontre a venda</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VendaViewModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<VendaViewModel>> GetById(int id) {
        var query = new GetVendaByIdQuery(id);
        var venda = await _sender.Send(query);

        if (venda is null)
            return NotFound();

        return Ok(venda);
    }

    /// <summary>
    /// Cria uma nova venda
    /// </summary>
    /// <param name="command">Venda a ser criada</param>
    /// <returns>Response com nova venda</returns>
    /// <response code="201">Venda criado com sucesso</response>
    /// <response code="400">Erro na requisição</response>
    [HttpPost()]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Create([FromBody] CreateVendaCommand command) {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        var usuarioId = identity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        command.SetUsuarioId(usuarioId);
        var response = await _sender.Send(command);

        if(response.Errors.Any())
            return BadRequest(response.Errors);

        return Created(nameof(GetById), new { id = response.Result });
    }
}