using estudos_basico.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Exercicios
{
    internal class Exercicio4 : Exercicio
    {

        private List<Aluno> _alunos = new List<Aluno>();

        public override void Executar()
        {
            Console.WriteLine("===== Exercício classe Aluno =====");
            this.ExecutarExercicio();
        }

        private void ExecutarExercicio()
        {

            try
            {
                int opcaoSelecionada = 0;

                while (opcaoSelecionada != 5)
                {
                    Console.WriteLine("Selecione uma opção:");
                    this.Menu();

                    opcaoSelecionada = int.Parse(Console.ReadLine());

                    switch (opcaoSelecionada)
                    {
                        case 1:
                            this.RegistrarAluno();
                            break;
                        case 2:
                            this.ApresentarAlunosRegistrados();
                            break;
                        case 3:
                            this.ApresentarDadosAlunoExpecifico();
                            break;
                        case 4:
                            this.RegistrarNotaAluno();
                            break;
                        case 5:
                            Console.WriteLine("Finalizando....");
                            break;
                        default:
                            Console.WriteLine("Opção inválida!");
                            break;
                    }

                    if (opcaoSelecionada != 5)
                    {
                        int opcaoContinuar = 0;

                        while (opcaoContinuar != 1 && opcaoContinuar != 2)
                        {
                            Console.WriteLine("deseja continuar? digite 1 para sim ou 2 para não!");
                            opcaoContinuar = int.Parse(Console.ReadLine());

                            if (opcaoContinuar != 1 && opcaoContinuar != 2)
                            {
                                Console.WriteLine("opção inválida, digite 1 para sim ou 2 para não!");
                            }

                            if (opcaoContinuar == 1)
                            {
                                opcaoSelecionada = 0;
                            }
                            else
                            {
                                opcaoSelecionada = 5;
                            }

                        }

                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: { e.Message }");
            }

        }

        private void RegistrarAluno()
        {
            var aluno = new Aluno();

            Console.WriteLine("informe o nome do aluno:");
            aluno.Nome = Console.ReadLine();

            Console.WriteLine("informe o número de matricula do aluno:");
            aluno.Matricula = Console.ReadLine();

            this._alunos.Add(aluno);
            Console.WriteLine("Aluno registrado com sucesso!");
        }

        private void ApresentarAlunosRegistrados()
        {

            if (this._alunos.Count == 0)
            {
                Console.WriteLine("Não existem alunos cadastrados!");

                return;
            }

            this._alunos.ForEach(aluno => aluno.ApresentarSituacaoAluno());

        }

        private Aluno BuscarAlunoPeloNome(string nome)
        {
            Aluno aluno = null;

            foreach (Aluno alunoConsultar in this._alunos)
            {

                if (alunoConsultar.Nome.Equals(nome))
                {
                    aluno = alunoConsultar;
                }

            }

            return aluno;
        }

        private void ApresentarDadosAlunoExpecifico()
        {
            Console.WriteLine("informe o nome do aluno que você deseja apresentar os dados:");
            string nomeAluno = Console.ReadLine();

            Aluno alunoApresentarDados = this.BuscarAlunoPeloNome(nomeAluno);

            if (alunoApresentarDados != null)
            {
                alunoApresentarDados.ApresentarSituacaoAluno();
            }
            else
            {
                Console.WriteLine("Não foi encontrado um aluno com o nome informado!");
            }

        }

        private void RegistrarNotaAluno()
        {
            Console.WriteLine("informe o nome do aluno que você deseja adicionar a nota:");
            string nomeAluno = Console.ReadLine();

            Aluno alunoAdicionarNota = this.BuscarAlunoPeloNome(nomeAluno);

            if (alunoAdicionarNota != null)
            {
                Console.WriteLine("Informe a nota:");
                double nota = double.Parse(Console.ReadLine());

                if (nota < 0 || nota > 10)
                {
                    Console.WriteLine("nota inválida!");

                    return;
                }

                alunoAdicionarNota.AdicionarNota(nota);

                Console.WriteLine("Nota adicionada com sucesso!");
            }
            else
            {
                Console.WriteLine("Não existe um aluno cadastrado com esse nome!");
            }

        }

        private void Menu()
        {
            Console.WriteLine("1 - registrar aluno");
            Console.WriteLine("2 - apresentar dados dos alunos registrados");
            Console.WriteLine("3 - apresentar dados de um aluno em expecifico");
            Console.WriteLine("4 - registrar uma nota para um aluno");
            Console.WriteLine("5 - finalizar");
        }

    }
}
