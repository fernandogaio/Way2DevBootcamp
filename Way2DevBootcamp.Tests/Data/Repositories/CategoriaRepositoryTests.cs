using NSubstitute;
using System;
using System.Threading.Tasks;
using Way2DevBootcamp.Data.Repositories;
using Way2DevBootcamp.Domain.Entities;
using Way2DevBootcamp.Domain.Interfaces;
using Xunit;

namespace Way2DevBootcamp.Tests.Data.Repositories {
    public class CategoriaRepositoryTests {
        private readonly IRepositoryBase<Categoria> _repositoryBaseSubstitute = Substitute.For<IRepositoryBase<Categoria>>();
        private readonly CategoriaRepository _categoriaRepository;

        public CategoriaRepositoryTests() {
            _categoriaRepository = new CategoriaRepository(_repositoryBaseSubstitute);
        }

        [Fact]
        public async Task GetAll_deve_chamar_GetAll_do_RepositoryBase() {
            await _categoriaRepository.GetAll();

            await _repositoryBaseSubstitute.Received().GetAll();
        }

        [Fact]
        public async Task GetById_deve_chamar_GetById_do_RepositoryBase() {
            var random = new Random();
            var id = random.Next();

            await _categoriaRepository.GetById(id);

            await _repositoryBaseSubstitute.Received().GetById(id);
        }
    }
}
