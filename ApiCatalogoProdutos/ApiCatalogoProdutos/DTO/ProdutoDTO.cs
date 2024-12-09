using ApiCatalogoProdutos.Models;

namespace ApiCatalogoProdutos.DTO
{
    public class ProdutoDTO
    {

        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double PrecoCompra { get; set; }
        public double PrecoVenda { get; set; }
        public int UnidadesEstoque { get; set; }
        public int CategoriaId { get; set; }
        public bool Ativo { get; set; }
        public string UrlImagemProduto { get; set; }
        public CategoriaDTO CategoriaDTO { get; set; }

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
