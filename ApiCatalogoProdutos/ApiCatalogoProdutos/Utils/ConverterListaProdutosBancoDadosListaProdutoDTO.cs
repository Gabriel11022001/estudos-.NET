using ApiCatalogoProdutos.DTO;
using ApiCatalogoProdutos.Models;

namespace ApiCatalogoProdutos.Utils
{
    public class ConverterListaProdutosBancoDadosListaProdutoDTO: IConverter<Produto, ProdutoDTO>
    {

        public List<ProdutoDTO> ConverterLista(List<Produto> listaConverter)
        {
            List<ProdutoDTO> produtos = new List<ProdutoDTO>();

            listaConverter.ForEach(p =>
            {
                produtos.Add(new ProdutoDTO(p));
            });

            return produtos;
        }

    }
}
