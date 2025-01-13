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

    }
}
