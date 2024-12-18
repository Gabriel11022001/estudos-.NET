using ApiCatalogoProdutos.DTO;
using ApiCatalogoProdutos.Models;
using ApiCatalogoProdutos.Repositorios;
using ApiCatalogoProdutos.Utils;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatalogoProdutos.Controllers
{
    [ Route("api/[controller]") ]
    [ ApiController ]
    public class CategoriaControllerTestesCamadaRepositorio: ControllerBase
    {

        private readonly ICategoriaProdutoRepositorio _categoriaRepositorio;
        private readonly IConverter<Categoria, CategoriaDTO> _converterListaCategoriasEmListaCategoriaDTO;

        /**
         * vou passar uma instancia de CategoriaRepositorioNovo injetando no construtor
         */
        public CategoriaControllerTestesCamadaRepositorio(ICategoriaProdutoRepositorio categoriaRepositorio)
        {
            this._categoriaRepositorio = categoriaRepositorio;
            this._converterListaCategoriasEmListaCategoriaDTO = new ConverterListaCategoriaEmListaCategoriaDTO();
        }

        [ HttpPost ]
        public async Task<ActionResult<CategoriaDTO>> CadastrarCategoria(CategoriaDTO categoriaDTOCadastrar)
        {

            try
            {
                // validar se já existe outra categoria cadastrada com o mesmo nome
                String nomeCategoriaValidar = categoriaDTOCadastrar.Nome.ToLower();
                if (this._categoriaRepositorio.BuscarCategoriaPeloNome(nomeCategoriaValidar) is not null)
                {

                    return BadRequest("Já existe uma categoria cadastrada com esse nome!");
                }

                Categoria categoria = new Categoria();
                categoria.Nome = categoriaDTOCadastrar.Nome;
                categoria.UrlImagemCategoria = categoriaDTOCadastrar.UrlImagemCategoria;

                await this._categoriaRepositorio.CadastrarCategoria(categoria);

                categoriaDTOCadastrar.CategoriaId = categoria.CategoriaId;

                Dictionary<String, CategoriaDTO> resposta = new Dictionary<string, CategoriaDTO>();
                resposta.Add("Categoria cadastrada com sucesso!", categoriaDTOCadastrar);

                return Ok(resposta);
            }
            catch (Exception e)
            {

                return BadRequest($"Erro ao tentar-se cadastrar a categoria: { e.Message }");
            }

        }

        [ HttpGet ]
        public async Task<ActionResult<List<CategoriaDTO>>> BuscarTodasCategorias()
        {

            try
            {
                List<Categoria> categorias = await this._categoriaRepositorio.BuscarTodasCategorias();

                if (categorias.Count == 0)
                {

                    return Ok("Não existem categorias cadastradas na base de dados!");
                }

                List<CategoriaDTO> categoriasConvertidas = this._converterListaCategoriasEmListaCategoriaDTO
                    .ConverterLista(categorias);

                return Ok(categoriasConvertidas);
            }
            catch (Exception e)
            {

                return BadRequest($"Erro ao tentar-se obter todas as categorias cadastradas na base de dados: { e.Message }");
            }

        }

        [ HttpGet("{id:int}") ]
        public async Task<ActionResult<CategoriaDTO>> BuscarCategoriaPeloId(int id)
        {

            try
            {

                if (id <= 0)
                {

                    return BadRequest("Informe o id da categoria!");
                }

                Categoria categoria = await this._categoriaRepositorio.BuscarCategoriaPeloId(id);

                if (categoria is null)
                {

                    return NotFound("Não foi encontrada uma categoria com esse id!");
                }

                return Ok(new CategoriaDTO(categoria));
            }
            catch (Exception e)
            {

                return BadRequest("Erro ao tentar-se buscar a categoria pelo id: " + e.Message);
            }

        }

        [ HttpDelete("{idCategoriaDeletar:int}") ]
        public async Task<ActionResult> DeletarCategoria(int idCategoriaDeletar)
        {

            try
            {
                // validar se existe a categoria com esse id
                Categoria categoriaDeletar = await this._categoriaRepositorio.BuscarCategoriaPeloId(idCategoriaDeletar);

                if (categoriaDeletar is null)
                {

                    return NotFound("Não existe uma categoria cadastrada com esse id!");
                }

                // validar se existem produtos relacionados a essa categoria
                List<Produto> produtosCategoria = await this._categoriaRepositorio.BuscarProdutosRelacionadosCategoria(idCategoriaDeletar);

                if (produtosCategoria.Count > 0)
                {

                    produtosCategoria.ForEach(p => Console.WriteLine($"Categoria do produto: { p.CategoriaId }"));

                    return BadRequest("Essa categoria possui produtos relacionados, não é possível deletar a mesma!");
                }

                await this._categoriaRepositorio.DeletarCategoria(idCategoriaDeletar);

                return Ok("Categoria deletada com sucesso!");
            }
            catch (Exception e)
            {

                return BadRequest("Erro ao tentar-se deletar a categoria: " + e.Message);
            }

        }

    }
}
