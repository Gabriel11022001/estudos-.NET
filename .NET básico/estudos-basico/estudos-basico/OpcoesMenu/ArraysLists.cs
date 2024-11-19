using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.OpcoesMenu
{

    internal class ArraysLists : OpcaoMenu
    {

        public override void ExecutarOpcaoMenu()
        {
            Console.WriteLine("===== ArrayList =====");

            ArrayList dados = new ArrayList();
            dados.Add(12);
            dados.Add("Gabriel Rodrigues dos Santos");
            dados.Add(12.98);
            dados.Add(false);
            dados.Add(new Aluno("Gabriel", 23));

            for (int contador = 0; contador < dados.Count; contador++)
            {
                Console.WriteLine(dados[ contador ].GetType());
            }

        }

    }
}
