using AutoMapper;
using MediatR;
using Way2DevBootcamp.Application.Categorias.Queries;
using Way2DevBootcamp.Application.Categorias.ViewModels;
using Way2DevBootcamp.Domain.Interfaces;

namespace Way2DevBootcamp.Application.Categorias.QueryHandlers;
public class GetCategoriaByIdQueryHandler : IRequestHandler<GetCategoriaByIdQuery, CategoriaViewModel> {
    public readonly IUnitOfWork _uow;
    public readonly IMapper _mapper;

    public GetCategoriaByIdQueryHandler(IUnitOfWork uow, IMapper mapper) {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<CategoriaViewModel?> Handle(GetCategoriaByIdQuery query, CancellationToken cancellationToken) {
        if (!await _uow.Categorias.Exists(query.Id))
            return null;

        return _mapper.Map<CategoriaViewModel>(await _uow.Categorias.GetById(query.Id));
    }
}