using ApiCatalogoProdutos.DTO;
using ApiCatalogoProdutos.Models;

namespace ApiCatalogoProdutos.Utils
{
    public class Converter
    {

        public static CategoriaDTOTeste ConverterCategoriaEmCategoriaDTOTeste(Categoria categoriaConverter)
        {
            CategoriaDTOTeste categoriaDTOTeste = new CategoriaDTOTeste();
            categoriaDTOTeste.CategoriaId = categoriaConverter.CategoriaId;
            categoriaDTOTeste.Nome = categoriaConverter.Nome;
            categoriaDTOTeste.UrlImagemCategoria = categoriaConverter.UrlImagemCategoria;

            return categoriaDTOTeste;
        }

        public static List<CategoriaDTOTeste> ConverterListaCategoriaEmListaCategoriaDTOTeste(List<Categoria> categoriasConverter)
        {
            List<CategoriaDTOTeste> categoriasConvertidas = new List<CategoriaDTOTeste>();

            foreach (Categoria categoria in categoriasConverter)
            {
                categoriasConvertidas.Add(new CategoriaDTOTeste()
                {
                    CategoriaId = categoria.CategoriaId,
                    Nome = categoria.Nome,
                    UrlImagemCategoria = categoria.UrlImagemCategoria
                });
            }

            return categoriasConvertidas;
        }

        public static ProdutoDTO ConverterProdutoEmProdutoDTO(Produto produtoConverter)
        {
            ProdutoDTO produtoDTO = new ProdutoDTO();

            produtoDTO.ProdutoId = produtoConverter.ProdutoId;
            produtoDTO.Nome = produtoConverter.Nome;
            produtoDTO.UrlImagemProduto = produtoConverter.UrlImagemProduto;
            produtoDTO.UnidadesEstoque = produtoConverter.UnidadesEstoque;
            produtoDTO.PrecoVenda = produtoConverter.PrecoVenda;
            produtoDTO.PrecoCompra = produtoConverter.PrecoCompra;
            produtoDTO.Ativo = produtoConverter.Ativo;
            produtoDTO.Descricao = produtoConverter.Descricao;
            
            if (produtoConverter.Categoria is not null)
            {
                produtoDTO.CategoriaDTO = new CategoriaDTO()
                {
                    CategoriaId = produtoConverter.Categoria.CategoriaId,
                    Nome = produtoConverter.Categoria.Nome,
                    UrlImagemCategoria = produtoConverter.Categoria.UrlImagemCategoria
                };
            }

            return produtoDTO;
        }

    }
}
