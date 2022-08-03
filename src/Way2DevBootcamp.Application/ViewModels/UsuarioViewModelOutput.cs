namespace Way2DevBootcamp.Application.ViewModels {
    public class UsuarioViewModelOutput {
        public bool Sucesso { get; private set; }
        public List<string> Erros { get; private set; }

        public UsuarioViewModelOutput() =>
            Erros = new List<string>();

        public UsuarioViewModelOutput(bool sucesso = true) : this() =>
            Sucesso = sucesso;

        public void AdicionarErros(IEnumerable<string> erros) =>
            Erros.AddRange(erros);
    }
}