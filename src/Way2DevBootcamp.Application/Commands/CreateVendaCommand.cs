using MediatR;
using Way2DevBootcamp.Application.Core;

namespace Way2DevBootcamp.Application.Commands;
public class CreateVendaCommand : IRequest<CommandResponse> {
    public Guid UsuarioId { get; set; }
    public ICollection<CreateVendaItemCommand> Itens { get; set; }

    public void SetUsuarioId(string usuarioId)
        => UsuarioId = Guid.Parse(usuarioId);
}