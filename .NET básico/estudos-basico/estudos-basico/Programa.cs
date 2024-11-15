using estudos_basico.OpcoesMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            Console.WriteLine("0 - exercícios");
            Console.WriteLine("1 - variáveis e tipos");
            Console.WriteLine("2 - strings");
            Console.WriteLine("3 - operadores");
            Console.WriteLine("4 - estruturas condicionais");
            Console.WriteLine("5 - laços de repetição");
            Console.WriteLine("6 - classes e objetos");
            Console.WriteLine("7 - métodos");
            Console.WriteLine("8 - getter e setter");

            opcao = Int32.Parse(Console.ReadLine());

            OpcaoMenu opcaoMenu = null;

            if (opcao == 0)
            {
                opcaoMenu = new OpcoesMenu.Exercicios();
            }
            else if (opcao == 1)
            {
                opcaoMenu = new VariaveisETipos();
            } 
            else if (opcao == 2)
            {
                opcaoMenu = new EstudoStrings();
            }
            else if (opcao == 3)
            {
                opcaoMenu = new Operadores();
            } 
            else if (opcao == 4)
            {
                opcaoMenu = new EstruturasCondicionais();
            }
            else if (opcao == 5)
            {
                opcaoMenu = new LacosRepeticao();
            }
            else if (opcao == 6)
            {
                opcaoMenu = new ClassesObjetos();
            }
            else if (opcao == 7)
            {
                opcaoMenu = new Metodos();
            }
            else if (opcao == 8)
            {
                opcaoMenu = new GettersSetters();
            }

            opcaoMenu.ExecutarOpcaoMenu();
        }

    }
}
