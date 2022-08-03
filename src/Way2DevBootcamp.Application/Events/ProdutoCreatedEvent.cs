using MediatR;

namespace Way2DevBootcamp.Application.Events;
public class ProdutoCreatedEvent : INotification {
    public int Id { get; set; }

    public ProdutoCreatedEvent(int id)
        => Id = id;
}