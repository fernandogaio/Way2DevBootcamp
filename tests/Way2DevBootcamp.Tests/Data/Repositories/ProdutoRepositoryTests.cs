using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Way2DevBootcamp.Data.Context;
using Way2DevBootcamp.Data.Repositories;
using Way2DevBootcamp.Domain.Entities;
using Xunit;

namespace Way2DevBootcamp.Tests.Data.Repositories {
    public class ProdutoRepositoryTests {
        private readonly DataContext _dataContextSubstitute = Substitute.For<DataContext>();
        private readonly DbSet<Produto> _dbSetSubstitute = Substitute.For<DbSet<Produto>>();
        private readonly ProdutoRepository _produtoRepository;

        public ProdutoRepositoryTests() {
            _produtoRepository = new ProdutoRepository(_dataContextSubstitute);
        }

        [Fact]
        public async Task GetAll_deve_chamar_GetAll_do_RepositoryBase() {
            var mockProdutos = new List<Produto>()
            {
                new Produto("aaa", "aaa", "aaa", 1, 1),
                new Produto("bbb", "bbb", "bbb", 2, 2),
                new Produto("ccc", "ccc", "ccc", 3, 3)
            };

            var mockSet = Substitute.For<DbSet<Produto>, IQueryable<Produto>>();

            ((IQueryable<Produto>)mockSet).Provider.Returns(mockProdutos.AsQueryable().Provider);
            ((IQueryable<Produto>)mockSet).Expression.Returns(mockProdutos.AsQueryable().Expression);
            ((IQueryable<Produto>)mockSet).ElementType.Returns(mockProdutos.AsQueryable().ElementType);
            ((IQueryable<Produto>)mockSet).GetEnumerator().Returns(mockProdutos.AsQueryable().GetEnumerator());
            //_dataContextSubstitute.Produtos.Returns(mockSet);

            var data = await _produtoRepository.GetAll();

            mockSet.When(q => q.Add(Arg.Any<Produto>()))
                .Do(q => mockProdutos.Add(q.Arg<Produto>()));

            mockSet.When(q => q.Remove(Arg.Any<Produto>()))
                .Do(q => mockProdutos.Remove(q.Arg<Produto>()));

            _dataContextSubstitute.Produtos = mockSet;

            //data.ToArray()[1].Nome.Should().Be("aaa");
            //data.Should().HaveCount(2);
        }

        [Fact]
        public async Task GetById_deve_chamar_GetById_do_RepositoryBase() {
            var random = new Random();
            var id = random.Next();

            await _produtoRepository.GetById(id);

            await _dbSetSubstitute.Received().FindAsync(id);
        }

        [Fact]
        public async Task Test1() {
            var produto = new Produto("aaa", "aaa", "aaa", 1, 1);

            await _produtoRepository.Add(produto);

            _dataContextSubstitute.Produtos.Received().Add(produto);
        }
    }
}
