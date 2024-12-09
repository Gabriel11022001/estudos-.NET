using ApiCatalogoProdutos.Contexto;
using ApiCatalogoProdutos.DTO;
using ApiCatalogoProdutos.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatalogoProdutos.Controllers
{
    // /api/categorias<nome da controller no plural>
    [Route("api/[controller]/")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {

        private CategoriaServico _categoriaServico;

        public CategoriasController(AppDbContexto contexto)
        {
            this._categoriaServico = new CategoriaServico(contexto);
        }

        // cadastrar categoria
        // /api/categorias/
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
        // /api/categorias/
        [ HttpGet ]
        public ActionResult<RespostaHttp<List<CategoriaDTO>>> BuscarTodasCategorias()
        {
            RespostaHttp<List<CategoriaDTO>> respostaConsultarTodasCategorias = this._categoriaServico.BuscarTodasCategorias();

            return respostaConsultarTodasCategorias.Ok ? 
                Ok(respostaConsultarTodasCategorias) : 
                BadRequest(respostaConsultarTodasCategorias);
        }

        // buscar categoria pelo id
        // /api/categorias/{id da categoria}
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

        // deletar categoria
        // /api/categorias/{ id da categoria para deleção }
        [ HttpDelete ]
        public ActionResult<RespostaHttp<Boolean>> DeletarCategoria(int idCategoriaDeletar)
        {
            RespostaHttp<Boolean> respostaDeletarCategoria = this._categoriaServico.DeletarCategoria(idCategoriaDeletar);

            if (respostaDeletarCategoria.Ok)
            {

                if (respostaDeletarCategoria.Mensagem == "Não foi encontrada uma categoria cadastrada com o id informado")
                {

                    return NotFound(respostaDeletarCategoria);
                }

                return Ok(respostaDeletarCategoria);
            }
            else
            {

                return BadRequest(respostaDeletarCategoria);
            }

        }

    }
}
