namespace Way2DevBootcamp.Domain.Entities {
    public class Categoria : Entity {
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }

        public Categoria(int id, string nome) {
            Id = id;
            Nome = nome;
        }
    }
}
