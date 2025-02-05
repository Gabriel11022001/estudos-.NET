using ApiCatalogoProdutos.Contexto;
using ApiCatalogoProdutos.DTO;
using ApiCatalogoProdutos.Models;
using ApiCatalogoProdutos.Repositorios;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace ApiCatalogoProdutos.Servicos
{
    public class CategoriaServico
    {

        private CategoriaRepositorio _categoriaRepositorio;
        private ProdutoRepositorio _produtoRepositorio;
        private CategoriaRepositorioAssincrono _categoriaRepositorioAssinc;

        public CategoriaServico(AppDbContexto contexto)
        {
            this._categoriaRepositorio = new CategoriaRepositorio(contexto);
            this._produtoRepositorio = new ProdutoRepositorio(contexto);
            this._categoriaRepositorioAssinc = new CategoriaRepositorioAssincrono(contexto);
        }

        public RespostaHttp<bool> CadastrarCategoria(CategoriaDTO categoriaCadastrarDTO)
        {

            try
            {
                // validar se informou o nome da categoria
                if (categoriaCadastrarDTO.Nome == "")
                {

                    return new RespostaHttp<bool>("Informe o nome da categoria!", false, false);
                }

                // validar se informou a url da imagem da categoria
                if (categoriaCadastrarDTO.UrlImagemCategoria == "")
                {

                    return new RespostaHttp<bool>("Informe a url da imagem da categoria!", false, false);
                }

                // validar se já existe uma categoria cadastrada com o mesmo nome informado
                CategoriaDTO categoriaNomeInformado = this._categoriaRepositorio.BuscarCategoriaPeloNome(categoriaCadastrarDTO.Nome);

                if (categoriaNomeInformado is not null)
                {

                    return new RespostaHttp<bool>("Já existe uma categoria cadastrada com esse nome!", false, false);
                }

                this._categoriaRepositorio.Cadastrar(categoriaCadastrarDTO);

                return new RespostaHttp<bool>()
                {
                    Mensagem = "Categoria cadastrada com sucesso!",
                    Ok = true,
                    Conteudo = true
                };
            }
            catch (Exception e)
            {

                return new RespostaHttp<bool>("Erro ao tentar-se cadastrar a categoria: " + e.Message, false, false);
            }

        }

        public RespostaHttp<List<CategoriaDTO>> BuscarTodasCategorias()
        {
            
            try
            {
                List<CategoriaDTO> categorias = this._categoriaRepositorio.BuscarTodos();

                if (categorias.Count > 0)
                {

                    return new RespostaHttp<List<CategoriaDTO>>("Categorias encontradas com sucesso!", true, categorias);
                }

                return new RespostaHttp<List<CategoriaDTO>>("Não existem categorias cadastradas na base de dados!", true, categorias);
            }
            catch (Exception e)
            {

                return new RespostaHttp<List<CategoriaDTO>>("Erro: " + e.Message, false, new List<CategoriaDTO>());
            }

        }

        public RespostaHttp<CategoriaDTO> BuscarCategoriaPeloId(int idCategoria)
        {

            try
            {
                CategoriaDTO categoriaDTO = this._categoriaRepositorio.BuscarPeloId(idCategoria);

                if (categoriaDTO is null)
                {

                    return new RespostaHttp<CategoriaDTO>()
                    {
                        Mensagem = "Não existe uma categoria cadastrada com esse id!",
                        Ok = true,
                        Conteudo = null
                    };
                }

                return new RespostaHttp<CategoriaDTO>()
                {
                    Mensagem = "Categoria encontrada com sucesso!",
                    Ok = true,
                    Conteudo = categoriaDTO
                };
            }
            catch (Exception e)
            {

                return new RespostaHttp<CategoriaDTO>()
                {
                    Mensagem = $"Erro: { e.Message }",
                    Ok = false,
                    Conteudo = null
                };
            }

        }

        public RespostaHttp<Boolean> DeletarCategoria(int idCategoriaDeletar)
        {

            try
            {
                CategoriaDTO categoriaDeletarDTO = this._categoriaRepositorio.BuscarPeloId(idCategoriaDeletar);

                if (categoriaDeletarDTO is null)
                {

                    return new RespostaHttp<bool>("Não foi encontrada uma categoria cadastrada com o id informado!", true, false);
                }

                // validar se existem produtos relacionados a categoria em questão
                List<ProdutoDTO> produtosCategoria = this._produtoRepositorio.BuscarProdutosPelaCategoria(idCategoriaDeletar);

                if (produtosCategoria.Count > 0)
                {

                    return new RespostaHttp<bool>("Existem produtos relacionados a essa categoria!", false, false);
                }

                this._categoriaRepositorio.DeletarCategoria(idCategoriaDeletar);

                return new RespostaHttp<bool>("Categoria deletada com sucesso da base de dados!", true, false);
            }
            catch (Exception e)
            {

                return new RespostaHttp<bool>()
                {
                    Mensagem = "Erro ao tentar-se deletar a categoria: " + e.Message,
                    Ok = false,
                    Conteudo = false
                };
            }

        }

        // buscar todas as categorias na base de dados de forma assinc
        public async Task<RespostaHttp<List<CategoriaDTO>>> BuscarTodasCategoriasAssincrono()
        {

            try
            {
                List<Categoria> categorias = await this._categoriaRepositorioAssinc.BuscarTodasCategorias();

                if (categorias.Count > 0)
                {
                    List<CategoriaDTO> categoriasDTO = new List<CategoriaDTO>();

                    foreach (Categoria categoria in categorias)
                    {
                        CategoriaDTO categoriaDTO = new CategoriaDTO();
                        categoriaDTO.CategoriaId = categoria.CategoriaId;
                        categoriaDTO.Nome = categoria.Nome;
                        categoriaDTO.UrlImagemCategoria = categoria.UrlImagemCategoria;

                        categoriasDTO.Add(categoriaDTO);
                    }

                    return new RespostaHttp<List<CategoriaDTO>>()
                    {
                        Mensagem = "Categorias encontradas com sucesso!",
                        Conteudo = categoriasDTO,
                        Ok = true
                    };
                }

                return new RespostaHttp<List<CategoriaDTO>>()
                {
                    Mensagem = "Não existem categorias cadastradas na base de dados!",
                    Conteudo = new List<CategoriaDTO>(),
                    Ok = true
                };
            }
            catch (Exception e)
            {
                return new RespostaHttp<List<CategoriaDTO>>()
                {
                    Mensagem = "Erro ao tentar-se consultar as categorias assinc!",
                    Ok = false,
                    Conteudo = new List<CategoriaDTO>()
                };
            }

        }

        // buscar categoria pelo id de forma assinc
        public async Task<RespostaHttp<CategoriaDTO>> BuscarCategoriaPeloIdAssincrono(int id)
        {

            try
            {
                Categoria categoria = await this._categoriaRepositorioAssinc.BuscarCategoriaPeloId(id);

                if (categoria is not null)
                {
                    CategoriaDTO categoriaDTO = new CategoriaDTO(categoria);

                    return new RespostaHttp<CategoriaDTO>()
                    {
                        Mensagem = "Categoria encontrada com sucesso!",
                        Conteudo = categoriaDTO,
                        Ok = true
                    };
                }

                return new RespostaHttp<CategoriaDTO>()
                {
                    Mensagem = "Não existe uma categoria com esse id!",
                    Ok = false,
                    Conteudo = null
                };
            }
            catch (Exception e)
            {

                return new RespostaHttp<CategoriaDTO>()
                {
                    Mensagem = "Erro ao tentar-se consultar a categoria pelo id!",
                    Conteudo = null,
                    Ok = false
                };
            }

        }

        // cadastrar categoria de forma assincrona
        public async Task<RespostaHttp<CategoriaDTO>> CadastrarCategoriaAssincrono(CategoriaDTO categoriaDTO)
        {

            try
            {
                // validar se já existe uma categoria cadastrada com o mesmo nome
                Categoria categoriaCadastradaMesmoNome = await this._categoriaRepositorioAssinc.BuscarCategoriaPeloNomeAssincrono(categoriaDTO.Nome);

                if (categoriaCadastradaMesmoNome is not null)
                {

                    return new RespostaHttp<CategoriaDTO>()
                    {
                        Mensagem = "Já existe outra categoia cadastrada com o mesmo nome!",
                        Conteudo = null,
                        Ok = false
                    };
                }

                Categoria categoriaCadastrar = new Categoria();
                categoriaCadastrar.Nome = categoriaDTO.Nome.Trim();
                categoriaCadastrar.UrlImagemCategoria = categoriaDTO.UrlImagemCategoria;

                await this._categoriaRepositorioAssinc.CadastrarCategoria(categoriaCadastrar);

                categoriaDTO.CategoriaId = categoriaCadastrar.CategoriaId;

                return new RespostaHttp<CategoriaDTO>()
                {
                    Mensagem = "Categoria cadastrada com sucesso!",
                    Conteudo = categoriaDTO,
                    Ok = true
                };
            }
            catch (Exception e)
            {

                return new RespostaHttp<CategoriaDTO>()
                {
                    Mensagem = "Erro ao tentar-se cadastrar a categoria!",
                    Conteudo = null,
                    Ok = false
                };
            }

        }

        // editar categoria de forma assincrona
        public async Task<RespostaHttp<CategoriaDTO>> EditarCategoriaAssincrono(CategoriaDTO categoriaDTO)
        {
            RespostaHttp<CategoriaDTO> resposta = new RespostaHttp<CategoriaDTO>();

            try
            {
                Categoria categoriaEditar = await this._categoriaRepositorioAssinc.BuscarCategoriaPeloId(categoriaDTO.CategoriaId);

                if (categoriaEditar is null)
                {
                    resposta.Mensagem = "Não existe uma categoria cadastrada com esse id na base de dados!";
                    resposta.Conteudo = null;
                    resposta.Ok = false;
                }
                else
                {
                    // validar se já existe outra categoria cadastrada com o mesmo nome
                    Categoria categoriaCadastradaMesmoNome = await this._categoriaRepositorioAssinc.BuscarCategoriaPeloNomeAssincrono(categoriaDTO.Nome);

                    if (categoriaCadastradaMesmoNome is not null && categoriaCadastradaMesmoNome.CategoriaId != categoriaEditar.CategoriaId)
                    {
                        resposta.Mensagem = "Já existe outra categoria cadastrada com esse nome!";
                        resposta.Ok = false;
                        resposta.Conteudo = null;
                    }
                    else
                    {
                        categoriaEditar.Nome = categoriaDTO.Nome;
                        categoriaEditar.UrlImagemCategoria = categoriaDTO.UrlImagemCategoria;

                        await this._categoriaRepositorioAssinc.EditarCategoria(categoriaEditar);

                        resposta.Mensagem = "Categoria editada com sucesso!";
                        resposta.Conteudo = categoriaDTO;
                        resposta.Ok = true;
                    }

                }

            }
            catch (Exception e)
            {
                resposta.Mensagem = "Erro ao tentar-se editar a categoria!";
                resposta.Conteudo = null;
                resposta.Ok = false;
            }

            return resposta;
        }

    }
}
