using AutoMapper;
using MediatR;
using Way2DevBootcamp.Application.Produtos.Queries;
using Way2DevBootcamp.Application.Produtos.ViewModels;
using Way2DevBootcamp.Domain.Interfaces;

namespace Way2DevBootcamp.Application.Produtos.QueryHandlers;
public class GetProdutoByIdQueryHandler : IRequestHandler<GetProdutoByIdQuery, ProdutoViewModel> {
    public readonly IUnitOfWork _uow;
    public readonly IMapper _mapper;

    public GetProdutoByIdQueryHandler(IUnitOfWork uow, IMapper mapper) {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<ProdutoViewModel> Handle(GetProdutoByIdQuery query, CancellationToken cancellationToken)
        => _mapper.Map<ProdutoViewModel>(await _uow.Produtos.GetById(query.Id));
}