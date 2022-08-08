using Way2DevBootcamp.Domain.Enumerators;

namespace Way2DevBootcamp.Domain.Entities;
public class Venda : Entity {
    private readonly List<VendaItem> _itens = new();

    public Guid UsuarioId { get; private set; }
    public DateTime DataVenda { get; private set; }
    public EnumStatusPedido StatusPedido { get; private set; }
    public double ValorTotal { get; private set; }

    public ICollection<VendaItem> Itens { get; private set; }

    public Venda(Guid usuarioId, EnumStatusPedido statusPedido) {
        UsuarioId = usuarioId;
        StatusPedido = statusPedido;
        DataVenda = DateTime.Now;
    }

    public void AddItem(VendaItem item) {
        _itens.Add(item);
        Itens = _itens;
        ValorTotal += item.Preco * item.Quantidade;
    }

    public void AddItens(IEnumerable<VendaItem> itens) {
        _itens.AddRange(itens);
        Itens = _itens;
        _itens.ForEach(item => { ValorTotal += item.Preco * item.Quantidade; });
    }

    public void Cancel()
        => StatusPedido = EnumStatusPedido.Cancelado;
}