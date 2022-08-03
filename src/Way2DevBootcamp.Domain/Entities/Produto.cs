namespace Way2DevBootcamp.Domain.Entities;
public class Produto : Entity {
    public string Codigo { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public double Preco { get; set; }
    public DateTime DataCadastro { get; set; }
    public int CategoriaId { get; set; }

    public virtual Categoria Categoria { get; set; }

    public Produto(string codigo, string nome, string descricao, double preco, int categoriaId) {
        Codigo = codigo;
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        DataCadastro = DateTime.Now;
        CategoriaId = categoriaId;
    }
}