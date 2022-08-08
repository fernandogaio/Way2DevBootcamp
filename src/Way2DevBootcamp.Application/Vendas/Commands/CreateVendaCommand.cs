using MediatR;
using Way2DevBootcamp.Application.Core;

namespace Way2DevBootcamp.Application.Vendas.Commands;
public class CreateVendaCommand : IRequest<CommandResponse> {
    public Guid UsuarioId { get; private set; }
    public IEnumerable<CreateVendaItemCommand> Itens { get; set; }

    public void SetUsuarioId(string usuarioId)
        => UsuarioId = Guid.Parse(usuarioId);
}