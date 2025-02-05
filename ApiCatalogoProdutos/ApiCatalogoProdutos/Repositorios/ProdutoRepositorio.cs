using ApiCatalogoProdutos.Contexto;
using ApiCatalogoProdutos.DTO;
using ApiCatalogoProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoProdutos.Repositorios
{
    public class ProdutoRepositorio : Repositorio<ProdutoDTO>
    {

        public ProdutoRepositorio(AppDbContexto contexto): base(contexto) { }

        public override ProdutoDTO BuscarPeloId(int id)
        {

            return new ProdutoDTO();
        }

        public override List<ProdutoDTO> BuscarTodos()
        {
            List<Produto> produtos = this._contexto.Produtos.ToList();
            List<ProdutoDTO> produtosDTO = new List<ProdutoDTO>();

            foreach (Produto produto in produtos)
            {
                ProdutoDTO produtoDTO = new ProdutoDTO();
                produtoDTO.ProdutoId = produto.ProdutoId;
                produtoDTO.UrlImagemProduto = produto.UrlImagemProduto;
                produtoDTO.Nome = produto.Nome;
                produtoDTO.PrecoCompra = produto.PrecoCompra;
                produtoDTO.PrecoVenda = produto.PrecoVenda;
                produtoDTO.Ativo = produto.Ativo;
                produtoDTO.UnidadesEstoque = produto.UnidadesEstoque;
                produtoDTO.CategoriaId = produto.CategoriaId;
               
                produtosDTO.Add(produtoDTO);
            }

            return produtosDTO;
        }

        public override bool Cadastrar(ProdutoDTO model)
        {
            Produto produto = new Produto();
            produto.Nome = model.Nome;
            produto.UrlImagemProduto = model.UrlImagemProduto;
            produto.PrecoVenda = model.PrecoVenda;
            produto.PrecoCompra = model.PrecoCompra;
            produto.Ativo = true;
            produto.Descricao = model.Descricao;
            produto.UnidadesEstoque = model.UnidadesEstoque;
            produto.CategoriaId = model.CategoriaId;

            // persistir o produto na base de dados
            this._contexto.Produtos.Add(produto);
            this._contexto.SaveChanges();

            return true;
        }

        public override bool Editar(ProdutoDTO model)
        {

            return true;
        }

        public List<ProdutoDTO> BuscarProdutosPelaCategoria(int idCategoria)
        {
            List<ProdutoDTO> produtosRetornar = new List<ProdutoDTO>();
            List<Produto> produtosCategoria = this._contexto.Produtos.Where(p => p.CategoriaId == idCategoria).ToList();

            if (produtosCategoria.Count > 0)
            {

                foreach (Produto produto in produtosCategoria)
                {
                    produtosRetornar.Add(new ProdutoDTO(produto));
                }

            }

            return produtosRetornar;
        }

        public async Task<ProdutoDTO> BuscarProdutoPeloNome(String nomeProdutoConsultar)
        {
            Produto produto = await this._contexto.Produtos.Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.Nome.Equals(nomeProdutoConsultar));

            if (produto is null)
            {

                return null;
            }

            return new ProdutoDTO(produto);
        }

        // persistir o produto na base de dados mas de forma assincrona
        public async Task<ProdutoDTO> CadastrarProdutoAsync(ProdutoDTO produtoDTO)
        {
            Produto produtoCadastrar = new Produto();
            produtoCadastrar.Nome = produtoDTO.Nome;
            produtoCadastrar.Descricao = produtoDTO.Descricao;
            produtoCadastrar.UnidadesEstoque = produtoDTO.UnidadesEstoque;
            produtoCadastrar.PrecoVenda = produtoDTO.PrecoVenda;
            produtoCadastrar.PrecoCompra = produtoDTO.PrecoCompra;
            produtoCadastrar.Ativo = produtoDTO.Ativo;
            produtoCadastrar.UrlImagemProduto = produtoDTO.UrlImagemProduto;
            produtoCadastrar.CategoriaId = produtoDTO.CategoriaId;

            await this._contexto.AddAsync(produtoCadastrar);
            await this._contexto.SaveChangesAsync();

            produtoDTO.ProdutoId = produtoCadastrar.ProdutoId;

            return produtoDTO;
        }

        // =============== IMPLEMENTAR SERVICE E CONTROLLER PARA OS MÉTODOS DA CAMADA DE REPOSITÓRIO ABAIXO ====================

        // editar produto de forma assincrona
        public async Task EditarProdutoAssincrono(Produto produtoEditar)
        {
            this._contexto.Produtos.Entry(produtoEditar).State = EntityState.Modified;
            await this._contexto.SaveChangesAsync();
        }
        
        // buscar produto pelo id de forma assincrona
        public async Task<Produto> BuscarProdutoPeloIdAssincrono(int idProdutoConsultar)
        {

            return await this._contexto
                .Produtos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.ProdutoId == idProdutoConsultar);
        }

        // buscar produtos de forma assincrona
        public async Task<List<Produto>> BuscarProdutosAssincrono()
        {

            return await this._contexto
                .Produtos
                .Include(p => p.Categoria)
                .OrderBy(p => p.Nome)
                .ToListAsync();
        }

        // deletar produto de forma assincrona
        public async Task DeletarProdutoAssincrono(Produto produtoDeletar)
        {
            this._contexto.Produtos.Entry(produtoDeletar).State = EntityState.Deleted;
            await this._contexto.SaveChangesAsync();
        }

        // buscar produtos entre preço assincrono
        public async Task<List<Produto>> FiltrarProdutosEntrePrecosAssincrono(Double precoInicial, Double precoFinal)
        {

            return await this._contexto
                .Produtos
                .Include(p => p.Categoria)
                .Where(p => p.PrecoVenda >= precoInicial && p.PrecoVenda <= precoFinal)
                .ToListAsync();
        }

        // filtrar produtos pelo nome assincrono
        public async Task<List<Produto>> FiltrarProdutosPeloNomeAssincrono(String nomeProdutoFiltro)
        {

            return await this._contexto
                .Produtos
                .Include(p => p.Categoria)
                .OrderBy(p => p.Nome)
                .Where(p => p.Nome.Contains(nomeProdutoFiltro))
                .ToListAsync();
        }

    }
}
