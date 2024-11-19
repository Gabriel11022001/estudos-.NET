using estudos_basico.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Exercicios
{
    internal class Exercicio3 : Exercicio
    {

        public override void Executar()
        {

            try
            {
                ListaGenerica<String> listaGenericaNomes = new ListaGenerica<string>();
                ListaGenerica<int> listaGenericaIdades = new ListaGenerica<int>();

                listaGenericaNomes.Adicionar("Gabriel Rodrigues dos Santos");
                listaGenericaNomes.Adicionar("Maria Fernanda da Silva");

                listaGenericaNomes.ApresentarElementos();

                listaGenericaIdades.Adicionar(23);
                listaGenericaIdades.Adicionar(24);

                listaGenericaIdades.ApresentarElementos();

                listaGenericaNomes.Adicionar("Gabriel Mariano da Silva", "Eduarda Pietro da Silva", "Gustavo Fernando Pereira");

                listaGenericaNomes.ApresentarElementos();

                listaGenericaNomes.RemoverPeloIndice(4);

                listaGenericaNomes.ApresentarElementos();

                listaGenericaNomes.RemoverPeloIndice(4);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }

        }

    }
}
