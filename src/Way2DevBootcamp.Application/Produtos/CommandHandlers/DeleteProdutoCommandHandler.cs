using MediatR;
using Way2DevBootcamp.Application.Core;
using Way2DevBootcamp.Application.Produtos.Commands;
using Way2DevBootcamp.Domain.Interfaces;

namespace Way2DevBootcamp.Application.Produtos.CommandHandlers;
public class DeleteProdutoCommandHandler : IRequestHandler<DeleteProdutoCommand, CommandResponse> {
    private readonly IUnitOfWork _uow;

    public DeleteProdutoCommandHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<CommandResponse> Handle(DeleteProdutoCommand command, CancellationToken cancellationToken) {
        var produto = await _uow.Produtos.GetById(command.Id);

        if (produto is null)
            return new CommandResponse().AddError("Produto não encontrado!");

        _uow.Produtos.Delete(produto);
        await _uow.Commit();

        return new CommandResponse("Produto excluído com sucesso!");
    }
}