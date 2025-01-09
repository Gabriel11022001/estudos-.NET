using ApiCatalogoProdutos.Models;
using ApiCatalogoProdutos.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatalogoProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaUnitOfWorkController : ControllerBase
    {

        private IUnitOfWork _unitOfWorkProjeto;

        public CategoriaUnitOfWorkController(IUnitOfWork unitOfWork)
        {
            this._unitOfWorkProjeto = unitOfWork;
        }

        [ HttpPost ]
        public ActionResult<Categoria> CadastrarCategoria(Categoria categoriaCadastrar)
        {

            try
            {
                // iniciando as transações
                this._unitOfWorkProjeto.BeginTransacoes();
                // adicionando a categoria no contexto
                this._unitOfWorkProjeto.RepositorioCategoriaUnitOfWork.Cadastrar(categoriaCadastrar);
                // salvando as alterações
                this._unitOfWorkProjeto.SalvarAlteracoesContexto();
                // comitando as alterações
                this._unitOfWorkProjeto.CommitTransacoes();

                return Ok(categoriaCadastrar);
            }
            catch (Exception e)
            {
                // realizando o rollback da transação
                this._unitOfWorkProjeto.RollbackTransacoes();

                return BadRequest("Erro ao tentar-se cadastrar a categoria: " + e.Message);
            }

        }

    }
}
