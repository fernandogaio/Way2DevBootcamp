using MediatR;
using Way2DevBootcamp.Application.Core;

namespace Way2DevBootcamp.Application.Produtos.Commands;
public class DeleteProdutoCommand : IRequest<CommandResponse> {
    public int Id { get; private set; }

    public DeleteProdutoCommand(int id)
        => Id = id;
}