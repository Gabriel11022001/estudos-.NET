namespace ApiCatalogoProdutos.Utils
{
    public class ValidadorProduto : IValidadorProduto
    {

        // validar se os preços do produto informados são maiores que R$0.00
        public bool ValidarPrecos(double preco)
        {

            return preco > 0;
        }

        // validar se a quantidade de unidades informadas do produto são maiores ou iguais a 0
        public bool ValidarQuantidadeUnidadesEstoqueProduto(int quantidadeUnidadesEstoqueProduto)
        {

            return quantidadeUnidadesEstoqueProduto >= 0;
        }

        public bool ValidarPrecoCompraMaiorOuIgualPrecoVenda(double precoCompra, double precoVenda)
        {

            if (precoCompra >= precoVenda)
            {

                return false;
            }

            return true;
        }

    }
}
