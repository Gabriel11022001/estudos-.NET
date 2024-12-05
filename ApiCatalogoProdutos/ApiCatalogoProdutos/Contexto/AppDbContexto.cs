using ApiCatalogoProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoProdutos.Contexto
{
    public class AppDbContexto: DbContext
    {

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public AppDbContexto(DbContextOptions<AppDbContexto> opcoes): base(opcoes)
        {

        }

    }
}
