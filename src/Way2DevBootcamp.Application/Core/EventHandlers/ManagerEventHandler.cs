using MediatR;
using Way2DevBootcamp.Application.Produtos.Events;
using Way2DevBootcamp.Application.Usuarios.Events;
using Way2DevBootcamp.Application.Vendas.Events;

namespace Way2DevBootcamp.Application.Core.EventHandlers;
public class ManagerEventHandler : INotificationHandler<ProdutoCreatedEvent>,
                                   INotificationHandler<VendaCreatedEvent>,
                                   INotificationHandler<UsuarioCreatedEvent> {
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

    public Task Handle(UsuarioCreatedEvent usuarioCreatedEvent, CancellationToken cancellationToken) {
        return Task.Run(() => {
            Console.WriteLine($"Usuário com o ID {usuarioCreatedEvent.Id} criado com sucesso!");
        }, cancellationToken);
    }
}