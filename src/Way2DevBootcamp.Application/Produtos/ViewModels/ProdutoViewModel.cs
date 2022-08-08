namespace Way2DevBootcamp.Application.Produtos.ViewModels {
    public class ProdutoViewModel {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public int CategoriaId { get; set; }
        public string CategoriaNome { get; set; }
    }
}
