using ApiCatalogoProdutos.Atributos;
using ApiCatalogoProdutos.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalogoProdutos.DTO
{
    public class ProdutoDTO
    {
        public int ProdutoId { get; set; }
        [ Required(ErrorMessage = "Informe o nome do produto!") ]
        [ StringLength(255, MinimumLength = 3, ErrorMessage = "O nome do produto deve ter entre 3 e 255 caracteres!") ]
        [ PrimeiraLetraMaiuscula ]
        public string Nome { get; set; }
        [ Required(ErrorMessage = "Informe a descrição do produto!") ]
        [ StringLength(int.MaxValue, MinimumLength = 3, ErrorMessage = "A descrição não possui limite máximo de tamanho e deve conter no mínimo 3 caracteres!") ]
        public string Descricao { get; set; }
        [ Required(ErrorMessage = "Informe o preço de compra do produto!")]
        [ Range(1, double.MaxValue, ErrorMessage = "Preço de compra inválido!") ]
        public double PrecoCompra { get; set; }
        [ Required(ErrorMessage = "Informe o preço de venda!") ]
        [ Range(1, double.MaxValue, ErrorMessage = "Preço de venda inválido!") ]
        public double PrecoVenda { get; set; }
        [ Required(ErrorMessage = "Informe a quantidade de unidades em estoque do produto!")]
        [ Range(0, int.MaxValue, ErrorMessage = "Quantidade de unidades do produto em estoque inválido!") ]
        public int UnidadesEstoque { get; set; }
        [ Required(ErrorMessage = "Informe o id da categoria do produto!") ]
        [ Range(1, int.MaxValue, ErrorMessage = "O id da categoria está incorreto!") ]
        public int CategoriaId { get; set; }
        public bool Ativo { get; set; }
        [ Required(ErrorMessage = "Informe a url da foto do produto!") ]
        public string UrlImagemProduto { get; set; }
        public CategoriaDTO? CategoriaDTO { get; set; }

        public ProdutoDTO() { }

        public ProdutoDTO(Produto produto)
        {
            this.ProdutoId = produto.ProdutoId;
            this.Nome = produto.Nome;
            this.UnidadesEstoque = produto.UnidadesEstoque;
            this.PrecoVenda = produto.PrecoVenda;
            this.PrecoCompra = produto.PrecoCompra;
            this.Ativo = produto.Ativo;
            this.CategoriaId = produto.CategoriaId;
            this.Descricao = produto.Descricao;
            this.UrlImagemProduto = produto.UrlImagemProduto;

            this.CategoriaDTO = new CategoriaDTO(produto.Categoria);
        }

    }
}
