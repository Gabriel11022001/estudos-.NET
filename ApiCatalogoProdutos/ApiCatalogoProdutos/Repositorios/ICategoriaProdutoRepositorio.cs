using ApiCatalogoProdutos.Models;

namespace ApiCatalogoProdutos.Repositorios
{
    public interface ICategoriaProdutoRepositorio
    {

        Task<Categoria> CadastrarCategoria(Categoria categoriaCadastrar);

        Task<Categoria> EditarCategoria(Categoria categoriaEditar);

        Task<List<Categoria>> BuscarTodasCategorias();

        Task<Categoria> BuscarCategoriaPeloId(int idCategoriaConsultar);

        Task<Boolean> DeletarCategoria(int idCategoria);

        Task<Categoria> BuscarCategoriaPeloNome(String nomeCategoriaConsultar);

        Task<List<Produto>> BuscarProdutosRelacionadosCategoria(int idCategoria);

    }
}
