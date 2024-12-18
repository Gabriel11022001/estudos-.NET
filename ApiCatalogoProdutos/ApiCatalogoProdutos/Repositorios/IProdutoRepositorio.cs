using ApiCatalogoProdutos.Models;

namespace ApiCatalogoProdutos.Repositorios
{
    public interface IProdutoRepositorio
    {

        Task<Produto> CadastrarProduto(Produto produtoCadastrar);

        Task<List<Produto>> BuscarTodosProdutos();

        Task<Produto> EditarProduto(Produto produtoEditar);

        Task<Produto> BuscarProdutoPeloId(int idProdutoConsultar);

        Task<Boolean> DeletarProduto(int idProdutoDeletar);

        Task<List<Produto>> BuscarProdutosEntrePrecosVenda(double precoInicial, double precoFinal);

        Task<List<Produto>> BuscarProdutosAtivos();

        Task<List<Produto>> BuscarProdutosPelaCategoria(int idCategoria);

    }
}
