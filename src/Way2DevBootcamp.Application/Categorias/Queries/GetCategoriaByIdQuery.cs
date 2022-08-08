using MediatR;
using Way2DevBootcamp.Application.Categorias.ViewModels;

namespace Way2DevBootcamp.Application.Categorias.Queries;
public class GetCategoriaByIdQuery : IRequest<CategoriaViewModel> {
    public int Id { get; private set; }

    public GetCategoriaByIdQuery(int id)
        => Id = id;
}