using MediatR;
using Way2DevBootcamp.Application.Produtos.ViewModels;

namespace Way2DevBootcamp.Application.Produtos.Queries;
public class GetProdutoByIdQuery : IRequest<ProdutoViewModel> {
    public int Id { get; private set; }

    public GetProdutoByIdQuery(int id)
        => Id = id;
}