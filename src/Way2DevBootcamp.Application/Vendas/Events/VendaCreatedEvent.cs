﻿using MediatR;

namespace Way2DevBootcamp.Application.Vendas.Events;
public class VendaCreatedEvent : INotification {
    public int Id { get; set; }

    public VendaCreatedEvent(int id)
        => Id = id;
}