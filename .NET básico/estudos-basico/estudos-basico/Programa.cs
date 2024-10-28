using estudos_basico.OpcoesMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico
{
    internal class Programa
    {

        public static void Executar()
        {
            int opcao = 0;

            Console.WriteLine("Informe uma opção");
            Console.WriteLine("1 - variáveis e tipos");
            Console.WriteLine("2 - strings");

            opcao = Int32.Parse(Console.ReadLine());

            OpcaoMenu opcaoMenu = null;

            if (opcao == 1)
            {
                opcaoMenu = new VariaveisETipos();
            } 
            else if (opcao == 2)
            {
                opcaoMenu = new EstudoStrings();
            }

            opcaoMenu.ExecutarOpcaoMenu();
        }

    }
}
