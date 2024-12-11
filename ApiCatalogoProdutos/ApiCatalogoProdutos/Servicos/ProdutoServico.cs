using ApiCatalogoProdutos.Contexto;
using ApiCatalogoProdutos.DTO;
using ApiCatalogoProdutos.Models;
using ApiCatalogoProdutos.Repositorios;
using ApiCatalogoProdutos.Utils;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoProdutos.Servicos
{
    public class ProdutoServico: Servico
    {

        private readonly IConverter<Produto, ProdutoDTO> _converterListaProdutosEmListaProdutosDTO;
        private readonly IValidador<ProdutoDTO> _validadosDadosCadastroProduto;
        private readonly ProdutoRepositorio _produtoRepositorio;
        private readonly CategoriaRepositorio _categoriaRepositorio;

        public ProdutoServico(AppDbContexto contexto): base(contexto) 
        {
            this._converterListaProdutosEmListaProdutosDTO = new ConverterListaProdutosBancoDadosListaProdutoDTO();
            this._validadosDadosCadastroProduto = new ValidarDadosProdutoCadastro();
            this._produtoRepositorio = new ProdutoRepositorio(contexto);
            this._categoriaRepositorio = new CategoriaRepositorio(contexto);
        }

        public async Task<RespostaHttp<List<ProdutoDTO>>> BuscarTodosProdutos()
        {

            try
            {
                List<Produto> produtos = await this._contexto.Produtos.Include(p => p.Categoria).ToListAsync();

                if (produtos.Count == 0)
                {

                    return new RespostaHttp<List<ProdutoDTO>>("Não existem produtos cadastrados na base de dados!", true, new List<ProdutoDTO>());
                }

                List<ProdutoDTO> produtosDTO = this._converterListaProdutosEmListaProdutosDTO.ConverterLista(produtos);

                return new RespostaHttp<List<ProdutoDTO>>("Produtos encontrados com sucesso!", true, produtosDTO);
            }
            catch (Exception e)
            {

                return new RespostaHttp<List<ProdutoDTO>>("Erro ao tentar-se consultar todos os produtos!", false, new List<ProdutoDTO>());
            }

        }

        public async Task<RespostaHttp<ProdutoDTO>> CadastrarProduto(ProdutoDTO produtoDTO)
        {

            try
            {
                /*String resultadoValidacaoDadosProdutoCadastro = this._validadosDadosCadastroProduto.Validar(produtoDTO);

                if (resultadoValidacaoDadosProdutoCadastro != "")
                {

                    return new RespostaHttp<ProdutoDTO>(resultadoValidacaoDadosProdutoCadastro, false, null);
                }*/

                if (produtoDTO.PrecoCompra <= produtoDTO.PrecoVenda)
                {

                    return new RespostaHttp<ProdutoDTO>("O preço de compra não pode ser menor ou igual ao preço de venda!", false, null);
                }

                // validar se já existe um produto cadastrado com o mesmo nome
                ProdutoDTO produtoCadastradoMesmoNome = await this._produtoRepositorio.BuscarProdutoPeloNome(produtoDTO.Nome);

                if (produtoCadastradoMesmoNome != null)
                {

                    return new RespostaHttp<ProdutoDTO>("Já existe um produto cadastrado com o mesmo nome na base de dados", false, null);
                }

                // validar se existe uma categoria cadastrada com o id informado
                CategoriaDTO categoriaProdutoDTO = await this._categoriaRepositorio.BuscarCategoriaPeloIdAsync(idCategoriaConsultar: produtoDTO.CategoriaId);

                if (categoriaProdutoDTO is null)
                {

                    return new RespostaHttp<ProdutoDTO>("não existe uma categoria cadastrada com esse id!", false, null);
                }

                produtoDTO = await this._produtoRepositorio.CadastrarProdutoAsync(produtoDTO);

                return new RespostaHttp<ProdutoDTO>("Produto cadastrado com sucesso!", true, produtoDTO);
            }
            catch (Exception e)
            {

                return new RespostaHttp<ProdutoDTO>($"Erro ao tentar-se cadastrar o produto: { e.Message }", false, null);
            }

        }

    }
}
