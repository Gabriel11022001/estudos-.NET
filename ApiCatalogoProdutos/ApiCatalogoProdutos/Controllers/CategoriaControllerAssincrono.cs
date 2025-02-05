using ApiCatalogoProdutos.Contexto;
using ApiCatalogoProdutos.DTO;
using ApiCatalogoProdutos.Models;
using ApiCatalogoProdutos.Repositorios;
using ApiCatalogoProdutos.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiCatalogoProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaControllerAssincrono : ControllerBase
    {

        private CategoriaServico _categoriaServico;
        private CategoriaRepositorioAssincrono _categoriaRepositorioAssincrono;

        public CategoriaControllerAssincrono(AppDbContexto contexto)
        {
            this._categoriaServico = new CategoriaServico(contexto);
            this._categoriaRepositorioAssincrono = new CategoriaRepositorioAssincrono(contexto);
        }

        // buscar todas as categorias assinc
        [ HttpGet ]
        public async Task<IActionResult> BuscarTodasCategoriasAssincrono()
        {
            var respostaConsultarTodasCategorias = await this._categoriaServico.BuscarTodasCategoriasAssincrono();

            if (respostaConsultarTodasCategorias.Ok)
            {

                return Ok(respostaConsultarTodasCategorias);
            }

            return BadRequest(respostaConsultarTodasCategorias);
        }

        // buscar categoria pelo id de forma assinc
        [ HttpGet("{id:int}") ]
        public async Task<IActionResult> BuscarCategoriaPeloIdAssincrono(int id)
        {
            var resposta = await this._categoriaServico.BuscarCategoriaPeloIdAssincrono(id);

            if (resposta.Ok)
            {

                return Ok(resposta);
            }

            if (resposta.Mensagem == "Não existe uma categoria com esse id!")
            {

                return NotFound(resposta);
            }

            return BadRequest(resposta);
        }

        // buscar categorias de forma paginada
        [ HttpGet("buscar-categorias-paginadas") ]
        public async Task<IActionResult> BuscarCategoriasPaginadoAssincrono([ FromQuery ] int paginaAtual, int totalElementosPorPagina)
        {

            try
            {

                if (paginaAtual <= 0)
                {
                    paginaAtual = 1;
                }

                if (totalElementosPorPagina <= 0)
                {
                    totalElementosPorPagina = 5;
                }

                int totalPaginas = await this._categoriaRepositorioAssincrono.BuscarTotalPaginasCategorias(totalElementosPorPagina);

                List<Categoria> categorias = await this._categoriaRepositorioAssincrono.BuscarCategoriasPaginadoAssincrono(paginaAtual, totalElementosPorPagina);

                if (categorias.Count == 0)
                {

                    return Ok(new RetornoListagemPaginadaDTO<Categoria>()
                    {
                        PaginaAtual = paginaAtual,
                        TotalItensPagina = totalElementosPorPagina,
                        TotalPaginas = totalElementosPorPagina,
                        Itens = new List<Categoria>()
                    });
                }

                return Ok(new RetornoListagemPaginadaDTO<Categoria>()
                {
                    PaginaAtual = paginaAtual,
                    TotalItensPagina = totalElementosPorPagina,
                    TotalPaginas = totalPaginas,
                    Itens = categorias
                });
            }
            catch (Exception e)
            {

                return BadRequest("Erro ao tentar-se consultar as categorias de maneira paginada: " + e.Message);
            }

        }

        // cadastrar categoria de forma assincrona
        [ HttpPost ]
        public async Task<IActionResult> CadastrarCategoriaAssincrono(CategoriaDTO categoriaDTO)
        {
            RespostaHttp<CategoriaDTO> respostaCadastrarCategoria = await this._categoriaServico.CadastrarCategoriaAssincrono(categoriaDTO);

            if (respostaCadastrarCategoria.Ok)
            {

                return StatusCode(201, respostaCadastrarCategoria);
            }

            return BadRequest(respostaCadastrarCategoria);
        }

        // editra categoria de forma assincrona
        [ HttpPut ]
        public async Task<IActionResult> EditarCategoriaAssincrono(CategoriaDTO categoriaDTO)
        {
            RespostaHttp<CategoriaDTO> res = await this._categoriaServico.EditarCategoriaAssincrono(categoriaDTO);

            return res.Ok ? Ok(res) : BadRequest(res);
        }

    }
}
