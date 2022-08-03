using MediatR;
using Way2DevBootcamp.Application.Core;

namespace Way2DevBootcamp.Application.Commands;
public class DeleteProdutoCommand : IRequest<CommandResponse> {
    public int Id { get; set; }
}