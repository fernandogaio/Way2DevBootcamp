namespace Way2DevBootcamp.API.ViewModels {
    public class CategoriaViewModelInput {
        public int Id { get; protected set; }
        public string Nome { get; set; }

        public void AtribuiId(int id) {
            Id = id;
        }
    }
}
