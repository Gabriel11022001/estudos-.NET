using ApiCatalogoProdutos.Contexto;
using ApiCatalogoProdutos.DTO;
using ApiCatalogoProdutos.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatalogoProdutos.Controllers
{
    [Route("api/categoria/")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {

        private CategoriaServico _categoriaServico;

        public CategoriasController(AppDbContexto contexto)
        {
            this._categoriaServico = new CategoriaServico(contexto);
        }

        // cadastrar categoria
        [ HttpPost ]
        public ActionResult<RespostaHttp<bool>> CadastrarCategoria(CategoriaDTO categoriaDTO)
        {
            RespostaHttp<bool> respostaCadastroCategoria = this._categoriaServico.CadastrarCategoria(categoriaDTO);

            if (respostaCadastroCategoria.Ok)
            {

                return Ok(respostaCadastroCategoria);
            }

            return BadRequest(respostaCadastroCategoria);
        }

        // buscar todas as categorias
        [ HttpGet ]
        public ActionResult<RespostaHttp<List<CategoriaDTO>>> BuscarTodasCategorias()
        {
            RespostaHttp<List<CategoriaDTO>> respostaConsultarTodasCategorias = this._categoriaServico.BuscarTodasCategorias();

            return respostaConsultarTodasCategorias.Ok ? 
                Ok(respostaConsultarTodasCategorias) : 
                BadRequest(respostaConsultarTodasCategorias);
        }

        [ HttpGet("{id:int}") ]
        public ActionResult<RespostaHttp<CategoriaDTO>> BuscarCategoriaPeloId(int id)
        {
            RespostaHttp<CategoriaDTO> respostaConsultarCategoriaPeloId = this._categoriaServico.BuscarCategoriaPeloId(id);

            if (!respostaConsultarCategoriaPeloId.Ok)
            {

                return BadRequest(respostaConsultarCategoriaPeloId);
            }

            if (respostaConsultarCategoriaPeloId.Mensagem == "Não existe uma categoria cadastrada com esse id!")
            {

                return NotFound(respostaConsultarCategoriaPeloId);
            }

            return Ok(respostaConsultarCategoriaPeloId);
        }

    }
}
