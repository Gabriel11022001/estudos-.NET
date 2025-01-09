namespace ApiCatalogoProdutos.Utils
{
    public interface IValidadorProduto
    {

        Boolean ValidarQuantidadeUnidadesEstoqueProduto(int quantidadeUnidadesEstoqueProduto);

        Boolean ValidarPrecos(Double preco);

        Boolean ValidarPrecoCompraMaiorOuIgualPrecoVenda(Double precoCompra, Double precoVenda);

    }
}
