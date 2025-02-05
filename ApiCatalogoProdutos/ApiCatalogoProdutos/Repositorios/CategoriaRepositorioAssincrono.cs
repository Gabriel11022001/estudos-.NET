using ApiCatalogoProdutos.Contexto;
using ApiCatalogoProdutos.Models;
using ApiCatalogoProdutos.Utils;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoProdutos.Repositorios
{
    public class CategoriaRepositorioAssincrono
    {

        private AppDbContexto _contexto;

        public CategoriaRepositorioAssincrono(AppDbContexto contexto)
        {
            this._contexto = contexto;
        }

        /**
         * o tipo de retorno de todos os métoso assincronos deve ser Task<> -> genérico
         * se o método não retornar nada, definir o tipo de retorno somente como Task -> sem ser genérico
         * todo método assincrono deve ter a palavra reservada async
         * no escopo de todo método assincrono, deve ser utilizada a palavra reservada await
         */

        public async Task<List<Categoria>> BuscarTodasCategorias()
        {

            return await this._contexto.Categorias.ToListAsync();
        }

        public async Task CadastrarCategoria(Categoria categoriaCadastrar)
        {
            this._contexto.Categorias.Add(categoriaCadastrar);
            await this._contexto.SaveChangesAsync();
        }

        public async Task EditarCategoria(Categoria categoriaEditar)
        {
            this._contexto.Categorias.Entry(categoriaEditar).State = EntityState.Modified;
            await this._contexto.SaveChangesAsync();
        }

        public async Task DeletarCategoria(Categoria categoriaDeletar)
        {
            this._contexto.Categorias.Entry(categoriaDeletar).State = EntityState.Deleted;
            await this._contexto.SaveChangesAsync();
        }

        public async Task<Categoria> BuscarCategoriaPeloId(int idCategoria)
        {

            return await this._contexto.Categorias.FindAsync(idCategoria);
        }

        // buscar categorias de forma paginada
        public async Task<List<Categoria>> BuscarCategoriasPaginadoAssincrono(int paginaAtual, int quantidadeElementosPagina)
        {

            return await this._contexto.Categorias
                .OrderBy(c => c.Nome)
                .Skip((paginaAtual - 1) * quantidadeElementosPagina)
                .Take(quantidadeElementosPagina)
                .ToListAsync();
        }

        // obter o total de páginas de categorias
        public async Task<int> BuscarTotalPaginasCategorias(int totalElementosPorPagina)
        {
            var categorias = await this._contexto.Categorias.ToListAsync();

            if (categorias.Count == 0)
            {

                return 0;
            }

            int totalPaginas = 0;

            if (totalElementosPorPagina >= categorias.Count) {
                totalPaginas = 1;
            } else
            {
                totalPaginas = categorias.Count / totalElementosPorPagina;
            }

            return totalPaginas;
        }

        // buscar categoria pelo nome de forma assincrona
        public async Task<Categoria> BuscarCategoriaPeloNomeAssincrono(string nomeCategoriaConsultar)
        {

            return await this._contexto.Categorias.FirstOrDefaultAsync(c => c.Nome.Equals(nomeCategoriaConsultar.Trim()));
        }

    }
}
