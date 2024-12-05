using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Classes.Exercicio7
{
    internal class ClienteRepositorio : IClienteRepositorio
    {
        /**
         * esse objeto representa o meu banco de dados
         */
        private List<Cliente> _clientes = new List<Cliente>();

        public Cliente BuscarClientePeloId(int IdCliente)
        {
            Cliente cliente = null;

            foreach (Cliente cli in this._clientes)
            {

                if (cli.Id == IdCliente)
                {
                    cliente = cli;
                }

            }

            return cliente;
        }

        public Cliente BuscarClientePeloEmail(string email)
        {
            Cliente cliente = null;

            this._clientes.ForEach(clienteConsultar =>
            {

                if (clienteConsultar.Email == email)
                {
                    cliente = clienteConsultar;
                }

            });

            return cliente;
        }

        public Cliente BuscarClientePeloNome(string nomeCliente)
        {
            Cliente cliente = null;

            this._clientes.ForEach(clienteConsultar =>
            {

                if (clienteConsultar.NomeCompleto == nomeCliente)
                {
                    cliente = clienteConsultar;
                }

            });

            return cliente;
        }

        public List<Cliente> BuscarTodosClientes()
        {

            return this._clientes;
        }

        public bool Cadastrar(Cliente entidade)
        {
            this._clientes.Add(entidade);

            return true;
        }

        public bool Editar(Cliente entidade)
        {
            Cliente clienteEditar = null;

            foreach (Cliente clienteEncontrado in this._clientes)
            {

                if (clienteEncontrado.Id == entidade.Id)
                {
                    clienteEditar = clienteEncontrado;
                }

            }

            if (clienteEditar != null)
            {
                clienteEditar = entidade;
            }

            return true;
        }

    }
}
