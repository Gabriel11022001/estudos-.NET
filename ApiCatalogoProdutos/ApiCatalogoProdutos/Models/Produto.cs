using System.ComponentModel.DataAnnotations;

namespace ApiCatalogoProdutos.Models
{
    public class Produto
    {

        public int ProdutoId { get; set; }
        [ Required(ErrorMessage = "O nome do produto é um dado obrigatório!") ]
        [ StringLength(255, ErrorMessage = "O nome do produto não pode ultrapassar 250 caracteres!") ]
        public string Nome { get; set; }
        [ Required(ErrorMessage = "A descrição do produto é um dado obrigatório!") ]
        public string Descricao { get; set; }
        [ Required(ErrorMessage = "O preço de compra do produto é um dado obrigatório!") ]
        public double PrecoCompra { get; set; }
        [ Required(ErrorMessage = "O preço de venda do produto é um dado obrigatório") ]
        public double PrecoVenda { get; set; }
        [ Required(ErrorMessage = "A quantidade de unidades em estoque é um dado obrigatório!") ]
        public int UnidadesEstoque { get; set; }
        public bool Ativo { get; set; }
        [ Required(ErrorMessage = "A url da imagem do produto é um dado obrigatório!") ]
        public string UrlImagemProduto { get; set; }
        [ Required(ErrorMessage = "O id da catregoria é um dado obrigatório!") ]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

    }
}
