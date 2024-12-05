namespace ApiCatalogoProdutos.DTO
{
    public class ProdutoCadastrarEditarDTO
    {

        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double PrecoCompra { get; set; }
        public double PrecoVenda { get; set; }
        public int UnidadesEstoque { get; set; }
        public bool Ativo { get; set; }
        public string UrlImagemProduto { get; set; }
        public int CategoriaId { get; set; }

    }
}
