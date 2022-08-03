using System;
using FluentValidation;
using Way2DevBootcamp.Domain.Entities;
using Way2DevBootcamp.Domain.Interfaces;

namespace Way2DevBootcamp.Domain.Validators;
public class VendaItemValidator : AbstractValidator<VendaItem> {
    private readonly IUnitOfWork _uow;

    public VendaItemValidator(IUnitOfWork uow) {
        _uow = uow;

        RuleFor(p => p.Preco)
            .NotEmpty()
            .WithMessage("O preço deve ser maior que 0.");

        RuleFor(p => p.Quantidade)
            .NotEmpty().WithMessage("Campo quantidade é obrigatório.");

        RuleFor(x => x.VendaId)
            .NotEmpty()
                .WithMessage("A venda deve ser informada.")
            .MustAsync(async (vendaId, cancellation) => await _uow.Vendas.Exists(vendaId))
                .WithMessage("A venda informada não existe");
        
        RuleFor(x => x.ProdutoId)
            .NotEmpty()
                .WithMessage("O produto deve ser informado.")
            .MustAsync(async (produtoId, cancellation) => await _uow.Produtos.Exists(produtoId))
                .WithMessage("O produto informado não existe");
    }
}