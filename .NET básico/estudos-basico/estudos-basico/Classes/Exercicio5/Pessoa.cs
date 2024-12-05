using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Classes.Exercicio5
{
    internal class Pessoa
    {

        public string Nome { get; set; }
        public int Idade { get; set; }

        public Pessoa() { }

        public Pessoa(string nome, int idade)
        {
            this.Nome = nome;
            this.Idade = idade;
        }

    }
}
