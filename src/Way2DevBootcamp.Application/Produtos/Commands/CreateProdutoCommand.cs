using MediatR;
using Way2DevBootcamp.Application.Core;

namespace Way2DevBootcamp.Application.Produtos.Commands;
public class CreateProdutoCommand : IRequest<CommandResponse> {
    public string Codigo { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public double Preco { get; set; }
    public int CategoriaId { get; set; }
}