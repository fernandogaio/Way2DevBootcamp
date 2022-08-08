using MediatR;
using Way2DevBootcamp.Application.Core;

namespace Way2DevBootcamp.Application.Usuarios.Commands;
public class LoginUsuarioCommand : IRequest<CommandResponse> {
    public string Email { get; set; }
    public string Senha { get; set; }
}