using AutoMapper;
using MediatR;
using Way2DevBootcamp.Application.Queries;
using Way2DevBootcamp.Application.ViewModels;
using Way2DevBootcamp.Domain.Interfaces;

namespace Way2DevBootcamp.Application.QueryHandlers;
public class GetProdutoByIdQueryHandler : IRequestHandler<GetProdutoByIdQuery, ProdutoViewModel> {
    public readonly IUnitOfWork _uow;
    public readonly IMapper _mapper;

    public GetProdutoByIdQueryHandler(IUnitOfWork uow, IMapper mapper) {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<ProdutoViewModel?> Handle(GetProdutoByIdQuery query, CancellationToken cancellationToken) {
        if (!await _uow.Produtos.Exists(query.Id))
            return null;
        
        return _mapper.Map<ProdutoViewModel>(await _uow.Produtos.GetById(query.Id));
    }
}