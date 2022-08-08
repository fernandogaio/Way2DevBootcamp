using MediatR;
using Way2DevBootcamp.Application.Produtos.ViewModels;

namespace Way2DevBootcamp.Application.Produtos.Queries;
public class GetProdutosQuery : IRequest<IEnumerable<ProdutoViewModel>> { }