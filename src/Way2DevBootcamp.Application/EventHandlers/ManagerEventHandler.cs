using MediatR;
using Way2DevBootcamp.Application.Events;

namespace Way2DevBootcamp.Application.EventHandlers;
public class ManagerEventHandler : INotificationHandler<ProdutoCreatedEvent>,
                                   INotificationHandler<VendaCreatedEvent> {
    public Task Handle(ProdutoCreatedEvent produtoCreatedEvent, CancellationToken cancellationToken) {
        return Task.Run(() => {
            Console.WriteLine($"Produto com o ID {produtoCreatedEvent.Id} criado com sucesso!");
        }, cancellationToken);
    }

    public Task Handle(VendaCreatedEvent vendaCreatedEvent, CancellationToken cancellationToken) {
        return Task.Run(() => {
            Console.WriteLine($"Venda com o ID {vendaCreatedEvent.Id} criada com sucesso!");
        }, cancellationToken);
    }
}