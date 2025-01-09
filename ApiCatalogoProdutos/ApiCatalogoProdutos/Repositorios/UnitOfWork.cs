using ApiCatalogoProdutos.Contexto;

namespace ApiCatalogoProdutos.Repositorios
{
    public class UnitOfWork : IUnitOfWork
    {

        public AppDbContexto Contexto;
        private IRepositorioCategoriaUnitOfWork _categoriaRepositorioUnitOfWork;
        public IRepositorioCategoriaUnitOfWork RepositorioCategoriaUnitOfWork
        {
            get
            {

                if (this._categoriaRepositorioUnitOfWork is null)
                {

                    return new CategoriaRepositorioUnitOfWork(this.Contexto);
                }

                return this._categoriaRepositorioUnitOfWork;
            }
        }

        public UnitOfWork(AppDbContexto contexto)
        {
            this.Contexto = contexto;
            this._categoriaRepositorioUnitOfWork = new CategoriaRepositorioUnitOfWork(this.Contexto);
        }

        // iniciar as transações na base de dados
        public void BeginTransacoes()
        {
            this.Contexto.Database.BeginTransaction();
        }

        // persistir as transações na base de dados
        public void CommitTransacoes()
        {
            this.Contexto.Database.CommitTransaction();
        }

        // calcelar as transações na base de dados
        public void RollbackTransacoes()
        {
            this.Contexto.Database.RollbackTransaction();
        }

        public void Dispose()
        {
            this.Contexto.Dispose();
        }

        public void SalvarAlteracoesContexto()
        {
            this.Contexto.SaveChanges();
        }

    }
}
