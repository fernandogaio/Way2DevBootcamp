using AutoMapper;
using MediatR;
using Way2DevBootcamp.Application.Core;
using Way2DevBootcamp.Application.Core.Notifications;
using Way2DevBootcamp.Application.Usuarios.Commands;
using Way2DevBootcamp.Application.ViewModels;
using Way2DevBootcamp.Identity.Enumerators;
using Way2DevBootcamp.Identity.Interfaces;

namespace Way2DevBootcamp.Application.Usuarios.CommandHandlers;
public class RefreshLoginUsuarioCommandHandler : IRequestHandler<RefreshLoginUsuarioCommand, CommandResponse> {
    private readonly IIdentityService _identityService;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public RefreshLoginUsuarioCommandHandler(IIdentityService identityService,
                                             IMediator mediator,
                                             IMapper mapper) {
        _identityService = identityService;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<CommandResponse> Handle(RefreshLoginUsuarioCommand command, CancellationToken cancellationToken) {
        try {
            var result = await _identityService.LoginWithoutPassword(command.UsuarioId);

            if (result.Error != null) {
                if (result.Error == EnumLoginResultErrors.IsLockedOut)
                    return new CommandResponse().AddError("Essa conta está bloqueada.");
                else
                    return new CommandResponse().AddError("Essa conta precisa confirmar seu e-mail antes de realizar o login.");
            }

            return new CommandResponse(_mapper.Map<LoginViewModel>(result));
        } catch (Exception) {
            var msg = "Ocorreu um erro no momento da criação";
            await _mediator.Publish(new ErrorNotification().AddError(msg), cancellationToken);
            return new CommandResponse().AddError(msg);
        }
    }
}