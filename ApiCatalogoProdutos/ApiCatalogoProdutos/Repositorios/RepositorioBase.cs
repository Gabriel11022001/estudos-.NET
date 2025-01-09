
using ApiCatalogoProdutos.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiCatalogoProdutos.Repositorios
{
    public class RepositorioBase<T> : IRepositorioBase<T>
    {

        private AppDbContexto _contexto;

        public RepositorioBase(AppDbContexto contexto)
        {
            this._contexto = contexto;
        }

        public async Task<T> BuscarPeloId(int id)
        {

            // return await this._contexto.Set<T>().FindAsync(id);

            return default;
        }

        public async Task<List<T>> BuscarTodos()
        {

            // return await this._contexto.Set<T>().ToListAsync();

            return default;
        }

        public async Task<T> Cadastrar(T model)
        {
            // await this._contexto.Set<T>().AddAsync(model);
            // await this._contexto.SaveChangesAsync();

            return default;
        }

        public async Task<bool> Deletar(int id)
        {
            var entidadeDeletar = await this.BuscarPeloId(id);

            if (entidadeDeletar is not null)
            {
                // this._contexto.Set<T>().Remove(entidadeDeletar);
                // await this._contexto.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<T> Editar(T model)
        {
            this._contexto.Entry(model).State = EntityState.Modified;
            await this._contexto.SaveChangesAsync();

            return model;
        }

        public async Task<List<T>> Filtrar(Expression<Func<T, bool>> expressao)
        {

            return default;
        }

    }
}
