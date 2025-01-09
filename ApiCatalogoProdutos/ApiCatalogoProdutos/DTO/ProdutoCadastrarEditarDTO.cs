using System.ComponentModel.DataAnnotations;

namespace ApiCatalogoProdutos.DTO
{
    public class ProdutoCadastrarEditarDTO
    {

        public int ProdutoId { get; set; }
        [ Required(ErrorMessage = "Informe o nome do produto.") ]
        [ StringLength(255, MinimumLength = 3, ErrorMessage = "O nome do produto deve ter entre 3 e 255 caracteres!") ]
        public string Nome { get; set; }
        [ Required(ErrorMessage = "Informe a descrição do produto.") ]
        public string Descricao { get; set; }
        [ Required(ErrorMessage = "Informe o preço de compra do produto.") ]
        public double PrecoCompra { get; set; }
        [ Required(ErrorMessage = "Informe o preço de compra do produto.") ]
        public double PrecoVenda { get; set; }
        [ Required(ErrorMessage = "Informe a quantidade de unidades do produto.") ]
        public int UnidadesEstoque { get; set; }
        [ Required(ErrorMessage = "Informe se o produto está ativo ou não.") ]
        public bool Ativo { get; set; }
        [ Required(ErrorMessage = "Informe a url da foto do produto.") ]
        public string UrlImagemProduto { get; set; }
        [ Required(ErrorMessage = "Informe a categoria do produto.") ]
        public int CategoriaId { get; set; }

    }
}
