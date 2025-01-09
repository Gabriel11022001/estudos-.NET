using ApiCatalogoProdutos.Contexto;
using ApiCatalogoProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoProdutos.Repositorios
{
    public class ProdutoRepositorioNovo: IProdutoRepositorio
    {

        private AppDbContexto _contexto;

        // recebendo um objeto do tipo AppDbContexto por injeção de dependência
        public ProdutoRepositorioNovo(AppDbContexto contexto)
        {
            this._contexto = contexto;
        }

        public async Task<Produto> CadastrarProduto(Produto produtoCadastrar)
        {
            await this._contexto.Produtos.AddAsync(produtoCadastrar);
            await this._contexto.SaveChangesAsync();

            return produtoCadastrar;
        }

        public async Task<Produto> EditarProduto(Produto produtoEditar)
        {
            this._contexto.Entry(produtoEditar).State = EntityState.Modified;
            await this._contexto.SaveChangesAsync();

            return produtoEditar;
        }

        public async Task<List<Produto>> BuscarTodosProdutos()
        {
            var produtos = await this._contexto.Produtos.Include(p => p.Categoria).ToListAsync();

            return produtos;
        }

        public async Task<Produto> BuscarProdutoPeloId(int idProdutoConsultar)
        {

            return await this._contexto.Produtos.FirstOrDefaultAsync(p => p.ProdutoId == idProdutoConsultar);
        }

        public async Task<Boolean> DeletarProduto(int idProdutoDeletar)
        {
            Produto produtoDeletar = await this._contexto.Produtos.FindAsync(idProdutoDeletar);

            if (produtoDeletar is not null)
            {
                this._contexto.Produtos.Remove(produtoDeletar);
                await this._contexto.SaveChangesAsync();

                return true;
            }

            throw new Exception("Não foi encontrado um produto com esse id!");
        }

        public async Task<List<Produto>> BuscarProdutosEntrePrecosVenda(double precoInicial, double precoFinal)
        {

            return await this._contexto.Produtos.Where(p => p.PrecoVenda >= precoInicial && p.PrecoVenda <= precoFinal)
                .OrderBy(p => p.Nome)
                .Include(p => p.Categoria)
                .ToListAsync();
        }

        public async Task<List<Produto>> BuscarProdutosAtivos()
        {

            return await this._contexto.Produtos
                .Where(p => p.Ativo == true)
                .OrderBy(p => p.Nome)
                .Include(p => p.Categoria)
                .ToListAsync();
        }

        public async Task<List<Produto>> BuscarProdutosPelaCategoria(int idCategoria)
        {

            return await this._contexto.Produtos
                .Where(p => p.CategoriaId == idCategoria)
                .OrderBy(p => p.Nome)
                .Include(p => p.Categoria)
                .ToListAsync();
        }

        public async Task<Produto> BuscarProdutoPeloNome(string nomeProdutoConsultar)
        {

            return await this._contexto.Produtos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.Nome.Equals(nomeProdutoConsultar.Trim()));
        }
    }
}
