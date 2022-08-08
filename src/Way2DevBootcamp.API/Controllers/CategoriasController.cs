using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Way2DevBootcamp.Application.Categorias.Queries;
using Way2DevBootcamp.Application.Categorias.ViewModels;

namespace Way2DevBootcamp.API.Controllers {
    [Authorize]
    [ApiController]
    [Route("v1/categorias")]
    public class CategoriasController : ControllerBase {
        private readonly ISender _sender;

        public CategoriasController(ISender sender)
            => _sender = sender;

        /// <summary>
        /// Retorna todas as categorias
        /// </summary>
        /// <returns>Response com todas as categorias</returns>
        /// <response code="200">Retorna todas as categorias</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CategoriaViewModel>))]
        public async Task<ActionResult<IEnumerable<CategoriaViewModel>>> Get() {
            var query = new GetCategoriasQuery();
            return Ok(await _sender.Send(query));
        }

        /// <summary>
        /// Retorna uma categoria por Id
        /// </summary>
        /// <param name="id">Id da categoria</param>
        /// <returns>Response com a categoria</returns>
        /// <response code="200">Retorna a categoria</response>
        /// <response code="404">Caso não encontre a categoria</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoriaViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoriaViewModel>> GetById(int id) {
            var query = new GetCategoriaByIdQuery(id);
            var categoria = await _sender.Send(query);

            if (categoria is null)
                return NotFound();

            return Ok(categoria);
        }
    }
}