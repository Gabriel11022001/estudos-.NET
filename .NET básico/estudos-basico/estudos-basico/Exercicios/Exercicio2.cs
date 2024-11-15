using estudos_basico.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Exercicios
{
    internal class Exercicio2 : Exercicio
    {
        // exercício agenda
        public override void Executar()
        {

            try
            {
                int opcao = -1;
                Agenda agenda = new Agenda();

                while (opcao != 0)
                {
                    Console.WriteLine("Informe uma opção:");
                    this.ApresentarMenu();
                    opcao = int.Parse(Console.ReadLine());

                    if (opcao == 1)
                    {
                        // adicionar contato na agenda
                        this.AdicionarContatoAgenda(agenda);
                    }
                    else if (opcao == 2)
                    {
                        // apresentar contatos da agenda
                        agenda.ApresentarContatos();
                    }
                    else if (opcao == 3)
                    {
                        this.RemoverContato(agenda);
                    }
                    else if (opcao == 4)
                    {
                        this.EditarContato(agenda);
                    }
                    else if (opcao == 0)
                    {
                        Console.WriteLine("Finalizando o programa...");
                        Console.WriteLine("Programa finalizado com sucesso...");
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida".ToUpper());
                    }

                    if (opcao >= 1 && opcao <= 4)
                    {
                        int desejaContinuar = 0;

                        while (desejaContinuar < 1 || desejaContinuar > 2)
                        {
                            Console.WriteLine("Deseja continuar? Digite 1 para sim ou 2 para não!");
                            desejaContinuar = int.Parse(Console.ReadLine());

                            if (desejaContinuar == 1)
                            {
                                opcao = -1;
                            }
                            else if (desejaContinuar == 2)
                            {
                                opcao = 0;
                                Console.WriteLine("Então o programa será finalizado...");
                                Console.WriteLine("Programa finalizado com sucesso...");
                            }
                            else
                            {
                                Console.WriteLine("Opção inválida!");
                            }

                        }

                    }

                }

            }
            catch (Exception e)
            {
                Console.Write("Erro: " + e.Message.ToString());
            }

        }

        private void ApresentarMenu()
        {
            Console.WriteLine("1 - adicionar contato na agenda");
            Console.WriteLine("2 - listar contatos da agenda");
            Console.WriteLine("3 - remover contato");
            Console.WriteLine("4 - editar contato");
            Console.WriteLine("0 - finalizar");
        }

        // método responsável por adicionar os contatos na agenda
        private void AdicionarContatoAgenda(Agenda agenda)
        {
            Contato contato = new Contato();

            Console.WriteLine("informe o nome do contato:");
            contato.NomeContato = Console.ReadLine();

            Console.WriteLine("informe o telefone do contato:");
            contato.Telefone = Console.ReadLine();

            agenda.AdicionarContato(contato);
        }

        private void RemoverContato(Agenda agenda)
        {
            Console.WriteLine("informe o telefone do contato que você deseja remover:");
            string telefone = Console.ReadLine();

            agenda.RemoverContato(telefone);
            Console.WriteLine("Como ficou a agenda:");
            agenda.ApresentarContatos();
        }

        private void EditarContato(Agenda agenda)
        {
            Console.WriteLine("informe o telefone atual do contato:");
            string telefoneAtual = Console.ReadLine();

            Contato contatoEdicao = new Contato();

            Console.WriteLine("informe o novo nome do contato na agenda:");
            contatoEdicao.NomeContato = Console.ReadLine();

            Console.WriteLine("informe o novo telefone do contato:");
            contatoEdicao.Telefone = Console.ReadLine();

            // persistir a alteração dos dados do contato na agenda
            agenda.EditarContatoAgenda(telefoneAtual, contatoEdicao);
        }

    }
}
