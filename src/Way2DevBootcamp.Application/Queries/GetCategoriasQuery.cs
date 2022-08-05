using MediatR;
using Way2DevBootcamp.Application.ViewModels;

namespace Way2DevBootcamp.Application.Queries;
public class GetCategoriasQuery : IRequest<IEnumerable<CategoriaViewModel>> { }