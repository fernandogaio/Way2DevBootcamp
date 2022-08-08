using MediatR;
using Way2DevBootcamp.Application.Core;
using Way2DevBootcamp.Application.Vendas.Commands;
using Way2DevBootcamp.Domain.Interfaces;

namespace Way2DevBootcamp.Application.Vendas.CommandHandlers;
public class CancellationVendaCommandHandler : IRequestHandler<CancellationVendaCommand, CommandResponse> {
    private readonly IUnitOfWork _uow;

    public CancellationVendaCommandHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<CommandResponse> Handle(CancellationVendaCommand command, CancellationToken cancellationToken) {
        var venda = await _uow.Vendas.GetById(command.Id);

        if (venda is null)
            return new CommandResponse().AddError("Venda não encontrada!");

        venda.Cancel();

        _uow.Vendas.Update(venda);
        await _uow.Commit();

        return new CommandResponse("Venda cancelada com sucesso!");
    }
}