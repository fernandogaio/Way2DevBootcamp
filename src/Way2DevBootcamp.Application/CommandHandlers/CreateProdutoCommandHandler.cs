using AutoMapper;
using MediatR;
using Way2DevBootcamp.Application.Commands;
using Way2DevBootcamp.Application.Core;
using Way2DevBootcamp.Application.Events;
using Way2DevBootcamp.Application.Notifications;
using Way2DevBootcamp.Domain.Entities;
using Way2DevBootcamp.Domain.Interfaces;

namespace Way2DevBootcamp.Application.CommandHandlers;
public class CreateProdutoCommandHandler : IRequestHandler<CreateProdutoCommand, CommandResponse> {
    private readonly IUnitOfWork _uow;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CreateProdutoCommandHandler(IUnitOfWork uow,
                                       IMediator mediator,
                                       IMapper mapper) {
        _uow = uow;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<CommandResponse> Handle(CreateProdutoCommand command, CancellationToken cancellationToken) {
        try {
            var produto = _mapper.Map<Produto>(command);

            await _uow.Produtos.Add(produto);
            await _uow.Commit();

            await _mediator.Publish(new ProdutoCreatedEvent(produto.Id), cancellationToken);
            return new CommandResponse(produto.Id);
        } catch (Exception) {
            var msg = "Ocorreu um erro no momento da criação";
            await _mediator.Publish(new ErrorNotification().AddError(msg), cancellationToken);
            return new CommandResponse().AddError(msg);
        }
    }
}