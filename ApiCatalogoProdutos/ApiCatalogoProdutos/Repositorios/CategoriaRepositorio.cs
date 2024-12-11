using ApiCatalogoProdutos.Contexto;
using ApiCatalogoProdutos.DTO;
using ApiCatalogoProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoProdutos.Repositorios
{
    public class CategoriaRepositorio : Repositorio<CategoriaDTO>
    {

        public CategoriaRepositorio(AppDbContexto contexto): base(contexto) { }

        public override CategoriaDTO BuscarPeloId(int id)
        {
            Categoria categoria = this._contexto.Categorias.FirstOrDefault(c => c.CategoriaId == id);

            if (categoria is null)
            {

                return null;
            }

            return new CategoriaDTO(categoria);
        }

        public override List<CategoriaDTO> BuscarTodos()
        {
            List<CategoriaDTO> categorias = new List<CategoriaDTO>();
            List<Categoria> categoriasConsulta = this._contexto.Categorias.ToList();

            foreach (Categoria categoriaMapear in categoriasConsulta)
            {
                CategoriaDTO categoriaDTO = new CategoriaDTO(categoriaMapear);

                categorias.Add(categoriaDTO);
            }

            return categorias;
        }

        public override bool Cadastrar(CategoriaDTO model)
        {
            Categoria categoriaCadastrar = new Categoria();
            categoriaCadastrar.Nome = model.Nome;
            categoriaCadastrar.UrlImagemCategoria = model.UrlImagemCategoria;

            this._contexto.Add(categoriaCadastrar);
            this._contexto.SaveChanges();

            return true;
        }

        public override bool Editar(CategoriaDTO model)
        {
            Categoria categoriaEditar = this._contexto.Categorias.Find(model.CategoriaId);
            categoriaEditar.Nome = model.Nome;
            categoriaEditar.UrlImagemCategoria = model.UrlImagemCategoria;

            this._contexto.Entry(categoriaEditar).State = EntityState.Modified;
            this._contexto.SaveChanges();

            return true;
        }

        public void DeletarCategoria(int idCategoriaDeletar)
        {
            Categoria categoriaDeletar = this._contexto.Categorias.Find(idCategoriaDeletar);
            
            if (categoriaDeletar != null)
            {
                this._contexto.Categorias.Remove(categoriaDeletar);
                this._contexto.SaveChanges();
            }

        }

        public CategoriaDTO BuscarCategoriaPeloNome(string nome)
        {
            Categoria categoria = this._contexto.Categorias.FirstOrDefault(c => c.Nome == nome);

            if (categoria is null)
            {

                return null;
            }

            return new CategoriaDTO(categoria);
        }

        public async Task<CategoriaDTO> BuscarCategoriaPeloIdAsync(int idCategoriaConsultar)
        {
            Categoria categoria = await this._contexto.Categorias.FindAsync(idCategoriaConsultar);

            if (categoria is null)
            {

                return null;
            }

            return new CategoriaDTO(categoria);
        }

    }
}
