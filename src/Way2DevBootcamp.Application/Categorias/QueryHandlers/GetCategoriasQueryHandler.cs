using AutoMapper;
using MediatR;
using Way2DevBootcamp.Application.Categorias.Queries;
using Way2DevBootcamp.Application.Categorias.ViewModels;
using Way2DevBootcamp.Domain.Interfaces;

namespace Way2DevBootcamp.Application.Categorias.QueryHandlers;
public class GetCategoriasQueryHandler : IRequestHandler<GetCategoriasQuery, IEnumerable<CategoriaViewModel>> {
    public readonly IUnitOfWork _uow;
    public readonly IMapper _mapper;

    public GetCategoriasQueryHandler(IUnitOfWork uow, IMapper mapper) {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoriaViewModel>> Handle(GetCategoriasQuery query, CancellationToken cancellationToken)
        => _mapper.Map<IEnumerable<CategoriaViewModel>>(await _uow.Categorias.GetAll());
}