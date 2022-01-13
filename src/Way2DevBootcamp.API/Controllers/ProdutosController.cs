using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Way2DevBootcamp.API.ViewModels;
using Way2DevBootcamp.Domain.Entities;
using Way2DevBootcamp.Domain.Interfaces;

namespace Way2DevBootcamp.API.Controllers {
    [ApiController]
    [Route("v1/produtos")]
    public class ProdutosController : ControllerBase {
        private readonly IProdutoService _service;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoService service, IMapper mapper) {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna todos os produtos.
        /// </summary>
        /// <returns>Response com todos os produtos</returns>
        /// <response code="200">Retorna todos os produtos</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProdutoViewModelOutput>))]
        public async Task<ActionResult<IEnumerable<ProdutoViewModelOutput>>> Get() {
            var produtosOutput = _mapper.Map<IEnumerable<ProdutoViewModelOutput>>(await _service.GetAll());

            return Ok(produtosOutput);
        }

        /// <summary>
        /// Retorna um produto por Id
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns>Response com o produto</returns>
        /// <response code="200">Retorna o produto</response>
        /// <response code="404">Caso não encontre o produto</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProdutoViewModelOutput))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProdutoViewModelOutput>> GetById(int id) {
            var produto = await _service.GetById(id);

            if (produto == null) {
                return NotFound();
            }

            var produtoOutput = _mapper.Map<ProdutoViewModelOutput>(produto);
            return Ok(produtoOutput);
        }

        /// <summary>
        /// Cria um novo produto
        /// </summary>
        /// <param name="produtoViewModelInput">Produto a ser criado</param>
        /// <returns>Response com novo produto</returns>
        /// <response code="201">Produto criado com sucesso</response>
        /// <response code="400">Erro na requisição</response>
        [HttpPost("criar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create([FromBody] ProdutoViewModelInput produtoViewModelInput) {
            try {
                var produto = _mapper.Map<Produto>(produtoViewModelInput);

                await _service.Create(produto);

                return Created(nameof(GetById), new { id = produto.Id });
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Altera um produto
        /// </summary>
        /// <param name="id">Id do produto a ser alterado</param>
        /// <param name="produtoViewModelInput">Produto a ser alterado</param>
        /// <response code="200">Produto criado com sucesso</response>
        /// <response code="400">Erro na requisição</response>
        /// <response code="404">Produto não encontrado</response>
        [HttpPut("alterar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Edit(int id, [FromBody] ProdutoViewModelInput produtoViewModel) {
            try {
                produtoViewModel.AtribuiId(id);
                var produto = await _service.GetById(id);

                if (produto == null) {
                    return NotFound();
                }

                _mapper.Map(produtoViewModel, produto);

                await _service.Edit(produto);
                return Ok();
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Remove um produto
        /// </summary>
        /// <param name="id">Id do produto a ser removido</param>
        /// <response code="204">Produto removido</response>
        /// <response code="404">Produto não encontrado</response>
        [HttpDelete("remover/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id) {
            var produto = await _service.GetById(id);

            if (produto == null) {
                return NotFound();
            }

            await _service.Delete(produto);

            return NoContent();
        }
    }
}