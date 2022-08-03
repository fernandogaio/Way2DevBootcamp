using AutoMapper;
using MediatR;
using Way2DevBootcamp.Application.Commands;
using Way2DevBootcamp.Application.Core;
using Way2DevBootcamp.Application.Notifications;
using Way2DevBootcamp.Domain.Interfaces;

namespace Way2DevBootcamp.Application.CommandHandlers;
public class UpdateProdutoCommandHandler : IRequestHandler<UpdateProdutoCommand, CommandResponse> {
    private readonly IUnitOfWork _uow;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public UpdateProdutoCommandHandler(IUnitOfWork uow,
                                       IMediator mediator,
                                       IMapper mapper) {
        _uow = uow;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<CommandResponse> Handle(UpdateProdutoCommand command, CancellationToken cancellationToken) {
        try {
            var produto = await _uow.Produtos.GetById(command.Id);

            if (produto is null)
                return new CommandResponse().AddError("Produto não encontrado!");

            _mapper.Map(command, produto);

            _uow.Produtos.Update(produto);
            await _uow.Commit();

            return new CommandResponse("Produto alterado com sucesso");
        } catch (Exception) {
            var msg = "Ocorreu um erro ao tentar alterar";
            await _mediator.Publish(new ErrorNotification().AddError(msg), cancellationToken);
            return new CommandResponse().AddError(msg);
        }
    }
}