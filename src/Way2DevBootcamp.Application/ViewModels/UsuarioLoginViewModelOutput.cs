using System.Text.Json.Serialization;

namespace Way2DevBootcamp.Application.ViewModels {
    public class UsuarioLoginViewModelOutput {
        public bool Sucesso => Erros.Count == 0;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string AccessToken { get; private set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string RefreshToken { get; private set; }

        public List<string> Erros { get; private set; }

        public UsuarioLoginViewModelOutput() =>
            Erros = new List<string>();

        public UsuarioLoginViewModelOutput(bool sucesso, string accessToken, string refreshToken) : this() {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        public void AdicionarErro(string erro) =>
            Erros.Add(erro);

        public void AdicionarErros(IEnumerable<string> erros) =>
            Erros.AddRange(erros);
    }
}