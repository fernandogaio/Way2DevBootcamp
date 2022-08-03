using FluentValidation;
using Way2DevBootcamp.Application.Commands;
using Way2DevBootcamp.Domain.Interfaces;

namespace Way2DevBootcamp.Application.Validators;
public class CreateProdutoCommandValidator : AbstractValidator<CreateProdutoCommand> {
    private readonly IUnitOfWork _uow;

    public CreateProdutoCommandValidator(IUnitOfWork uow) {
        _uow = uow;

        RuleFor(p => p.Codigo)
            .NotEmpty().WithMessage("Campo código é obrigatório.")
            .MaximumLength(6).WithMessage("Código com tamanho maior do que o suportado.");

        RuleFor(p => p.Nome)
            .NotEmpty().WithMessage("Campo nome é obrigatório.")
            .MaximumLength(100).WithMessage("Nome com tamanho maior do que o suportado.");

        RuleFor(p => p.Descricao)
            .NotEmpty().WithMessage("Campo descrição é obrigatório.")
            .MaximumLength(500).WithMessage("Campo descrição com tamanho maior do que o suportado.");

        RuleFor(p => p.Preco)
            .NotEmpty()
            .WithMessage("O preço deve ser maior que 0.");

        RuleFor(x => x.CategoriaId)
            .NotEmpty()
                .WithMessage("A categoria deve ser informada.")
            .MustAsync(async (categoriaId, cancellation) => await _uow.Categorias.Exists(categoriaId))
                .WithMessage("A categoria informada não existe");
    }
}