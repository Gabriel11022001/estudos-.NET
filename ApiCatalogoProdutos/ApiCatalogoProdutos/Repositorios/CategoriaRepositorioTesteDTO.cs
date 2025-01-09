using ApiCatalogoProdutos.Contexto;
using ApiCatalogoProdutos.DTO;
using ApiCatalogoProdutos.Models;

namespace ApiCatalogoProdutos.Repositorios
{
    public class CategoriaRepositorioTesteDTO : ICategoriaRepositorioTestesDTO
    {

        private AppDbContexto _contexto;

        public CategoriaRepositorioTesteDTO(AppDbContexto contexto)
        {
            this._contexto = contexto;
        }

        public CategoriaDTOTeste BuscarCategoriaPeloId(int id)
        {
            Categoria categoria = this._contexto.Categorias.Find(id);

            if (categoria is null)
            {

                return null;
            }

            CategoriaDTOTeste categoriaDTOTeste = new CategoriaDTOTeste(categoria);

            return categoriaDTOTeste;
        }

        public CategoriaDTOTeste BuscarCategoriaPeloNome(string nomeCategoria)
        {
            Categoria categoria = this._contexto.Categorias.FirstOrDefault(c => c.Nome.Equals(nomeCategoria.Trim()));

            if (categoria is null) {

                return null;
            }

            CategoriaDTOTeste categoriaDTOTeste = new CategoriaDTOTeste(categoria);

            return categoriaDTOTeste;
        }

        public List<CategoriaDTOTeste> BuscarTodasCategorias()
        {
            var categorias = this._contexto.Categorias.OrderBy(c => c.Nome).ToList();

            if (categorias.Count == 0)
            {

                return new List<CategoriaDTOTeste>();
            }

            var categoriasDTO = new List<CategoriaDTOTeste>();

            foreach (var categoria in categorias)
            {
                categoriasDTO.Add(new CategoriaDTOTeste(categoria));
            }

            return categoriasDTO;
        }

        public CategoriaDTOTeste Cadastrar(CategoriaDTOTeste categoriaDTOTeste)
        {
            Categoria categoria = new Categoria();
            categoria.Nome = categoriaDTOTeste.Nome;
            categoria.UrlImagemCategoria = categoriaDTOTeste.UrlImagemCategoria;

            this._contexto.Categorias.Add(categoria);
            this._contexto.SaveChanges();

            categoriaDTOTeste.CategoriaId = categoria.CategoriaId;

            return categoriaDTOTeste;
        }

        public CategoriaDTOTeste Editar(CategoriaDTOTeste categoriaDTOTeste)
        {
            Categoria categoria = this._contexto.Categorias.Find(categoriaDTOTeste.CategoriaId);

            if (categoria is not null)
            {
                categoria.CategoriaId = categoriaDTOTeste.CategoriaId;
                categoria.Nome = categoriaDTOTeste.Nome;
                categoria.UrlImagemCategoria = categoriaDTOTeste.UrlImagemCategoria;

                this._contexto.Categorias.Entry(categoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this._contexto.SaveChanges();

                return categoriaDTOTeste;
            }

            throw new Exception("Categoria não encontrada!");
        }

    }
}
