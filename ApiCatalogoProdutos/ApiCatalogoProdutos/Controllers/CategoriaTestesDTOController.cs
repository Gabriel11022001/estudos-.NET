using ApiCatalogoProdutos.DTO;
using ApiCatalogoProdutos.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatalogoProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaTestesDTOController : ControllerBase
    {

        private ICategoriaRepositorioTestesDTO _categoriaRepositorio;

        public CategoriaTestesDTOController(ICategoriaRepositorioTestesDTO categoriaRepositorioTestesDTO)
        {
            this._categoriaRepositorio = categoriaRepositorioTestesDTO;
        }

        [ HttpPost ]
        public ActionResult<CategoriaDTOTeste> CadastrarCategoria(CategoriaDTOTeste categoriaDTOTesteCadastrar)
        {
            
            try
            {
                // validar se já existe outra categoria cadastrada com o mesmo nome
                if (this._categoriaRepositorio.BuscarCategoriaPeloNome(categoriaDTOTesteCadastrar.Nome) is not null)
                {

                    return BadRequest("Já existe uma categoria cadastrada com esse mesmo nome!");
                }

                this._categoriaRepositorio.Cadastrar(categoriaDTOTesteCadastrar);

                return Ok(categoriaDTOTesteCadastrar);
            }
            catch (Exception e)
            {

                return BadRequest("Erro ao tentar-se cadastrar a categoria: " + e.Message);
            }

        }

        [ HttpPut ]
        public ActionResult<CategoriaDTOTeste> EditarCategoria(CategoriaDTOTeste categoriaDTOTeste)
        {

            try
            {
                // validar se já não existe outra categoria cadastrada com o nome informado
                CategoriaDTOTeste categoriaDTOTesteCadastradoMesmoNome = this._categoriaRepositorio.BuscarCategoriaPeloNome(categoriaDTOTeste.Nome);

                if (categoriaDTOTesteCadastradoMesmoNome is  not null && categoriaDTOTesteCadastradoMesmoNome.CategoriaId != categoriaDTOTeste.CategoriaId)
                {

                    return BadRequest("Já existe outra categoria cadastrada com o mesmo nome!");
                }

                this._categoriaRepositorio.Editar(categoriaDTOTeste);

                return Ok(categoriaDTOTeste);
            }
            catch (Exception e)
            {

                return BadRequest("Erro ao tentar-se editar a categoria na base de dados: " + e.Message);
            }

        }

        [ HttpGet ]
        public ActionResult<List<CategoriaDTOTeste>> BuscarTodasCategorias()
        {

            try
            {
                var categorias = this._categoriaRepositorio.BuscarTodasCategorias();

                if (categorias.Count == 0)
                {

                    return Ok("Não existem categorias cadastradas na base de dados!");
                }

                return Ok(categorias);
            }
            catch (Exception e)
            {

                return BadRequest("Erro ao tentar-se consultar todas as categorias: " + e.Message);
            }

        }

        [ HttpGet("{id:int}") ]
        public ActionResult<CategoriaDTOTeste> BuscarCategoriaPeloId(int id)
        {

            try
            {
                var categoria = this._categoriaRepositorio.BuscarCategoriaPeloId(id);

                if (categoria is null)
                {

                    return NotFound("Não existe uma categoria cadastrada com esse id na base de dados!");
                }

                return Ok(categoria);
            }
            catch (Exception e)
            {

                return BadRequest("Erro ao tentar-se consultar a categoria pelo id: " + e.Message);
            }

        }

        [ HttpGet("buscar-categoria-pelo-nome/{nomeCategoriaConsultar}") ]
        public ActionResult<CategoriaDTOTeste> BuscarCategoriaPeloNome(string nomeCategoriaConsultar)
        {

            try
            {
                CategoriaDTOTeste categoriaDTOTeste = this._categoriaRepositorio.BuscarCategoriaPeloNome(nomeCategoriaConsultar);

                return categoriaDTOTeste is null ? NotFound("Não existe uma categoria cadastrada na base de dados com esse nome!") : Ok(categoriaDTOTeste);
            }
            catch (Exception e)
            {

                return BadRequest("Erro ao tentar-se consultar a categoria pelo nome: " + e.Message);
            }

        }

    }
}
