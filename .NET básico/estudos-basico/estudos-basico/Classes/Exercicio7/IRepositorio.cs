using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Classes.Exercicio7
{
    internal interface IRepositorio<T>
    {

        bool Cadastrar(T entidade);

        bool Editar(T entidade);

    }
}
