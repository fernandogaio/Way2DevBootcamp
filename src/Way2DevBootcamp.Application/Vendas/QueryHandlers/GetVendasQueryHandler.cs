using AutoMapper;
using MediatR;
using Way2DevBootcamp.Application.Vendas.Queries;
using Way2DevBootcamp.Application.Vendas.ViewModels;
using Way2DevBootcamp.Domain.Interfaces;

namespace Way2DevBootcamp.Application.Vendas.QueryHandlers;
public class GetVendasQueryHandler : IRequestHandler<GetVendasQuery, IEnumerable<VendaViewModel>> {
    public readonly IUnitOfWork _uow;
    public readonly IMapper _mapper;

    public GetVendasQueryHandler(IUnitOfWork uow, IMapper mapper) {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<IEnumerable<VendaViewModel>> Handle(GetVendasQuery query, CancellationToken cancellationToken)
        => _mapper.Map<IEnumerable<VendaViewModel>>(await _uow.Vendas.GetAll());
}