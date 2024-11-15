using estudos_basico.Exercicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.OpcoesMenu
{
    internal class Exercicios : OpcaoMenu
    {

        public override void ExecutarOpcaoMenu()
        {
            int exercicioSelecionado = 0;
            int ultimoExercicioCadastrado = 5;

            while (exercicioSelecionado <= 0 || exercicioSelecionado > ultimoExercicioCadastrado)
            {
                Console.WriteLine("Selecione um exercício para executar");
                Console.WriteLine("1 - primeiro exercício");
                Console.WriteLine("2 - segundo exercício(agenda de contatos)");
                Console.WriteLine("3 - terceiro exercício");
                Console.WriteLine("4 - quarto exercício");
                Console.WriteLine("5 - quinto exercício");

                exercicioSelecionado = Int32.Parse(Console.ReadLine());

                if (exercicioSelecionado <= 0 || exercicioSelecionado > ultimoExercicioCadastrado)
                {
                    Console.WriteLine("Exercício inválido");
                }
                else
                {
                    // selecionou um exercício válido
                    Exercicio exercicio = null;

                    switch (exercicioSelecionado)
                    {
                        case 1:
                            exercicio = new Exercicio1();
                            break;
                        case 2:
                            exercicio = new Exercicio2();
                            break;
                        default:
                            Console.WriteLine("Exercício inválido!");
                            break;
                    }

                    exercicio.Executar();
                }

            }

        }

    }
}
