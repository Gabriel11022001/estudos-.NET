namespace ApiCatalogoProdutos.Repositorios
{
    public interface IRepositorioUnitOfWork<T>
    {

        List<T> BuscarTodos();

        void Cadastrar(T entidade);

        void Editar(T entidade);

        void Deletar(T entidade);

        T BuscarPeloId(int id);

    }
}
