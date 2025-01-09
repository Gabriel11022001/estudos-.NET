using ApiCatalogoProdutos.Models;

namespace ApiCatalogoProdutos.Repositorios
{
    public interface IRepositorioCategoriaUnitOfWork: IRepositorioUnitOfWork<Categoria>
    {

        Categoria BuscarCategoriaPeloNome(String nomeCategoriaFiltrar);

    }
}
