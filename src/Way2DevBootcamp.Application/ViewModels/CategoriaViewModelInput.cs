namespace Way2DevBootcamp.Application.ViewModels {
    public class CategoriaViewModelInput {
        public int Id { get; private set; }
        public string Nome { get; set; }

        public void SetId(int id) {
            Id = id;
        }
    }
}
