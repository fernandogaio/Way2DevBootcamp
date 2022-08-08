using AutoMapper;
using MediatR;
using Way2DevBootcamp.Application.Produtos.Queries;
using Way2DevBootcamp.Application.Produtos.ViewModels;
using Way2DevBootcamp.Domain.Interfaces;

namespace Way2DevBootcamp.Application.Produtos.QueryHandlers;
public class GetProdutosQueryHandler : IRequestHandler<GetProdutosQuery, IEnumerable<ProdutoViewModel>> {
    public readonly IUnitOfWork _uow;
    public readonly IMapper _mapper;

    public GetProdutosQueryHandler(IUnitOfWork uow, IMapper mapper) {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProdutoViewModel>> Handle(GetProdutosQuery query, CancellationToken cancellationToken)
        => _mapper.Map<IEnumerable<ProdutoViewModel>>(await _uow.Produtos.GetAll());
}