namespace Way2DevBootcamp.Application.Vendas.ViewModels;
public class VendaViewModel {
    public int Id { get; set; }
    public Guid UsuarioId { get; set; }
    public DateTime DataVenda { get; set; }
    public string StatusPedido { get; set; }
    public double ValorTotal { get; set; }
    public bool Cancelada => StatusPedido == "Cancelado";
    public virtual ICollection<VendaItemViewModel> Itens { get; set; }
}