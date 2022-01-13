using System.Text;
using Way2DevBootcamp.Domain.Entities;
using Way2DevBootcamp.Domain.Interfaces;

namespace Way2DevBootcamp.Domain.Services {
    public sealed class ProdutoService : IProdutoService {
        private readonly IUnitOfWork _uow;

        public ProdutoService(IUnitOfWork uow) {
            _uow = uow;
        }

        public async Task<IEnumerable<Produto>> GetAll()
            => await _uow.Produtos.GetAll();

        public async Task<Produto> GetById(int id)
            => await _uow.Produtos.GetById(id);

        public async Task Create(Produto produto) {
            await Validate(produto);
            await _uow.Produtos.Add(produto);
            await _uow.Commit();
        }

        public async Task Edit(Produto produto) {
            await Validate(produto);
            _uow.Produtos.Update(produto);
            await _uow.Commit();
        }

        public async Task Delete(Produto produto) {
            _uow.Produtos.Delete(produto);
            await _uow.Commit();
        }

        private async Task Validate(Produto produto) {
            var stringBuilder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(produto.Codigo)) {
                stringBuilder.AppendLine("Campo código é obrigatório.");
            }

            if (produto.Codigo?.Length > 6) {
                stringBuilder.AppendLine("Código com tamanho maior do que o suportado.");
            }

            if (string.IsNullOrWhiteSpace(produto.Nome)) {
                stringBuilder.AppendLine("Campo nome é obrigatório.");
            }

            if (produto.Nome?.Length > 100) {
                stringBuilder.AppendLine("Nome com tamanho maior do que o suportado.");
            }

            if (await _uow.Produtos.ExisteProduto(produto)) {
                stringBuilder.AppendLine("Produto já cadastrado.");
            }

            if (string.IsNullOrWhiteSpace(produto.Descricao)) {
                stringBuilder.AppendLine("Campo descrição é obrigatório.");
            }

            if (produto.Descricao?.Length > 500) {
                stringBuilder.AppendLine("Campo descrição com tamanho maior do que o suportado.");
            }

            if (produto.Preco <= 0) {
                stringBuilder.AppendLine("O preço deve ser maior que 0.");
            }

            if (produto.CategoriaId == 0) {
                stringBuilder.AppendLine("A categoria deve ser informada.");
            }

            if (await _uow.Categorias.GetById(produto.CategoriaId) == null) {
                stringBuilder.AppendLine("Categoria não encontrada.");
            }

            if (stringBuilder.Length > 0) {
                throw new Exception(stringBuilder.ToString());
            }
        }
    }
}
