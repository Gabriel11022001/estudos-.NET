using ApiCatalogoProdutos.Contexto;

namespace ApiCatalogoProdutos.Repositorios
{
    public abstract class Repositorio<T>
    {

        protected AppDbContexto _contexto;

        public Repositorio(AppDbContexto contexto)
        {
            this._contexto = contexto;
        }

        public abstract bool Cadastrar(T model);

        public abstract bool Editar(T model);

        public abstract List<T> BuscarTodos();

        public abstract T BuscarPeloId(int id);

    }
}
