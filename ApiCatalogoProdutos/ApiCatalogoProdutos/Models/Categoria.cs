using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalogoProdutos.Models
{
    public class Categoria
    {

        public int CategoriaId { get; set; }
        [ Required(ErrorMessage = "O nome da categoria é um dado obrigatório!") ]
        [ StringLength(150, ErrorMessage = "O nome da categoria não pode ultrapassar 150 caracteres!") ]
        public string Nome { get; set; }
        [ Required(ErrorMessage = "A url da foto da categoria é um dado obrigatório!") ]
        public string UrlImagemCategoria { get; set; }
        public ICollection<Produto> Produtos { get; set; }

        public Categoria()
        {
            this.Produtos = new Collection<Produto>();
        }

    }
}
