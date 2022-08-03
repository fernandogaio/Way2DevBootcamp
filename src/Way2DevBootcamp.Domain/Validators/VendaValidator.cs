using FluentValidation;
using Way2DevBootcamp.Domain.Entities;

namespace Way2DevBootcamp.Domain.Validators;
public class VendaValidator : AbstractValidator<Venda> {
    public VendaValidator() {
        //RuleFor(x => x.UsuarioId)
        //    .NotEmpty().WithMessage("A usuário deve ser informado.");

        RuleFor(p => p.StatusPedido)
            .NotEmpty().WithMessage("Campo status do pedido é obrigatório.");

        RuleFor(p => p.ValorTotal)
            .NotEmpty()
            .WithMessage("O valor total deve ser maior que 0.");
    }
}