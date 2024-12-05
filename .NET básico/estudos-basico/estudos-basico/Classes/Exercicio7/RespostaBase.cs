using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Classes.Exercicio7
{
    internal class RespostaBase<T>
    {

        public String Mensagem { get; set; }
        public  Boolean Ok { get; set; }
        public T Conteudo { get; set; }

    }
}
