using MediatR;
using Way2DevBootcamp.Application.Categorias.ViewModels;

namespace Way2DevBootcamp.Application.Categorias.Queries;
public class GetCategoriasQuery : IRequest<IEnumerable<CategoriaViewModel>> { }