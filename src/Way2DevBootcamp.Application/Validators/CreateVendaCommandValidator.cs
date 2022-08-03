using FluentValidation;
using Way2DevBootcamp.Application.Commands;
using Way2DevBootcamp.Domain.Interfaces;

namespace Way2DevBootcamp.Application.Validators;
public class CreateVendaCommandValidator : AbstractValidator<CreateVendaCommand> {
    public CreateVendaCommandValidator(IUnitOfWork uow) {
        RuleFor(p => p.Itens)
            .NotEmpty().WithMessage("É necessário adicionar pelo menos 1 item.");
        
        RuleForEach(p => p.Itens)
            .SetValidator(new CreateVendaItemCommandValidator(uow));
    }
}