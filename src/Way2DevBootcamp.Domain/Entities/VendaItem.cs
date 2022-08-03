namespace Way2DevBootcamp.Domain.Entities;

public class VendaItem : Entity {
    public double Preco { get; private set; }
    public int Quantidade { get; private set; }
    public int VendaId { get; private set; }
    public int ProdutoId { get; private set; }

    public virtual Venda Venda { get; set; }
    public virtual Produto Produto { get; set; }

    public VendaItem(double preco, int quantidade, int vendaId, int produtoId) {
        Preco = preco;
        Quantidade = quantidade;
        VendaId = vendaId;
        ProdutoId = produtoId;
    }
}