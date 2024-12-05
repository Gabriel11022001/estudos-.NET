using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Classes.Exercicio7
{
    internal interface IClienteRepositorio: IRepositorio<Cliente>
    {

        List<Cliente> BuscarTodosClientes();

        Cliente BuscarClientePeloNome(String nomeCliente);

        Cliente BuscarClientePeloEmail(String email);

        Cliente BuscarClientePeloId(int IdCliente);

    }
}
