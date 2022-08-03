using Way2DevBootcamp.Domain.Enumerators;

namespace Way2DevBootcamp.Domain.Entities;

public class Venda : Entity {
    public Guid UsuarioId { get; private set; }
    public DateTime DataVenda { get; private set; }
    public EnumStatusPedido StatusPedido { get; private set; }
    public double ValorTotal { get; private set; }

    public virtual ICollection<VendaItem> Itens { get; set; }

    public Venda(Guid usuarioId, DateTime dataVenda, EnumStatusPedido statusPedido, double valorTotal) {
        UsuarioId = usuarioId;
        DataVenda = dataVenda;
        StatusPedido = statusPedido;
        ValorTotal = valorTotal;
    }
}