namespace Way2DevBootcamp.Domain.Entities;

public class VendaItem : Entity {
    public double Preco { get; set; }
    public int Quantidade { get; set; }
    public int VendaId { get; set; }
    public int ProdutoId { get; set; }

    public virtual Venda Venda { get; set; }
    public virtual Produto Produto { get; set; }
}