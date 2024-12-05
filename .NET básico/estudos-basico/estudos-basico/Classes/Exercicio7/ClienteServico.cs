using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Classes.Exercicio7
{
    internal class ClienteServico
    {

        private ClienteRepositorio _clienteRepositorio;

        public ClienteServico()
        {
            this._clienteRepositorio = new ClienteRepositorio();
        }

        public RespostaBase<Cliente> SalvarCliente(Cliente clienteSalvar)
        {
            var respostaBase = new RespostaBase<Cliente>();

            try
            {
                
                if (clienteSalvar.Id == 0)
                {
                    // cadastrar um novo cliente
                    respostaBase = this.CadastrarCliente(clienteSalvar);
                }
                else
                {
                    // editar os dados do cliente
                    respostaBase = this.EditarCliente(clienteSalvar);
                }

            }
            catch (Exception e)
            {
                respostaBase.Ok = false;
                respostaBase.Mensagem = "Erro ao tentar-se salvar o cliente: " + e.Message;
            }

            return respostaBase;
        }

        private RespostaBase<Cliente> CadastrarCliente(Cliente clienteCadastrar)
        {
            RespostaBase<Cliente> resposta = new RespostaBase<Cliente>();

            try
            {

                if (clienteCadastrar.NomeCompleto.Trim() == "")
                {
                    resposta.Ok = false;
                    resposta.Mensagem = "Informe o nome do cliente!";
                }
                else if (clienteCadastrar.Email.Trim() == "")
                {
                    resposta.Ok = false;
                    resposta.Mensagem = "Informe o e-mail do cliente!";
                }
                else if (!ValidaDados.ValidarEmail(clienteCadastrar.Email))
                {
                    resposta.Ok = false;
                    resposta.Mensagem = "E-mail inválido!";
                }
                else if (clienteCadastrar.Genero.Trim() == "")
                {
                    resposta.Ok = false;
                    resposta.Mensagem = "Informe o e-mail do cliente!";
                }
                else if (!ValidaDados.ValidarGenero(clienteCadastrar.Genero))
                {
                    resposta.Ok = false;
                    resposta.Mensagem = "Gênero inválido!";
                }
                else if (!ValidaDados.ValidarEndereco(clienteCadastrar.Endereco))
                {
                    resposta.Ok = false;
                    resposta.Mensagem = "Endereço inválido!";
                }
                else
                {
                    // todos os dados são válidos
                    bool cadastroEfetivadoComSucesso = this._clienteRepositorio.Cadastrar(clienteCadastrar);

                    if (cadastroEfetivadoComSucesso)
                    {
                        resposta.Ok = true;
                        resposta.Mensagem = "Cliente cadastrado com sucesso!";
                        resposta.Conteudo = clienteCadastrar;
                    }
                    else
                    {
                        resposta.Ok = false;
                        resposta.Mensagem = "Ocorreu um erro ao tentar-se cadastrar o cliente!";
                    }

                }

            }
            catch (Exception e)
            {
                resposta.Ok = false;
                resposta.Mensagem = "Erro ao tentar-se cadastrar um cliente: " + e.Message;
            }

            return resposta;
        }

        private RespostaBase<Cliente> EditarCliente(Cliente clienteEditar)
        {

            return null;
        }

        public RespostaBase<List<Cliente>> BuscarTodosClientes()
        {
            RespostaBase<List<Cliente>> resposta = new RespostaBase<List<Cliente>>();

            try
            {
                List<Cliente> clientes = this._clienteRepositorio.BuscarTodosClientes();

                if (clientes.Count == 0)
                {
                    resposta.Ok = true;
                    resposta.Mensagem = "Não existem clientes cadastrados na base de dados!";
                }
                else
                {
                    resposta.Ok = true;
                    resposta.Mensagem = "Clientes listados com sucesso!";
                    resposta.Conteudo = clientes;
                }

            }
            catch (Exception e)
            {
                resposta.Ok = false;
                resposta.Mensagem = $"Erro ao tentar-se consultar os dados dos clientes cadastrados na base de dados: { e.Message }";
            }

            return resposta;
        }

    }
}
