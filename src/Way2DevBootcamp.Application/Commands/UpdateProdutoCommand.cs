using MediatR;
using Way2DevBootcamp.Application.Core;

namespace Way2DevBootcamp.Application.Commands;
public class UpdateProdutoCommand : IRequest<CommandResponse> {
    public int Id { get; private set; }
    public string Codigo { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public double Preco { get; set; }
    public int CategoriaId { get; set; }

    public void SetId(int id) {
        Id = id;
    }
}