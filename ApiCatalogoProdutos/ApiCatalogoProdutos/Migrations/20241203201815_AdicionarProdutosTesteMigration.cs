using ApiCatalogoProdutos.DTO;
using ApiCatalogoProdutos.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Globalization;

#nullable disable

namespace ApiCatalogoProdutos.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarProdutosTesteMigration : Migration
    {

        private List<ProdutoDTO> _produtos = new List<ProdutoDTO>();

        public AdicionarProdutosTesteMigration()
        {

            for (int contador = 0; contador < 100; contador++)
            {
                this._produtos.Add(new ProdutoDTO()
                {
                    Nome = "Produto de teste " + (contador + 1),
                    UrlImagemProduto = "https://i.pinimg.com/originals/21/7e/70/217e70ced0d6cfaadf797cc55b3fc034.jpg",
                    PrecoCompra = 22.98,
                    PrecoVenda = 34.98,
                    UnidadesEstoque = 100 + contador,
                    Ativo = true,
                    Descricao = "Descrição do produto de teste " + (contador + 1),
                    CategoriaId = contador % 2 == 0 ? 1 : 2
                });
            }

        }

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            this._produtos.ForEach(produto =>
            {
                var ativo = produto.Ativo ? 1 : 0;
                String precoCompra = produto.PrecoCompra.ToString(CultureInfo.InvariantCulture);
                String precoVenda = produto.PrecoVenda.ToString(CultureInfo.InvariantCulture);

                // inserir os produtos na base de dados
                migrationBuilder.Sql($@"
                    INSERT INTO Produtos
                    (Nome, UrlImagemProduto, PrecoCompra, PrecoVenda, Ativo, UnidadesEstoque, Descricao, CategoriaId)
                    VALUES
                    ('{ produto.Nome }', '{ produto.UrlImagemProduto }', { precoCompra }, { precoVenda }, { ativo }, { produto.UnidadesEstoque }, '{ produto.Descricao }', { produto.CategoriaId })");
            });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            foreach (ProdutoDTO produto in this._produtos)
            {
                migrationBuilder.Sql("delete from Produtos where Nome = " + produto.Nome);
            }

        }
    }
}
