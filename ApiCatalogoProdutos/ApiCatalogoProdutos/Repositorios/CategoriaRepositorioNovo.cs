using ApiCatalogoProdutos.Contexto;
using ApiCatalogoProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoProdutos.Repositorios
{
    public class CategoriaRepositorioNovo : ICategoriaProdutoRepositorio
    {

        private AppDbContexto _contexto;

        public CategoriaRepositorioNovo(AppDbContexto contexto)
        {
            this._contexto = contexto;
        }

        public async Task<Categoria> BuscarCategoriaPeloId(int idCategoriaConsultar)
        {
            var categoria = await this._contexto.Categorias.FirstOrDefaultAsync(c => c.CategoriaId == idCategoriaConsultar);

            return categoria;
        }

        public async Task<List<Categoria>> BuscarTodasCategorias()
        {
            var categorias = await this._contexto.Categorias.ToListAsync();

            return categorias;
        }

        public async Task<Categoria> CadastrarCategoria(Categoria categoriaCadastrar)
        {

            if (categoriaCadastrar is null)
            {

                throw new ArgumentNullException("Categoria inválida!");
            }

            await this._contexto.Categorias.AddAsync(categoriaCadastrar);
            await this._contexto.SaveChangesAsync();

            return categoriaCadastrar;
        }

        public async Task<bool> DeletarCategoria(int idCategoria)
        {
            var categoria = await this._contexto.Categorias.FindAsync(idCategoria);

            if (categoria is not null)
            {
                this._contexto.Categorias.Remove(categoria);
                await this._contexto.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<Categoria> EditarCategoria(Categoria categoriaEditar)
        {
            this._contexto.Entry(categoriaEditar).State = EntityState.Modified;
            await this._contexto.SaveChangesAsync();

            return categoriaEditar;
        }

        public async Task<Categoria> BuscarCategoriaPeloNome(String nomeCategoriaConsultar)
        {

            return await this._contexto.Categorias.FirstOrDefaultAsync(c => c.Nome.ToLower().Equals(nomeCategoriaConsultar.ToLower()));
        }

        public async Task<List<Produto>> BuscarProdutosRelacionadosCategoria(int idCategoria)
        {
            List<Produto> produtos = new List<Produto>();

            Categoria categoria = await this._contexto.Categorias.Include(c => c.Produtos)
                .FirstOrDefaultAsync(c => c.CategoriaId == idCategoria);

            if (categoria != null && categoria.Produtos != null && categoria.Produtos.Count > 0)
            {

                foreach (var produto in categoria.Produtos)
                {
                    produtos.Add(produto);
                }

            }

            return produtos;
        }
    }
}
