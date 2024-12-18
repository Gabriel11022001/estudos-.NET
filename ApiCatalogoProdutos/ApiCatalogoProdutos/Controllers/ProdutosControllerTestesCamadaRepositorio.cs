using ApiCatalogoProdutos.DTO;
using ApiCatalogoProdutos.Models;
using ApiCatalogoProdutos.Repositorios;
using ApiCatalogoProdutos.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatalogoProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosControllerTestesCamadaRepositorio : ControllerBase
    {

        private IProdutoRepositorio _produtoRepositorio;
        private IConverter<Produto, ProdutoDTO> _converter;

        public ProdutosControllerTestesCamadaRepositorio(IProdutoRepositorio produtoRepositorio)
        {
            this._produtoRepositorio = produtoRepositorio;
            this._converter = new ConverterListaProdutosBancoDadosListaProdutoDTO();
        }

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

    }
}
