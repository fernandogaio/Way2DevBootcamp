using MediatR;

namespace Way2DevBootcamp.Application.Vendas.Commands;
public class CreateVendaItemCommand : IRequest<string> {
    public double Preco { get; set; }
    public int Quantidade { get; set; }
    public int ProdutoId { get; set; }
}