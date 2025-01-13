using ApiCatalogoProdutos.Contexto;
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
    public class CategoriaControllerPaginada : ControllerBase
    {

        private CategoriaRepositorio _categoriaRepositorio;
        private AppDbContexto _contexto;
        private const int _minimoElementosPorPagina = 5;
        private const int _maximoElementosPorPagina = 10;

        public CategoriaControllerPaginada(AppDbContexto contexto)
        {
            this._categoriaRepositorio = new CategoriaRepositorio(contexto);
            this._contexto = contexto;
        }

        /**
         * [ FromQuery ] -> poder acessar as propriedades por query-string na url
         * -> exemplo /categorias?PaginaAtual=1&ElementosPorPagina=10
         */
        [HttpGet ]
        public IActionResult BuscarCategoriasPaginado([ FromQuery ] CategoriasParametros categoriasParametros)
        {

            try
            {
                // buscar as categorias de forma paginada
                List<Categoria> categorias = this._categoriaRepositorio.BuscarCategoriasPaginado(categoriasParametros);

                if (categorias.Count == 0)
                {

                    return Ok(new List<CategoriaDTO>());
                }

                List<CategoriaDTO> categoriasDTO = new List<CategoriaDTO>();

                foreach (Categoria c in categorias)
                {
                    categoriasDTO.Add(new CategoriaDTO()
                    {
                        CategoriaId = c.CategoriaId,
                        Nome = c.Nome,
                        UrlImagemCategoria = c.UrlImagemCategoria
                    });
                }

                return Ok(categoriasDTO);
            }
            catch (Exception e)
            {

                return BadRequest("Erro: " + e.Message);
            }

        }

        [ HttpGet("buscar-paginado-2") ]
        public IActionResult BuscarCategoriasPaginado2([ FromQuery ] int paginaAtual, int elementosPorPagina)
        {

            try
            {

                if (paginaAtual <= 0)
                {

                    return BadRequest("Página atual inválido!");
                }

                if (elementosPorPagina < _minimoElementosPorPagina || elementosPorPagina > _maximoElementosPorPagina)
                {

                    return BadRequest($"O mínimo de elementos por página é { _minimoElementosPorPagina } e o máximo de elementos por página é { _maximoElementosPorPagina }");
                }

                List<Categoria> categorias = this._contexto.Categorias
                    .OrderBy(c => c.Nome)
                    .Skip((paginaAtual - 1) * elementosPorPagina)
                    .Take(elementosPorPagina)
                    .ToList();

                if (!categorias.Any())
                {

                    return Ok(new List<CategoriaDTO>());
                }

                List<CategoriaDTO> categoriasDTO = new List<CategoriaDTO>();

                foreach (Categoria categoria in categorias)
                {
                    CategoriaDTO categoriaDTO = new CategoriaDTO();
                    categoriaDTO.CategoriaId = categoria.CategoriaId;
                    categoriaDTO.Nome = categoria.Nome;
                    categoriaDTO.UrlImagemCategoria = categoria.UrlImagemCategoria;

                    categoriasDTO.Add(categoriaDTO);
                }

                return Ok(categoriasDTO);
            }
            catch (Exception e)
            {

                return BadRequest($"Erro ao tentar-se consultar as categorias paginado: { e.Message }");
            }

        }

    }
}
