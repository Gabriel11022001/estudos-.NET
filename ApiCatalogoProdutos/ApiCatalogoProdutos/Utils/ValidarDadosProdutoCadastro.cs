using ApiCatalogoProdutos.DTO;

namespace ApiCatalogoProdutos.Utils
{
    public class ValidarDadosProdutoCadastro: IValidador<ProdutoDTO>
    {

        public string Validar(ProdutoDTO entidadeValidar)
        {
            string msgRetorno = "";

            if (entidadeValidar.Nome.Trim() == "")
            {
                msgRetorno = "Informe o nome do produto!";
            }
            else if (entidadeValidar.PrecoVenda <= 0)
            {
                msgRetorno = "Preço de venda inválido!";
            }
            else if (entidadeValidar.PrecoCompra <= 0)
            {
                msgRetorno = "Preço de compra inválido!";
            }
            else if (entidadeValidar.PrecoCompra >= entidadeValidar.PrecoVenda)
            {
                msgRetorno = "O preço de compra não deve ser maior ou igual ao preço de venda!";
            }
            else if (entidadeValidar.UnidadesEstoque < 0)
            {
                msgRetorno = "Quantidade de unidades em estoque do produto inválido!";
            }
            else if (entidadeValidar.Descricao.Trim() == "")
            {
                msgRetorno = "Informe a descrição do produto!";
            }
            else if (entidadeValidar.CategoriaId <= 0)
            {
                msgRetorno = "Informe o id da categoria do produto!";
            }
            else if (entidadeValidar.UrlImagemProduto.Trim() == "")
            {
                msgRetorno = "Informe a url da foto do produto!";
            }

            return msgRetorno;
        }

    }
}
