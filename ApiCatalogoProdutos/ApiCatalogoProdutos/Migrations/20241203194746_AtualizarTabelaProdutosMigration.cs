using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogoProdutos.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarTabelaProdutosMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PrecoCompra",
                table: "Produtos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PrecoVenda",
                table: "Produtos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoCompra",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "PrecoVenda",
                table: "Produtos");
        }
    }
}
