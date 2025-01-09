using ApiCatalogoProdutos.Contexto;
using ApiCatalogoProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoProdutos.Repositorios
{
    public class CategoriaRepositorioUnitOfWork : RepositorioBaseUnitOfWork, IRepositorioCategoriaUnitOfWork
    {

        public CategoriaRepositorioUnitOfWork(AppDbContexto contexto): base(contexto) {}

        public Categoria BuscarCategoriaPeloNome(string nomeCategoriaFiltrar)
        {

            return this.Contexto.Categorias.FirstOrDefault(c => c.Nome.Equals(nomeCategoriaFiltrar));
        }

        public Categoria BuscarPeloId(int id)
        {

            return this.Contexto.Categorias.Find(id);
        }

        public List<Categoria> BuscarTodos()
        {

            return this.Contexto.Categorias.OrderBy(c => c.Nome).ToList();
        }

        public void Cadastrar(Categoria entidade)
        {
            this.Contexto.Add(entidade);
        }

        public void Deletar(Categoria entidade)
        {
            this.Contexto.Categorias.Entry(entidade).State = EntityState.Deleted;
        }

        public void Editar(Categoria entidade)
        {
            this.Contexto.Categorias.Entry(entidade).State = EntityState.Modified;
        }

    }
}
