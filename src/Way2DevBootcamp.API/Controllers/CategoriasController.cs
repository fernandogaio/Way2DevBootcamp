using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Way2DevBootcamp.API.ViewModels;
using Way2DevBootcamp.Domain.Interfaces;

namespace Way2DevBootcamp.API.Controllers {
    [ApiController]
    [Route("v1/categorias")]
    public class CategoriasController : ControllerBase {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CategoriasController(IUnitOfWork uow, IMapper mapper) {
            _uow = uow;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna todas as categorias
        /// </summary>
        /// <returns>Response com todas as categorias</returns>
        /// <response code="200">Retorna todas as categorias</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CategoriaViewModelOutput>))]
        public async Task<ActionResult<IEnumerable<CategoriaViewModelOutput>>> Get() {
            var categoriasViewModelOutput = _mapper.Map<IEnumerable<CategoriaViewModelOutput>>(await _uow.Categorias.GetAll());

            return Ok(categoriasViewModelOutput);
        }

        /// <summary>
        /// Retorna uma categoria por Id
        /// </summary>
        /// <param name="id">Id da categoria</param>
        /// <returns>Response com a categoria</returns>
        /// <response code="200">Retorna a categoria</response>
        /// <response code="404">Caso não encontre a categoria</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoriaViewModelOutput))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoriaViewModelOutput>> GetById(int id) {
            var categoria = await _uow.Categorias.GetById(id);

            if (categoria == null) {
                return NotFound();
            }

            var categoriaViewModelOutput = _mapper.Map<CategoriaViewModelOutput>(categoria);

            return Ok(categoriaViewModelOutput);
        }
    }
}