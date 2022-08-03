using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Way2DevBootcamp.Application.Commands;
using Way2DevBootcamp.Application.Queries;
using Way2DevBootcamp.Application.ViewModels;
using Way2DevBootcamp.Identity;

namespace Way2DevBootcamp.API.Controllers;
[Authorize(Roles = Roles.Admin)]
[ApiController]
[Route("v1/produtos")]
public class ProdutosController : ControllerBase {
    private readonly ISender _sender;

    public ProdutosController(ISender sender)
        => _sender = sender;

    /// <summary>
    /// Retorna todos os produtos.
    /// </summary>
    /// <returns>Response com todos os produtos</returns>
    /// <response code="200">Retorna todos os produtos</response>
    [HttpGet, AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProdutoViewModel>))]
    public async Task<ActionResult<IEnumerable<ProdutoViewModel>>> Get() {
        var query = new GetProdutosQuery();
        return Ok(await _sender.Send(query));
    }

    /// <summary>
    /// Retorna um produto por Id
    /// </summary>
    /// <param name="id">Id do produto</param>
    /// <returns>Response com o produto</returns>
    /// <response code="200">Retorna o produto</response>
    /// <response code="404">Caso não encontre o produto</response>
    [HttpGet("{id}"), AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProdutoViewModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProdutoViewModel>> GetById(int id) {
        var query = new GetProdutoByIdQuery { Id = id };

        if (query is null)
            return NotFound();

        return Ok(await _sender.Send(query));
    }

    /// <summary>
    /// Cria um novo produto
    /// </summary>
    /// <param name="command">Produto a ser criado</param>
    /// <returns>Response com novo produto</returns>
    /// <response code="201">Produto criado com sucesso</response>
    /// <response code="400">Erro na requisição</response>
    [HttpPost, AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Create([FromBody] CreateProdutoCommand command) {
        var response = await _sender.Send(command);

        if (response.Errors.Any())
            return BadRequest(response.Errors);

        return Created(nameof(GetById), new { id = response });
    }

    /// <summary>
    /// Altera um produto
    /// </summary>
    /// <param name="id">Id do produto a ser alterado</param>
    /// <param name="command">Produto a ser alterado</param>
    /// <response code="200">Produto criado com sucesso</response>
    /// <response code="400">Erro na requisição</response>
    /// <response code="404">Produto não encontrado</response>
    [HttpPut("{id}"), AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Update(int id, [FromBody] UpdateProdutoCommand command) {
        command.SetId(id);
        var response = await _sender.Send(command);

        if (response.Errors.Any())
            return BadRequest(response.Errors);

        return Ok(response);
    }

    /// <summary>
    /// Remove um produto
    /// </summary>
    /// <param name="id">Id do produto a ser removido</param>
    /// <response code="204">Produto removido</response>
    /// <response code="404">Produto não encontrado</response>
    [HttpDelete("{id}"), AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id) {
        var command = new DeleteProdutoCommand { Id = id };
        await _sender.Send(command);

        return NoContent();
    }
}