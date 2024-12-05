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
            int ultimoExercicioCadastrado = 10;

            while (exercicioSelecionado <= 0 || exercicioSelecionado > ultimoExercicioCadastrado)
            {
                Console.WriteLine("Selecione um exercício para executar");
                Console.WriteLine("1 - primeiro exercício");
                Console.WriteLine("2 - segundo exercício(agenda de contatos)");
                Console.WriteLine("3 - terceiro exercício(lista genérica)");
                Console.WriteLine("4 - quarto exercício(classe aluno)");
                Console.WriteLine("5 - quinto exercício");
                Console.WriteLine("6 - sexto exercício");
                Console.WriteLine("7 - sétimo exercício");
                Console.WriteLine("8 - oitavo exercício(cartão de comemoração)");

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
                        case 3:
                            exercicio = new Exercicio3();
                            break;
                        case 4:
                            exercicio = new Exercicio4();
                            break;
                        case 5:
                            exercicio = new Exercicio5();
                            break;
                        case 6:
                            exercicio = new Exercicio6();
                            break;
                        case 7:
                            exercicio = new Exercicio7();
                            break;
                        case 8:
                            exercicio = new Exercicio8();
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
