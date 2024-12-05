using estudos_basico.OpcoesMenu;
using System;
using System.Collections.Generic;
using System.IO;
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
            Console.WriteLine("9 - enums");
            Console.WriteLine("10 - arrays/coleções");
            Console.WriteLine("11 - listas");
            Console.WriteLine("12 - ArrayList");
            Console.WriteLine("13 - Set");
            Console.WriteLine("14 - Dictionary");
            Console.WriteLine("15 - Herança poo");

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
            else if (opcao == 9)
            {
                opcaoMenu = new OpcoesMenu.Enums();
            }
            else if (opcao == 10)
            {
                opcaoMenu = new EstudosArrays();
            }
            else if (opcao == 11)
            {
                opcaoMenu = new Listas();
            }
            else if (opcao == 12)
            {
                opcaoMenu = new ArraysLists();
            }
            else if (opcao == 13)
            {
                opcaoMenu = new ListaTipoSet();
            }
            else if (opcao == 14)
            {
                opcaoMenu = new ListaTipoMapa();
            }
            else if (opcao == 15)
            {
                opcaoMenu = new EstudosHerancaPOO();
            }

            opcaoMenu.ExecutarOpcaoMenu();
        }

    }
}
