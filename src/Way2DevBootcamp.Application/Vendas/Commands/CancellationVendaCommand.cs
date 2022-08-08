using MediatR;
using Way2DevBootcamp.Application.Core;

namespace Way2DevBootcamp.Application.Vendas.Commands;
public class CancellationVendaCommand : IRequest<CommandResponse> {
    public int Id { get; private set; }

    public CancellationVendaCommand(int id)
        => Id = id;
}