using MediatR;
using Way2DevBootcamp.Application.Vendas.ViewModels;

namespace Way2DevBootcamp.Application.Vendas.Queries;
public class GetVendasQuery : IRequest<IEnumerable<VendaViewModel>> { }