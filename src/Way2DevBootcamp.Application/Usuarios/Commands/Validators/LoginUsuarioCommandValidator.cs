using FluentValidation;

namespace Way2DevBootcamp.Application.Usuarios.Commands.Validators;
public class LoginUsuarioCommandValidator : AbstractValidator<LoginUsuarioCommand> {
    public LoginUsuarioCommandValidator() {
        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("Email é obrigatório.")
            .EmailAddress().WithMessage("Email inválido.");

        RuleFor(u => u.Senha)
            .NotEmpty().WithMessage("A senha é obrigatória.");
    }
}