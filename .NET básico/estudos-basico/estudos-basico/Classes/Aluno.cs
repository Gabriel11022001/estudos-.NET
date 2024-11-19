using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Classes
{
    internal class Aluno
    {

        public string Nome { get; set; }
        public string Matricula { get; set; }
        private List<double> _notas;

        public Aluno()
        {
            this._notas = new List<double>();
        }

        public Aluno(string nome, string matricula)
        {
            this._notas = new List<double>();
            this.Nome = nome;
            this.Matricula = matricula;
        }

        public void AdicionarNota(double nota)
        {

            if (nota < 0)
            {

                throw new Exception("Nota inválida!");
            }

            this._notas.Add(nota);
        }

        public double CalcularMediaAluno()
        {

            if (this._notas.Count == 0)
            {
                Console.WriteLine("O aluno não possui notas informadas!");

                return 0;
            }

            double somaNotas = 0;
            double media = 0;

            this._notas.ForEach(nota =>
            {
                somaNotas += nota;
            });

            media = somaNotas / this._notas.Count;

            return media;
        }

        public void ApresentarSituacaoAluno()
        {
            Console.WriteLine($"Nome: { this.Nome }");
            Console.WriteLine($"Número da matricula: { this.Matricula }");

            double media = this.CalcularMediaAluno();

            if (this._notas.Count > 0)
            {

                if (media >= 6)
                {
                    Console.WriteLine($"Aprovado com média { media }");
                }
                else if (media >= 4)
                {
                    Console.WriteLine($"Em recuperação com média: { media }");
                }
                else
                {
                    Console.WriteLine($"Reprovado com média: { media }");
                }
                
            }
            else
            {
                Console.WriteLine($"O aluno { this.Nome } não possui notas informadas!");
            }

        }

    }
}
