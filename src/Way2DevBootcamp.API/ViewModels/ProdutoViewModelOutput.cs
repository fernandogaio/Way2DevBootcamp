namespace Way2DevBootcamp.API.ViewModels {
    public class ProdutoViewModelOutput {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public int CategoriaId { get; set; }
        public string CategoriaNome { get; set; }
    }
}
