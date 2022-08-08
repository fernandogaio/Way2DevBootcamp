using MediatR;
using Microsoft.AspNetCore.Identity;
using Way2DevBootcamp.Application.Core;
using Way2DevBootcamp.Application.Core.Notifications;
using Way2DevBootcamp.Application.Usuarios.Commands;
using Way2DevBootcamp.Application.Usuarios.Events;
using Way2DevBootcamp.Identity.Interfaces;

namespace Way2DevBootcamp.Application.Usuarios.CommandHandlers;
public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, CommandResponse> {
    private readonly IIdentityService _identityService;
    private readonly IMediator _mediator;

    public CreateUsuarioCommandHandler(IIdentityService identityService,
                                       IMediator mediator) {
        _identityService = identityService;
        _mediator = mediator;
    }

    public async Task<CommandResponse> Handle(CreateUsuarioCommand command, CancellationToken cancellationToken) {
        try {
            var identityUser = new IdentityUser {
                UserName = command.Email,
                Email = command.Email,
                EmailConfirmed = true
            };

            var result = await _identityService.AddUser(identityUser, command.Senha);

            if (!result.Succeeded && result.Errors.Any())
                return new CommandResponse().AddErrors(result.Errors.Select(r => r.Description));

            await _mediator.Publish(new UsuarioCreatedEvent(identityUser.Id), cancellationToken);
            return new CommandResponse(identityUser.Id);
        } catch (Exception) {
            var msg = "Ocorreu um erro no momento da criação";
            await _mediator.Publish(new ErrorNotification().AddError(msg), cancellationToken);
            return new CommandResponse().AddError(msg);
        }
    }
}