using ApiCatalogoProdutos.Models;

namespace ApiCatalogoProdutos.DTO
{
    public class CategoriaDTO
    {

        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public string UrlImagemCategoria { get; set; }

        public CategoriaDTO() { }

        public CategoriaDTO(Categoria categoriaMapear)
        {
            this.MapearCategoriaEntidadeParaCategoriaDTO(categoriaMapear);
        }

        private void MapearCategoriaEntidadeParaCategoriaDTO(Categoria categoriaMapear)
        {
            this.CategoriaId = categoriaMapear.CategoriaId;
            this.Nome = categoriaMapear.Nome;
            this.UrlImagemCategoria = categoriaMapear.UrlImagemCategoria;
        }

    }
}
