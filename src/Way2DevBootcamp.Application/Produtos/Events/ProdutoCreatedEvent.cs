using MediatR;

namespace Way2DevBootcamp.Application.Produtos.Events;
public class ProdutoCreatedEvent : INotification {
    public int Id { get; set; }

    public ProdutoCreatedEvent(int id)
        => Id = id;
}