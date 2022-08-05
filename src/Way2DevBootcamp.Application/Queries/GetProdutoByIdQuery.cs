using MediatR;
using Way2DevBootcamp.Application.ViewModels;

namespace Way2DevBootcamp.Application.Queries;
public class GetProdutoByIdQuery : IRequest<ProdutoViewModel> {
    public int Id { get; private set; }

    public GetProdutoByIdQuery(int id)
        => Id = id;
}