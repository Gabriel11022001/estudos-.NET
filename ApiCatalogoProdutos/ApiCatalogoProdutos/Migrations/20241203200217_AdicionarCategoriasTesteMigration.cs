using ApiCatalogoProdutos.DTO;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogoProdutos.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarCategoriasTesteMigration : Migration
    {

        private List<CategoriaDTO> _categorias = new List<CategoriaDTO>();

        public AdicionarCategoriasTesteMigration()
        {
            // popular a lista com as categorias de teste cadastradas
            this.PopularListaCategoriasCadastrar();
        }

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // adicionar categorias de teste
            this._categorias.ForEach(categoriaCadastrar =>
            {
                migrationBuilder.Sql($"insert into Categorias(Nome, UrlImagemCategoria) values('{ categoriaCadastrar.Nome }', '{ categoriaCadastrar.UrlImagemCategoria }');");
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // deletar as categorias cadastradas
            this._categorias.ForEach(categoriaDeletar =>
            {
                migrationBuilder.Sql("delete from Categorias where Nome = " + categoriaDeletar.Nome);
            });
        }

        private void PopularListaCategoriasCadastrar()
        {

            for (int contador = 0; contador < 100; contador++)
            {
                var categoriaDTO = new CategoriaDTO();
                categoriaDTO.Nome = "Categoria de teste " + (contador + 1);
                categoriaDTO.UrlImagemCategoria = "https://th.bing.com/th/id/OIP.V8YqHho4NXzm5hLHdai7MQAAAA?rs=1&pid=ImgDetMain";

                this._categorias.Add(categoriaDTO);
            }

        }

    }
}
