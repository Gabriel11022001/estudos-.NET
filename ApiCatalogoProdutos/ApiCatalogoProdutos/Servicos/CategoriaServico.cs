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

        public CategoriaServico(AppDbContexto contexto)
        {
            this._categoriaRepositorio = new CategoriaRepositorio(contexto);
            this._produtoRepositorio = new ProdutoRepositorio(contexto);
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

    }
}
