using ApiCatalogoProdutos.DTO;

namespace ApiCatalogoProdutos.Repositorios
{
    public interface ICategoriaRepositorioTestesDTO
    {

        CategoriaDTOTeste Cadastrar(CategoriaDTOTeste categoriaDTOTeste);

        CategoriaDTOTeste Editar(CategoriaDTOTeste categoriaDTOTeste);

        List<CategoriaDTOTeste> BuscarTodasCategorias();

        CategoriaDTOTeste BuscarCategoriaPeloId(int id);

        CategoriaDTOTeste BuscarCategoriaPeloNome(string nomeCategoria);

    }
}
