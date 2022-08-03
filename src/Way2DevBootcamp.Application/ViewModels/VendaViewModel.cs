namespace Way2DevBootcamp.Application.ViewModels;
public class VendaViewModel {
    public int Id { get; set; }
    public Guid UsuarioId { get; set; }
    public DateTime DataVenda { get; set; }
    public string StatusPedido { get; set; }
    public double ValorTotal { get; set; }
    public virtual ICollection<VendaItemViewModel> Itens { get; set; }
}