namespace Way2DevBootcamp.Application.Vendas.ViewModels;
public class VendaItemViewModel {
    public int Id { get; set; }
    public double Preco { get; set; }
    public int Quantidade { get; set; }
    public int ProdutoId { get; set; }
    public string ProdutoNome { get; set; }
}