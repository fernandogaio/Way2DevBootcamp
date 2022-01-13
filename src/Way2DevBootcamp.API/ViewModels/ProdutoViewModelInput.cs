namespace Way2DevBootcamp.API.ViewModels {
    public class ProdutoViewModelInput {
        public int Id { get; protected set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public int CategoriaId { get; set; }

        public void AtribuiId(int id) {
            Id = id;
        }
    }
}
