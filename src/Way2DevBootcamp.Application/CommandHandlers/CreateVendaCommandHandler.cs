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
    private readonly IUnitOfWork _uow;
    private readonly IMediator _mediator;

    public CreateVendaCommandHandler(IUnitOfWork uow,
                                     IMediator mediator) {
        _uow = uow;
        _mediator = mediator;
    }

    public async Task<CommandResponse> Handle(CreateVendaCommand command, CancellationToken cancellationToken) {
        try {
            var venda = new Venda(command.UsuarioId,
                                  DateTime.Now,
                                  EnumStatusPedido.Pendente,
                                  SomarValorTotal(command));

            await _uow.BeginTransaction();

            await _uow.Vendas.Add(venda);
            await _uow.Commit();
            await AdicionarItens(command, venda);

            await _uow.EndTransaction();

            await _mediator.Publish(new VendaCreatedEvent(venda.Id), cancellationToken);
            return new CommandResponse(venda.Id);
        } catch (Exception) {
            var msg = "Ocorreu um erro no momento da criação";
            await _mediator.Publish(new ErrorNotification().AddError(msg), cancellationToken);
            return new CommandResponse().AddError(msg);
        }
    }

    private double SomarValorTotal(CreateVendaCommand command) {
        double valorTotal = 0;
        foreach (var item in command.Itens)
            valorTotal += item.Preco * item.Quantidade;

        return valorTotal;
    }

    private async Task AdicionarItens(CreateVendaCommand command, Venda venda) {
        foreach (var item in command.Itens) {
            await _uow.VendaItens.Add(new VendaItem(item.Preco,
                                                    item.Quantidade,
                                                    item.ProdutoId,
                                                    venda.Id));
        }
        await _uow.Commit();
    }
}