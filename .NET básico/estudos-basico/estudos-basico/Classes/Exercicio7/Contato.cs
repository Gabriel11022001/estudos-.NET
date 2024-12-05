using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Classes.Exercicio7
{
    internal class Contato
    {

        public String TipoContato { get; set; }
        public String DescricaoContato { get; set; }

        public void ApresentarContato()
        {
            Console.WriteLine("Tipo do contato: " + this.TipoContato);
            Console.WriteLine("Contato: " + this.DescricaoContato);
        }

    }
}
