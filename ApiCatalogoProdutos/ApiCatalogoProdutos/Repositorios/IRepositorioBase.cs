using System.Linq.Expressions;

namespace ApiCatalogoProdutos.Repositorios
{
    public interface IRepositorioBase<T>
    {

        Task<T> Cadastrar(T model);

        Task<T> Editar(T model);

        Task<Boolean> Deletar(int id);

        Task<T> BuscarPeloId(int id);

        Task<List<T>> BuscarTodos();

        /**
         * Expression<Func<T, Boolean>> expressao -> vou poder, ao invocar
         * o método Filtrar, passar uma expressão lambda para poder fazer a consulta
         * aplicando os filtros que eu quiser
         */
        Task<List<T>> Filtrar(Expression<Func<T, Boolean>> expressao);

    }
}
