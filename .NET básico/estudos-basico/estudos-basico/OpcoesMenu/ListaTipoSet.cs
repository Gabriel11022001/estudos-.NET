using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.OpcoesMenu
{
    internal class ListaTipoSet : OpcaoMenu
    {

        public override void ExecutarOpcaoMenu()
        {
            Console.WriteLine("===== Set ======");
            // o set é uma estrutura que não aceita repetição e não é indexado
            HashSet<String> nomes = new HashSet<string>();

            nomes.Add("Gabriel");
            nomes.Add("Pedro");
            nomes.Add("Gabriel");
            nomes.Add("Maria");
            nomes.Add("Pedro");

            foreach (string nome in nomes)
            {
                Console.WriteLine($"nome: { nome }");
            }

        }

    }
}
