using MediatR;
using Way2DevBootcamp.Application.Core;

namespace Way2DevBootcamp.Application.Usuarios.Commands;
public class RefreshLoginUsuarioCommand : IRequest<CommandResponse> {
    public string UsuarioId { get; private set; }

    public RefreshLoginUsuarioCommand(string usuarioId)
        => UsuarioId = usuarioId;
}