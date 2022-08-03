using Xunit;
using Way2DevBootcamp.Domain.Entities;
using Way2DevBootcamp.Domain.Interfaces;
using NSubstitute;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;

namespace Way2DevBootcamp.Tests.Domain.Services {
    public class ProdutoServiceTests {
        [Fact]
        public async Task Test1() {
            var produto = new Produto("", "", "", 0, 0);

            var uowSubstitute = Substitute.For<IUnitOfWork>();
            var validatorSubstitute = Substitute.For<IValidator<Produto>>();

            await uowSubstitute.Produtos.Add(produto);

            //var produtoService = new ProdutoService(uowSubstitute, validatorSubstitute);

            //var createdPost = produtoService.Create(produto);

            //createdPost.Should().NotBeNull();

            //await uowSubstitute.Produtos.Received().Add(produto);
        }
    }
}