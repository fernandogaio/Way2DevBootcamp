using MediatR;
using Way2DevBootcamp.Application.ViewModels;

namespace Way2DevBootcamp.Application.Queries;
public class GetProdutosQuery : IRequest<IEnumerable<ProdutoViewModel>> { }