using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Way2DevBootcamp.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    DataVenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusPedido = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VendaItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    VendaId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendaItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendaItem_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendaItem_Venda_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Venda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Acessórios de Tecnologia" },
                    { 2, "Ar e Ventilação" },
                    { 3, "Artesanato" },
                    { 4, "Artigos para Festa" },
                    { 5, "Áudio" },
                    { 6, "Automotivo" },
                    { 7, "Bebês" },
                    { 8, "Beleza & Perfumaria" },
                    { 9, "Brinquedos" },
                    { 10, "Cama, Mesa e Banho" },
                    { 11, "Câmeras e Drones" },
                    { 12, "Casa e Construção" },
                    { 13, "Casa Inteligente" },
                    { 14, "Celular e Smartphone" },
                    { 15, "Colchões" },
                    { 16, "Comércio e Indústria" },
                    { 17, "Cursos" },
                    { 18, "Decoração" },
                    { 19, "Eletrodomésticos" },
                    { 20, "Eletroportáteis" },
                    { 21, "Esporte e Lazer" },
                    { 22, "Ferramentas" },
                    { 23, "Filmes e Séries" },
                    { 24, "Games" },
                    { 25, "Informática" },
                    { 26, "Instrumentos Musicais" },
                    { 27, "Livros" },
                    { 28, "Mercado" },
                    { 29, "Moda" },
                    { 30, "Móveis" },
                    { 31, "Música e Shows" },
                    { 32, "Natal" },
                    { 33, "Papelaria" },
                    { 34, "Pet Shop" },
                    { 35, "Relógios" },
                    { 36, "Saúde e Cuidados Pessoais" },
                    { 37, "Serviços" },
                    { 38, "Suplementos Alimentares" },
                    { 39, "Tablets, iPads e E - Readers" },
                    { 40, "Telefonia Fixa" },
                    { 41, "TV e Vídeo" },
                    { 42, "Utilidades Domésticas" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CategoriaId",
                table: "Produto",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_VendaItem_ProdutoId",
                table: "VendaItem",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_VendaItem_VendaId",
                table: "VendaItem",
                column: "VendaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VendaItem");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
