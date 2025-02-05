using ApiCatalogoProdutos.Contexto;
using ApiCatalogoProdutos.DTO;
using ApiCatalogoProdutos.Models;
using ApiCatalogoProdutos.Repositorios;
using ApiCatalogoProdutos.Utils;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoProdutos.Servicos
{
    public class ProdutoServico: Servico
    {

        private readonly IConverter<Produto, ProdutoDTO> _converterListaProdutosEmListaProdutosDTO;
        private readonly IValidador<ProdutoDTO> _validadosDadosCadastroProduto;
        private readonly ProdutoRepositorio _produtoRepositorio;
        private readonly CategoriaRepositorio _categoriaRepositorio;

        public ProdutoServico(AppDbContexto contexto): base(contexto) 
        {
            this._converterListaProdutosEmListaProdutosDTO = new ConverterListaProdutosBancoDadosListaProdutoDTO();
            this._validadosDadosCadastroProduto = new ValidarDadosProdutoCadastro();
            this._produtoRepositorio = new ProdutoRepositorio(contexto);
            this._categoriaRepositorio = new CategoriaRepositorio(contexto);
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
                /*String resultadoValidacaoDadosProdutoCadastro = this._validadosDadosCadastroProduto.Validar(produtoDTO);

                if (resultadoValidacaoDadosProdutoCadastro != "")
                {

                    return new RespostaHttp<ProdutoDTO>(resultadoValidacaoDadosProdutoCadastro, false, null);
                }*/

                if (produtoDTO.PrecoCompra <= produtoDTO.PrecoVenda)
                {

                    return new RespostaHttp<ProdutoDTO>("O preço de compra não pode ser menor ou igual ao preço de venda!", false, null);
                }

                // validar se já existe um produto cadastrado com o mesmo nome
                ProdutoDTO produtoCadastradoMesmoNome = await this._produtoRepositorio.BuscarProdutoPeloNome(produtoDTO.Nome);

                if (produtoCadastradoMesmoNome != null)
                {

                    return new RespostaHttp<ProdutoDTO>("Já existe um produto cadastrado com o mesmo nome na base de dados", false, null);
                }

                // validar se existe uma categoria cadastrada com o id informado
                CategoriaDTO categoriaProdutoDTO = await this._categoriaRepositorio.BuscarCategoriaPeloIdAsync(idCategoriaConsultar: produtoDTO.CategoriaId);

                if (categoriaProdutoDTO is null)
                {

                    return new RespostaHttp<ProdutoDTO>("não existe uma categoria cadastrada com esse id!", false, null);
                }

                produtoDTO = await this._produtoRepositorio.CadastrarProdutoAsync(produtoDTO);

                return new RespostaHttp<ProdutoDTO>("Produto cadastrado com sucesso!", true, produtoDTO);
            }
            catch (Exception e)
            {

                return new RespostaHttp<ProdutoDTO>($"Erro ao tentar-se cadastrar o produto: { e.Message }", false, null);
            }

        }

        // buscar produtos de forma assincrona
        public async Task<RespostaHttp<List<ProdutoDTO>>> BuscarProdutosAssincrono()
        {

            try
            {
                var produtos = await this._produtoRepositorio.BuscarProdutosAssincrono();

                if (!produtos.Any())
                {

                    return new RespostaHttp<List<ProdutoDTO>>()
                    {
                        Mensagem = "Não existem produtos cadastrados na base de dados!",
                        Conteudo = new List<ProdutoDTO>(),
                        Ok = true
                    };
                }

                var produtosDTO = new List<ProdutoDTO>();

                foreach (var produto in produtos)
                {
                    var produtoDTO = new ProdutoDTO();
                    produtoDTO.ProdutoId = produto.ProdutoId;
                    produtoDTO.Nome = produto.Nome;
                    produtoDTO.Descricao = produto.Descricao;
                    produtoDTO.PrecoVenda = produto.PrecoVenda;
                    produtoDTO.PrecoCompra = produto.PrecoCompra;
                    produtoDTO.UnidadesEstoque = produto.UnidadesEstoque;
                    produtoDTO.Ativo = produto.Ativo;
                    produtoDTO.UrlImagemProduto = produto.UrlImagemProduto;
                    produtoDTO.CategoriaDTO = new CategoriaDTO()
                    {
                        CategoriaId = produto.Categoria.CategoriaId,
                        Nome = produto.Categoria.Nome,
                        UrlImagemCategoria = produto.Categoria.UrlImagemCategoria
                    };

                    produtosDTO.Add(produtoDTO);
                }

                return new RespostaHttp<List<ProdutoDTO>>()
                {
                    Mensagem = "Produtos listados com sucesso!",
                    Conteudo = produtosDTO,
                    Ok = true
                };
            }
            catch (Exception e)
            {

                return new RespostaHttp<List<ProdutoDTO>>()
                {
                    Mensagem = "Erro ao tentar-se consultar os produtos de forma assincrona!",
                    Conteudo = null,
                    Ok = false
                };
            }

        }

        // buscar produto pelo id assincrono
        public async Task<RespostaHttp<ProdutoDTO>> BuscarProdutoPeloIdAssincrono(int idProdutoConsultar)
        {

            try
            {
                Produto produto = await this._produtoRepositorio.BuscarProdutoPeloIdAssincrono(idProdutoConsultar);

                if (produto is null)
                {

                    return new RespostaHttp<ProdutoDTO>()
                    {
                        Mensagem = "Não existe um produto cadastrado com esse id na base de dados!",
                        Conteudo = null,
                        Ok = false
                    };
                }

                /* ProdutoDTO produtoDTO = new ProdutoDTO();
                produtoDTO.ProdutoId = produto.ProdutoId;
                produtoDTO.Nome = produto.Nome;
                produtoDTO.UnidadesEstoque = produto.UnidadesEstoque;
                produtoDTO.PrecoVenda = produto.PrecoVenda;
                produtoDTO.PrecoCompra = produto.PrecoCompra;
                produtoDTO.Ativo = produto.Ativo;
                produtoDTO.Descricao = produto.Descricao;
                produtoDTO.UrlImagemProduto = produto.UrlImagemProduto;
                produtoDTO.CategoriaDTO = new CategoriaDTO()
                {
                    CategoriaId = produto.Categoria.CategoriaId,
                    Nome = produto.Categoria.Nome,
                    UrlImagemCategoria = produto.Categoria.UrlImagemCategoria
                }; */
                ProdutoDTO produtoDTO = Converter.ConverterProdutoEmProdutoDTO(produto);

                return new RespostaHttp<ProdutoDTO>()
                {
                    Mensagem = "Produto encontrado com sucesso!",
                    Conteudo = produtoDTO,
                    Ok = true
                };
            }
            catch (Exception e)
            {

                return new RespostaHttp<ProdutoDTO>()
                {
                    Mensagem = "Erro ao tentar-se consultar produto pelo id!",
                    Conteudo = null,
                    Ok = false
                };
            }

        }

        public async Task<RespostaHttp<ProdutoCadastrarEditarDTO>> EditarProdutoAssincrono(ProdutoCadastrarEditarDTO produtoCadastrarEditarDTO)
        {

            try
            {
                Produto produtoEditar = await this.ValidarExisteProdutoCadastradoComIdInformado(produtoCadastrarEditarDTO.ProdutoId);

                if (produtoEditar is null)
                {

                    return new RespostaHttp<ProdutoCadastrarEditarDTO>()
                    {
                        Mensagem = "Não existe um produto cadastrado na base de dados com o id informado!",
                        Conteudo = null,
                        Ok = false
                    };
                }

                ProdutoDTO produtoCadastradoMesmoNomeDTO = await this._produtoRepositorio.BuscarProdutoPeloNome(produtoCadastrarEditarDTO.Nome);

                if (produtoCadastradoMesmoNomeDTO is not null && produtoCadastradoMesmoNomeDTO.ProdutoId != produtoEditar.ProdutoId)
                {

                    return new RespostaHttp<ProdutoCadastrarEditarDTO>()
                    {
                        Mensagem = "Já existe outro produto cadastrado com o mesmo nome na base de dados!",
                        Conteudo = null,
                        Ok = false
                    };
                }

                // validar a quantidade de unidades em estoque
                if (produtoCadastrarEditarDTO.UnidadesEstoque < 0)
                {

                    return new RespostaHttp<ProdutoCadastrarEditarDTO>()
                    {
                        Mensagem = "Unidades em estoque inválido!",
                        Ok = false,
                        Conteudo = null
                    };
                }

                // validar preços
                if (produtoCadastrarEditarDTO.PrecoCompra <= 0)
                {

                    return new RespostaHttp<ProdutoCadastrarEditarDTO>()
                    {
                        Mensagem = "Preço de compra inválido!",
                        Ok = false,
                        Conteudo = null
                    };
                }

                if (produtoCadastrarEditarDTO.PrecoVenda <= 0)
                {

                    return new RespostaHttp<ProdutoCadastrarEditarDTO>()
                    {
                        Mensagem = "Preço de venda inválido!",
                        Ok = false,
                        Conteudo = null
                    };
                }

                if (produtoCadastrarEditarDTO.PrecoCompra > produtoCadastrarEditarDTO.PrecoVenda)
                {

                    return new RespostaHttp<ProdutoCadastrarEditarDTO>()
                    {
                        Mensagem = "O preço de compra do produto não pode ser maior que seu preço de venda!",
                        Ok = false,
                        Conteudo = null
                    };
                }

                // validar categoria
                CategoriaDTO categoriaProdutoDTO = await this._categoriaRepositorio.BuscarCategoriaPeloIdAsync(produtoCadastrarEditarDTO.CategoriaId);

                if (categoriaProdutoDTO is null)
                {

                    return new RespostaHttp<ProdutoCadastrarEditarDTO>()
                    {
                        Mensagem = "Não existe uma categoria cadastrada com esse id na base de dados!",
                        Conteudo = null,
                        Ok = false
                    };
                }

                produtoEditar.Nome = produtoCadastrarEditarDTO.Nome;
                produtoEditar.UrlImagemProduto = produtoCadastrarEditarDTO.UrlImagemProduto.Trim();
                produtoEditar.UnidadesEstoque = produtoCadastrarEditarDTO.UnidadesEstoque;
                produtoEditar.PrecoCompra = produtoCadastrarEditarDTO.PrecoCompra;
                produtoEditar.PrecoVenda = produtoCadastrarEditarDTO.PrecoVenda;
                produtoEditar.Descricao = produtoCadastrarEditarDTO.Descricao;
                produtoEditar.CategoriaId = produtoCadastrarEditarDTO.CategoriaId;
                produtoEditar.Ativo = produtoCadastrarEditarDTO.Ativo;

                await this._produtoRepositorio.EditarProdutoAssincrono(produtoEditar);

                return new RespostaHttp<ProdutoCadastrarEditarDTO>()
                {
                    Mensagem = "Produto editado com sucesso!",
                    Conteudo = produtoCadastrarEditarDTO,
                    Ok = true
                };
            }
            catch (Exception e)
            {

                return new RespostaHttp<ProdutoCadastrarEditarDTO>()
                {
                    Mensagem = "Erro ao tentar-se editar os dados do produto!",
                    Conteudo = null,
                    Ok = false
                };
            }

        }

        private async Task<Produto> ValidarExisteProdutoCadastradoComIdInformado(int idProdutoConsultar)
        {

            try
            {
                Produto produtoConsultado = await this._produtoRepositorio.BuscarProdutoPeloIdAssincrono(idProdutoConsultar);

                return produtoConsultado;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

    }
}
