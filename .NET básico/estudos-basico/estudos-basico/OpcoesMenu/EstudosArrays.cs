using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.OpcoesMenu
{

    class Aluno
    {

        public string NomeAluno { get; set; }
        public string Telefone { get; set; }
        public int Idade { get; set; }

        public Aluno(string nomeAluno, int idadeAluno)
        {
            this.NomeAluno = nomeAluno;
            this.Idade = idadeAluno;
        }

    }

    internal class EstudosArrays : OpcaoMenu
    {

        public override void ExecutarOpcaoMenu()
        {
            Console.WriteLine("===== Arrays =====");

            string[] alunos = new string[5];

            alunos[0] = "Gabriel";
            alunos[1] = "Maria";
            alunos[2] = "Pedro";
            alunos[3] = "Eduardo";
            alunos[4] = "Jõão";

            foreach (string aluno in alunos)
            {
                Console.WriteLine(aluno);
            }

            // array de objetos
            Aluno[] alunosObjetos = new Aluno[2]
            {
                new Aluno("Gabriel", 23),
                new Aluno("Pedro", 22)
            };

            foreach (Aluno aluno in alunosObjetos)
            {
                Console.WriteLine(aluno.NomeAluno);
                Console.WriteLine(aluno.Idade);
            }

        }

    }
}
