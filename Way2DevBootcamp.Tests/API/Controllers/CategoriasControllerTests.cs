using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Way2DevBootcamp.API.AutoMapper;
using Way2DevBootcamp.API.Controllers;
using Way2DevBootcamp.API.ViewModels;
using Way2DevBootcamp.Domain.Entities;
using Way2DevBootcamp.Domain.Interfaces;
using Xunit;

namespace Way2DevBootcamp.Tests.API.Controllers {
    public class CategoriasControllerTests {
        private readonly CategoriasController _categoriasController;
        private readonly IUnitOfWork uowSubstitute = Substitute.For<IUnitOfWork>();
        private readonly IMapper _mapper;
        private readonly Random _random = new();
        private Categoria _categoria;

        public CategoriasControllerTests() {
            var mockMapper = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = mockMapper.CreateMapper();
            _categoriasController = new CategoriasController(uowSubstitute, _mapper);
        }

        [Fact]
        public async Task GetAll_deve_retornar_todas_as_categorias() {
            var categorias = new List<Categoria> { new Categoria(1, "nome1"), new Categoria(2, "nome2") };
            uowSubstitute.Categorias.GetAll().Returns(categorias);

            var contentResult = await _categoriasController.Get();

            contentResult.Count().Should().Be(2);
        }

        [Fact]
        public async Task GetById_deve_retornar_categoria_quando_categoria_existe() {
            var id = _random.Next();
            _categoria = new Categoria(id, "nome");
            uowSubstitute.Categorias.GetById(id).Returns(_categoria);

            var actionResult = await _categoriasController.GetById(id);
            var okResult = actionResult as OkObjectResult;
            var contentResult = okResult.Value as CategoriaViewModelOutput;

            contentResult.Id.Should().Be(_categoria.Id);
            contentResult.Nome.Should().Be(_categoria.Nome);
        }

        [Fact]
        public async Task GetById_deve_retornar_StatusCode_200_quando_categoria_existe() {
            var id = _random.Next();
            _categoria = new Categoria(id, "nome");
            uowSubstitute.Categorias.GetById(id).Returns(_categoria);

            var actionResult = await _categoriasController.GetById(id);
            var okResult = actionResult as OkObjectResult;

            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        }


        [Fact]
        public async Task GetById_deve_retornar_NotFound_quando_categoria_existe() {
            var id = _random.Next();

            var actionResult = await _categoriasController.GetById(id);
            var okResult = actionResult as NotFoundResult;

            okResult.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }
    }
}
