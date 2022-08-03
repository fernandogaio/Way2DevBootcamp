using MediatR;
using Way2DevBootcamp.Application.ViewModels;

namespace Way2DevBootcamp.Application.Queries;
public class GetVendaByIdQuery : IRequest<VendaViewModel> {
    public int Id { get; set; }
}