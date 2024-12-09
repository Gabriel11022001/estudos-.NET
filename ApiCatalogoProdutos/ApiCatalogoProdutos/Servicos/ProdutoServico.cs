using ApiCatalogoProdutos.Contexto;
using ApiCatalogoProdutos.DTO;
using ApiCatalogoProdutos.Models;
using ApiCatalogoProdutos.Utils;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoProdutos.Servicos
{
    public class ProdutoServico: Servico
    {

        private readonly IConverter<Produto, ProdutoDTO> _converterListaProdutosEmListaProdutosDTO;
        private readonly IValidador<ProdutoDTO> _validadosDadosCadastroProduto;

        public ProdutoServico(AppDbContexto contexto): base(contexto) 
        {
            this._converterListaProdutosEmListaProdutosDTO = new ConverterListaProdutosBancoDadosListaProdutoDTO();
            this._validadosDadosCadastroProduto = new ValidarDadosProdutoCadastro();
        }

        public async Task<RespostaHttp<List<ProdutoDTO>>> BuscarTodosProdutos()
        {

            try
            {
                List<Produto> produtos = await this._contexto.Produtos.Include(p => p.Categoria).ToListAsync();

                if (produtos.Count == 0)
                {

                    return new RespostaHttp<List<ProdutoDTO>>("Não existem produtos cadastrados na base de dados!", true, new List<ProdutoDTO>());
                }

                List<ProdutoDTO> produtosDTO = this._converterListaProdutosEmListaProdutosDTO.ConverterLista(produtos);

                return new RespostaHttp<List<ProdutoDTO>>("Produtos encontrados com sucesso!", true, produtosDTO);
            }
            catch (Exception e)
            {

                return new RespostaHttp<List<ProdutoDTO>>("Erro ao tentar-se consultar todos os produtos!", false, new List<ProdutoDTO>());
            }

        }

        public async Task<RespostaHttp<ProdutoDTO>> CadastrarProduto(ProdutoDTO produtoDTO)
        {

            try
            {
                String resultadoValidacaoDadosProdutoCadastro = this._validadosDadosCadastroProduto.Validar(produtoDTO);

                if (resultadoValidacaoDadosProdutoCadastro != "")
                {

                    return new RespostaHttp<ProdutoDTO>(resultadoValidacaoDadosProdutoCadastro, false, null);
                }

                // validar se já existe um produto cadastrado com o mesmo nome
            }
            catch (Exception e)
            {

                return new RespostaHttp<ProdutoDTO>($"Erro ao tentar-se cadastrar o produto: { e.Message }", false, null);
            }

        }

    }
}
