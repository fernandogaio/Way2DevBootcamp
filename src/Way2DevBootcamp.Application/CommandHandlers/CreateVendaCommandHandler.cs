using AutoMapper;
using MediatR;
using Way2DevBootcamp.Application.Commands;
using Way2DevBootcamp.Application.Core;
using Way2DevBootcamp.Application.Events;
using Way2DevBootcamp.Application.Notifications;
using Way2DevBootcamp.Domain.Entities;
using Way2DevBootcamp.Domain.Enumerators;
using Way2DevBootcamp.Domain.Interfaces;

namespace Way2DevBootcamp.Application.CommandHandlers;
public class CreateVendaCommandHandler : IRequestHandler<CreateVendaCommand, CommandResponse> {
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _uow;
    private readonly IMediator _mediator;

    public CreateVendaCommandHandler(IMapper mapper,
                                     IUnitOfWork uow,
                                     IMediator mediator) {
        _mapper = mapper;
        _uow = uow;
        _mediator = mediator;
    }

    public async Task<CommandResponse> Handle(CreateVendaCommand command, CancellationToken cancellationToken) {
        try {
            var venda = new Venda(command.UsuarioId, EnumStatusPedido.Pendente);
            venda.AddItens(_mapper.Map<IEnumerable<VendaItem>>(command.Itens));

            await _uow.Vendas.Add(venda);
            await _uow.Commit();

            await _mediator.Publish(new VendaCreatedEvent(venda.Id), cancellationToken);
            return new CommandResponse(venda.Id);
        } catch (Exception) {
            var msg = "Ocorreu um erro no momento da criação";
            await _mediator.Publish(new ErrorNotification().AddError(msg), cancellationToken);
            return new CommandResponse().AddError(msg);
        }
    }
}