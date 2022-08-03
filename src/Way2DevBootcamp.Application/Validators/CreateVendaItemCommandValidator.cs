using FluentValidation;
using Way2DevBootcamp.Application.Commands;
using Way2DevBootcamp.Domain.Interfaces;

namespace Way2DevBootcamp.Application.Validators;
public class CreateVendaItemCommandValidator : AbstractValidator<CreateVendaItemCommand> {
    private readonly IUnitOfWork _uow;

    public CreateVendaItemCommandValidator(IUnitOfWork uow) {
        _uow = uow;

        RuleFor(p => p.Preco)
            .NotEmpty()
            .WithMessage("O preço deve ser maior que 0.");

        RuleFor(p => p.Quantidade)
            .NotEmpty().WithMessage("Campo quantidade é obrigatório.");

        RuleFor(x => x.ProdutoId)
            .NotEmpty()
                .WithMessage("O produto deve ser informado.")
            .MustAsync(async (produtoId, cancellation) => await _uow.Produtos.Exists(produtoId))
                .WithMessage("O produto informado não existe");
    }
}