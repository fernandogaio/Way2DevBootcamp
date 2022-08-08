using MediatR;

namespace Way2DevBootcamp.Application.Usuarios.Events;
public class UsuarioCreatedEvent : INotification {
    public string Id { get; set; }

    public UsuarioCreatedEvent(string id)
        => Id = id;
}