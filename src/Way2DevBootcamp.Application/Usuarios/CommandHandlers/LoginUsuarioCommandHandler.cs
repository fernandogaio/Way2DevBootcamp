using AutoMapper;
using MediatR;
using Way2DevBootcamp.Application.Core;
using Way2DevBootcamp.Application.Core.Notifications;
using Way2DevBootcamp.Application.Usuarios.Commands;
using Way2DevBootcamp.Application.ViewModels;
using Way2DevBootcamp.Identity.Enumerators;
using Way2DevBootcamp.Identity.Interfaces;

namespace Way2DevBootcamp.Application.Usuarios.CommandHandlers;
public class LoginUsuarioCommandHandler : IRequestHandler<LoginUsuarioCommand, CommandResponse> {
    private readonly IIdentityService _identityService;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public LoginUsuarioCommandHandler(IIdentityService identityService,
                                      IMediator mediator,
                                      IMapper mapper) {
        _identityService = identityService;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<CommandResponse> Handle(LoginUsuarioCommand command, CancellationToken cancellationToken) {
        try {
            var result = await _identityService.Login(command.Email, command.Senha);

            if (result.Error != null) {
                switch (result.Error) {
                    case EnumLoginResultErrors.IsLockedOut:
                        return new CommandResponse().AddError("Essa conta está bloqueada.");
                    case EnumLoginResultErrors.IsNotAllowed:
                        return new CommandResponse().AddError("Essa conta não tem permissão para fazer login.");
                    case EnumLoginResultErrors.RequiresTwoFactor:
                        return new CommandResponse().AddError("É necessário confirmar o login no seu segundo fator de autenticação.");
                    case EnumLoginResultErrors.InvalidCredentials:
                        return new CommandResponse().AddError("Usuário ou senha estão incorretos.");
                }
            }

            return new CommandResponse(_mapper.Map<LoginViewModel>(result));
        } catch (Exception) {
            var msg = "Ocorreu um erro no momento da criação";
            await _mediator.Publish(new ErrorNotification().AddError(msg), cancellationToken);
            return new CommandResponse().AddError(msg);
        }
    }
}