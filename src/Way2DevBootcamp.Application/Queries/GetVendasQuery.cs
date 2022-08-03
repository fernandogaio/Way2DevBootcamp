using MediatR;
using Way2DevBootcamp.Application.ViewModels;

namespace Way2DevBootcamp.Application.Queries;
public class GetVendasQuery : IRequest<IEnumerable<VendaViewModel>> { }