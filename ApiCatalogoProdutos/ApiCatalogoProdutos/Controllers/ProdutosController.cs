using ApiCatalogoProdutos.Contexto;
using ApiCatalogoProdutos.DTO;
using ApiCatalogoProdutos.Models;
using ApiCatalogoProdutos.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoProdutos.Controllers
{
    [Route("api/produto")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {

        private ProdutoServico _produtoServico;
        private readonly AppDbContexto _contextoTeste;

        // injeção de dependencia do contexto na controller
        public ProdutosController(AppDbContexto contexto)
        {
            this._produtoServico = new ProdutoServico(contexto);
            this._contextoTeste = contexto;
        }

        /**
         * a anotação HttpGet define que será utilizado o método
         * http get para realizar essa requisição, eu posso passar a
         * identificação para esse endpoint passando HttpGet("<endpoint>")
         */
        [ HttpGet("/teste-primeira-action") ]
        public string TestePrimeraAction()
        {

            return "Testando a minha primeira action na classe ProdutosController!";
        }

        // devo fazer com que minhas actions retornem um ActionResult
        [ HttpGet("/primeiro-teste-consultar-todos-produtos") ]
        public ActionResult<List<Produto>> BuscarTodosProdutosPrimeiroTeste()
        {
            
            try
            {
                // buscar todos os produtos cadastrados na base de dados
                List<Produto> produtosRetornar = this._contextoTeste.Produtos.ToList();

                if (produtosRetornar.Count > 0)
                {

                    return produtosRetornar;
                }

                return this.NotFound("Não existem produtos cadastrados na base de dados.");
            }
            catch (Exception e)
            {

                return this.BadRequest($"Ocorreu o seguinte erro ao tentar-se consultar os produtos: { e.Message }");
            }

        }

        [ HttpGet("/primeiro-teste-consultar-produto-pelo-id/{idProduto:int}") ]
        public ActionResult<Produto> BuscarProdutoPeloIdPrimeiroTeste(int idProduto)
        {

            try
            {
                // var produtoRetorna = this._contextoTeste.Produtos.FirstOrDefault(p => p.ProdutoId == idProduto);
                // buscar o produto pelo id, retornando a primeira instancia que tiver o ProdutoId == ao idProduto passado como parâmetro
                var produtoRetorna = this._contextoTeste.Produtos.FirstOrDefault<Produto>(p => p.ProdutoId == idProduto);

                if (produtoRetorna is null)
                {

                    // retorna um 404
                    return NotFound("Não existe um produto cadastrado na base de dados com esse id!");
                }

                return produtoRetorna;
            }
            catch (Exception e)
            {

                // retorna um 400
                return BadRequest("Erro ao tentar-se consultar o produto pelo id: " + e.Message);
            }

        }

        [  HttpPost("/cadastrar-produto-primeiro-teste") ]
        public ActionResult<Produto> CadastrarProdutoPrimeiroTeste(ProdutoCadastrarEditarDTO produtoCadastrarDto)
        {

            try
            {
                Produto produtoCadastrar = new Produto()
                {
                    Nome = produtoCadastrarDto.Nome,
                    PrecoCompra = produtoCadastrarDto.PrecoCompra,
                    PrecoVenda = produtoCadastrarDto.PrecoVenda,
                    UnidadesEstoque = produtoCadastrarDto.UnidadesEstoque,
                    Ativo = produtoCadastrarDto.Ativo,
                    UrlImagemProduto = produtoCadastrarDto.UrlImagemProduto,
                    Descricao = produtoCadastrarDto.Descricao,
                    CategoriaId = produtoCadastrarDto.CategoriaId
                };

                // adicionar o produto no contexto da tabela de produtos
                this._contextoTeste.Add(produtoCadastrar);
                // persistir a inserção do produto na base de dados
                this._contextoTeste.SaveChanges();

                return produtoCadastrar;
            }
            catch (Exception e)
            {

                return BadRequest("Erro ao tentar-se cadastrar o produto: " + e.Message);
            }

        }

        [ HttpPut("/editar-produto-primeiro-teste") ]
        public ActionResult<Produto> EditarProdutoPrimeiroTeste(ProdutoCadastrarEditarDTO produtoEditarDto)
        {

            try
            {

                if (!ModelState.IsValid)
                {

                    return BadRequest("Os dados enviados na requisição estão inválidos!");
                }

                Produto produtoEditar = this._contextoTeste.Produtos.Find(produtoEditarDto.ProdutoId);

                if (produtoEditar is null)
                {

                    return NotFound("Não existe um produto cadastrado com esse id na base de dados!");
                }

                produtoEditar.Nome = produtoEditarDto.Nome;
                produtoEditar.PrecoCompra = produtoEditarDto.PrecoCompra;
                produtoEditar.PrecoVenda = produtoEditarDto.PrecoVenda;
                produtoEditar.UnidadesEstoque = produtoEditarDto.UnidadesEstoque;
                produtoEditar.Ativo = produtoEditarDto.Ativo;
                produtoEditar.Descricao = produtoEditarDto.Descricao;
                produtoEditar.CategoriaId = produtoEditarDto.CategoriaId;
                produtoEditar.UrlImagemProduto = produtoEditarDto.UrlImagemProduto;

                // definir que o estado do produto é modificado, definindo que eu posso editar ele
                this._contextoTeste.Entry(produtoEditar).State = EntityState.Modified;
                this._contextoTeste.SaveChanges();

                return produtoEditar;
            }
            catch (Exception e)
            {

                return BadRequest("Erro ao tentar-se editar o produto: " + e.Message);
            }

        }

        [ HttpDelete("/deletar-produto-primeiro-teste/{idProdutoDeletar:int}") ]
        public ActionResult DeletarProdutoPrimeiroTeste(int idProdutoDeletar)
        {

            try
            {
                Produto produtoDeletar = this._contextoTeste.Produtos.FirstOrDefault(p => p.ProdutoId == idProdutoDeletar);

                if (produtoDeletar is null)
                {

                    return NotFound("Não existe um produto com o id informado!");
                }

                // remover o produto do contexto
                this._contextoTeste.Produtos.Remove(produtoDeletar);
                // persistir a deleção do produto na base de dados
                this._contextoTeste.SaveChanges();

                // código http 200
                return Ok("Produto deletado com sucesso!");
            }
            catch (Exception e)
            {

                return BadRequest("Erro ao tentar-se deletar o produto: " + e.Message);
            }

        }

    }
}
