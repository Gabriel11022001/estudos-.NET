namespace ApiCatalogoProdutos.Repositorios
{
    public interface IUnitOfWork
    {

        IRepositorioCategoriaUnitOfWork RepositorioCategoriaUnitOfWork { get; }

        void CommitTransacoes();

        void RollbackTransacoes();

        void BeginTransacoes();

        void SalvarAlteracoesContexto();

    }
}
