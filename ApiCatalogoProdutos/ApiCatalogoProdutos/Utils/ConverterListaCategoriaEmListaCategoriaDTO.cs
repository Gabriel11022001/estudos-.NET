using ApiCatalogoProdutos.DTO;
using ApiCatalogoProdutos.Models;

namespace ApiCatalogoProdutos.Utils
{
    public class ConverterListaCategoriaEmListaCategoriaDTO: IConverter<Categoria, CategoriaDTO>
    {

        public List<CategoriaDTO> ConverterLista(List<Categoria> listaConverter)
        {
            List<CategoriaDTO> categorias = new List<CategoriaDTO>();

            foreach (Categoria categoriaConverter in listaConverter)
            {
                categorias.Add(new CategoriaDTO(categoriaConverter));
            }

            return categorias;
        }

    }
}
