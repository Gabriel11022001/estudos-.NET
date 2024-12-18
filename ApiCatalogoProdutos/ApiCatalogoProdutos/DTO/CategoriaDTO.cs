using ApiCatalogoProdutos.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalogoProdutos.DTO
{
    public class CategoriaDTO
    {

        public int CategoriaId { get; set; }
        [ Required(ErrorMessage = "Informe o nome da categoria") ]
        [ StringLength(155, MinimumLength = 3, ErrorMessage = "O nome da categoria deve ter entre 3 e 155 caracteres") ]
        public string Nome { get; set; }
        [ Required(ErrorMessage = "Informe a url da imagem da categoria") ]
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
