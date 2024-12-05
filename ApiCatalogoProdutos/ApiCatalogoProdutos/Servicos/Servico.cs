using ApiCatalogoProdutos.Contexto;

namespace ApiCatalogoProdutos.Servicos
{
    public class Servico
    {

        protected AppDbContexto _contexto;

        public Servico(AppDbContexto contexto)
        {
            this._contexto = contexto;
        }

    }
}
