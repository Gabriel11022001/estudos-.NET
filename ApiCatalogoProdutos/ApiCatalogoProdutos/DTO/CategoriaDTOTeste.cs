using ApiCatalogoProdutos.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalogoProdutos.DTO
{
    public class CategoriaDTOTeste
    {

        public int CategoriaId { get; set; }
        private string _nome;
        [Required(ErrorMessage = "Informe o nome do contato!")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "O nome do contato deve ter entre 3 e 150 caracteres!")]
        public String Nome 
        {
            get
            {

                return this._nome;
            }
            set
            {
                this._nome = value.ToUpper();
            }
        }
        [ Required(ErrorMessage = "Informe a url da imagem da categoria!") ]
        public string UrlImagemCategoria { get; set; }

        public CategoriaDTOTeste() { }

        public CategoriaDTOTeste(Categoria categoria)
        {
            this.CategoriaId = categoria.CategoriaId;
            this.Nome = categoria.Nome;
            this.UrlImagemCategoria = categoria.UrlImagemCategoria;
        }

    }
}
