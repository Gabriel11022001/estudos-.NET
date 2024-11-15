using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.OpcoesMenu
{
    internal class LacosRepeticao : OpcaoMenu
    {

        public override void ExecutarOpcaoMenu()
        {
            Console.WriteLine("---- laços de repetição ------");

            int contador = 0;

            while (contador < 10)
            {
                Console.WriteLine(contador);
                contador++;
            }

            contador = 0;

            do
            {
                Console.WriteLine(contador);
                contador++;
            }
            while (contador < 10);

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
            }

            string[] nomes = { "Gabriel", "Pedro", "Matheus", "Maria" };

            for (int contadorNomes = 0; contadorNomes < nomes.Length; contadorNomes++)
            {
                Console.WriteLine(nomes[contadorNomes]);
            }

            foreach (string nome in nomes)
            {
                Console.WriteLine($"nome no foreach: { nome }");
            }

        }

    }
}
