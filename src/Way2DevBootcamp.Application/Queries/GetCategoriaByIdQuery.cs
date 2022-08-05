using MediatR;
using Way2DevBootcamp.Application.ViewModels;

namespace Way2DevBootcamp.Application.Queries;
public class GetCategoriaByIdQuery : IRequest<CategoriaViewModel> {
    public int Id { get; private set; }

    public GetCategoriaByIdQuery(int id)
        => Id = id;
}