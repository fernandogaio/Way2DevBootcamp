using FluentValidation;
using Way2DevBootcamp.Domain.Entities;

namespace Way2DevBootcamp.Domain.Validators;
public class CategoriaValidator : AbstractValidator<Categoria> {
    public CategoriaValidator() {
        RuleFor(x => x.Nome)
            .NotEmpty()
                .WithMessage("O campo Nome deve ser informado.")
            .MaximumLength(50)
                .WithMessage("Nome não deve conter mais de 50 caracteres.");
    }
}