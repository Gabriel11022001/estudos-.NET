using ApiCatalogoProdutos.Contexto;

namespace ApiCatalogoProdutos.Repositorios
{
    public abstract class RepositorioBaseUnitOfWork
    {

        protected AppDbContexto Contexto;

        public RepositorioBaseUnitOfWork(AppDbContexto contexto)
        {
            this.Contexto = contexto;
        }

    }
}
