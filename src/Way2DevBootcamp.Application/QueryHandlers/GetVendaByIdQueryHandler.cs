using AutoMapper;
using MediatR;
using Way2DevBootcamp.Application.Queries;
using Way2DevBootcamp.Application.ViewModels;
using Way2DevBootcamp.Domain.Interfaces;

namespace Way2DevBootcamp.Application.QueryHandlers;
public class GetVendaByIdQueryHandler : IRequestHandler<GetVendaByIdQuery, VendaViewModel> {
    public readonly IUnitOfWork _uow;
    public readonly IMapper _mapper;

    public GetVendaByIdQueryHandler(IUnitOfWork uow, IMapper mapper) {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<VendaViewModel> Handle(GetVendaByIdQuery query, CancellationToken cancellationToken) {
        if (!await _uow.Vendas.Exists(query.Id))
            return null;

        return _mapper.Map<VendaViewModel>(await _uow.Vendas.GetById(query.Id));
    }
}