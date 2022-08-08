using MediatR;
using Way2DevBootcamp.Application.Vendas.ViewModels;

namespace Way2DevBootcamp.Application.Vendas.Queries;
public class GetVendaByIdQuery : IRequest<VendaViewModel> {
    public int Id { get; private set; }

    public GetVendaByIdQuery(int id)
        => Id = id;
}