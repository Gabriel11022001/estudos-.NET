using ApiCatalogoProdutos.Contexto;

namespace ApiCatalogoProdutos.Servicos
{
    public class ProdutoServico: Servico
    {

        public ProdutoServico(AppDbContexto contexto) : base(contexto) { }

    }
}
