using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.OpcoesMenu
{
    internal class ListaTipoMapa : OpcaoMenu
    {

        public override void ExecutarOpcaoMenu()
        {
            Console.WriteLine("===== Estudando sobre o Dictionary ======");

            Dictionary<String, int> pessoasIdades = new Dictionary<string, int>();

            pessoasIdades.Add("Gabriel", 23);
            pessoasIdades.Add("Maria", 23);
            pessoasIdades.Add("Pedro", 44);

            Console.WriteLine($"idade do Gabriel: { pessoasIdades["Gabriel"] } ");
            Console.WriteLine($"idade da Maria: { pessoasIdades["Maria"] }");

            if (pessoasIdades.ContainsKey("Pedro"))
            {
                Console.WriteLine("Idade do Pedro: " + pessoasIdades["Pedro"]);
            }

            if (pessoasIdades.ContainsValue(44))
            {
                Console.WriteLine("Existe uma pessoa com 44 anos de idade!");
            }

            foreach (var pessoa in pessoasIdades)
            {
                Console.WriteLine($"{ pessoa.Key } possui { pessoa.Value } anos de idade!");
            }

        }

    }
}
