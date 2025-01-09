using ApiCatalogoProdutos.DTO;
using ApiCatalogoProdutos.Models;
using ApiCatalogoProdutos.Repositorios;
using ApiCatalogoProdutos.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatalogoProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosControllerTestesCamadaRepositorio : ControllerBase
    {

        private IProdutoRepositorio _produtoRepositorio;
        private ICategoriaProdutoRepositorio _categoriaProdutoRepositorio;
        private IConverter<Produto, ProdutoDTO> _converter;
        private IValidadorProduto _validadorDadosProduto;

        public ProdutosControllerTestesCamadaRepositorio(IProdutoRepositorio produtoRepositorio, ICategoriaProdutoRepositorio categoriaProdutoRepositorio)
        {
            this._produtoRepositorio = produtoRepositorio;
            this._converter = new ConverterListaProdutosBancoDadosListaProdutoDTO();
            this._validadorDadosProduto = new ValidadorProduto();
            this._categoriaProdutoRepositorio = categoriaProdutoRepositorio;
        }

        // buscar produtos entre preços
        [ HttpGet("consultar-entre-precos-venda/{primeiroValor:double}/{segundoValor:double}") ]
        public async Task<ActionResult<List<ProdutoDTO>>> BuscarProdutosEntrePrecos(double primeiroValor, double segundoValor)
        {

            try
            {
                List<Produto> produtos = await this._produtoRepositorio.BuscarProdutosEntrePrecosVenda(
                    primeiroValor,
                    segundoValor
                );

                if (produtos.Count == 0)
                {

                    return Ok("Não existem produtos cadastrados na base de dados!");
                }

                List<ProdutoDTO> produtosConvertidosDTO = this._converter.ConverterLista(produtos);

                return Ok(produtosConvertidosDTO);
            }
            catch (Exception e)
            {

                return BadRequest("Erro: " + e.Message);
            }

        }

        // buscar somente os produtos ativos
        [ HttpGet("buscar-ativos") ]
        public async Task<ActionResult<List<ProdutoDTO>>> BuscarProdutosAtivos()
        {

            try
            {
                List<Produto> produtosAtivos = await this._produtoRepositorio.BuscarProdutosAtivos();

                return produtosAtivos.Count > 0 ? Ok(this._converter.ConverterLista(produtosAtivos))
                    : Ok("Não existem produtos ativos cadastrados na base de dados!");
            }
            catch (Exception e)
            {

                return BadRequest($"Erro: { e.Message }");
            }

        }

        // cadastrar produto na base de dados
        [ HttpPost ]
        public async Task<ActionResult<ProdutoCadastrarEditarDTO>> CadastrarProduto(ProdutoCadastrarEditarDTO produtoCadastrarEditarDTO)
        {

            try
            {

                if (!this._validadorDadosProduto.ValidarQuantidadeUnidadesEstoqueProduto(produtoCadastrarEditarDTO.UnidadesEstoque))
                {

                    return BadRequest("Unidades do produto em estoque incorreto!");
                }

                if (!this._validadorDadosProduto.ValidarPrecos(produtoCadastrarEditarDTO.PrecoCompra))
                {

                    return BadRequest("Preço de compra incorreto!");
                }

                if (!this._validadorDadosProduto.ValidarPrecos(produtoCadastrarEditarDTO.PrecoVenda))
                {

                    return BadRequest("Preço de venda incorreto!");
                }

                if (!this._validadorDadosProduto.ValidarPrecoCompraMaiorOuIgualPrecoVenda(
                    produtoCadastrarEditarDTO.PrecoCompra, produtoCadastrarEditarDTO.PrecoVenda))
                {

                    return BadRequest("O preço de compra deve ser menor que o preço de venda, para que você não tenha prejuizo!");
                }

                // validar se já não existe outro produto cadastrado com o mesmo nome
                Produto produtoCadastradoMesmoNome = await this._produtoRepositorio.BuscarProdutoPeloNome(produtoCadastrarEditarDTO.Nome);

                if (produtoCadastradoMesmoNome is not null)
                {

                    return BadRequest("Já existe outro produto cadastrado com o mesmo nome!");
                }

                // validar se a categoria informada existe
                if (await this._categoriaProdutoRepositorio.BuscarCategoriaPeloId(produtoCadastrarEditarDTO.CategoriaId) is null)
                {

                    return NotFound("Não existe uma categoria cadastrada com esse id na base de dados!");
                }

                Produto produtoCadastrar = new Produto()
                {
                    Nome = produtoCadastrarEditarDTO.Nome.Trim(),
                    Descricao = produtoCadastrarEditarDTO.Descricao.Trim(),
                    PrecoCompra = produtoCadastrarEditarDTO.PrecoCompra,
                    PrecoVenda = produtoCadastrarEditarDTO.PrecoVenda,
                    UnidadesEstoque = produtoCadastrarEditarDTO.UnidadesEstoque,
                    Ativo = produtoCadastrarEditarDTO.Ativo,
                    UrlImagemProduto = produtoCadastrarEditarDTO.UrlImagemProduto,
                    CategoriaId = produtoCadastrarEditarDTO.CategoriaId
                };

                await this._produtoRepositorio.CadastrarProduto(produtoCadastrar);

                produtoCadastrarEditarDTO.ProdutoId = produtoCadastrar.ProdutoId;

                var retorno = new Dictionary<String, ProdutoCadastrarEditarDTO>();
                retorno.Add("Produto cadastrado com sucesso!", produtoCadastrarEditarDTO);

                return Ok(retorno);
            }
            catch (Exception e)
            {

                return BadRequest("Erro ao tentar-se cadastrar o produto: " + e.Message);
            }

        }

        [ HttpGet ]
        public async Task<ActionResult<List<ProdutoDTO>>> BuscarTodosProdutos()
        {

            try
            {
                var produtos = await this._produtoRepositorio.BuscarTodosProdutos();

                if (produtos.Count == 0)
                {

                    return Ok("Não existem produtos cadastrados na base de dados!");
                }

                return Ok(this._converter.ConverterLista(produtos));
            }
            catch (Exception e)
            {

                return BadRequest("Erro ao tentar-se consultar todos os produtos cadastrados na base de dados: " + e.Message);
            }

        }

    }
}
