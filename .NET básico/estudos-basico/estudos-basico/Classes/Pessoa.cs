using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Classes
{
    public class Pessoa
    {
        /*
            todos os atributos abaixo são públicos, ou seja, podem ser acessados
            por meio da instância(objeto)
         */
        public string Nome { get; set; }
        public int Idade { get; set; }
        public bool PossuiCnh { get; set; }

        /*
         em c# eu posso possuir vários construtores com assinatura diferentes
         */
        public Pessoa()
        {
            Console.WriteLine("executando o construtor que não recebe parâmetros");
        }

        public Pessoa(string nome, int idade)
        {
            this.Nome = nome;
            this.Idade = idade;

            Console.WriteLine("executando o construtor que recebe o nome e a idade como argumento");
        }

        public Pessoa(int idade, string nome)
        {
            this.Nome = nome;
            this.Idade = idade;

            Console.WriteLine("executando o construtor que recebe o nome e idade como argumento mas em ordem diferente");
        }

        public Pessoa(string nome, int idade, bool possuiCnh)
        {
            this.Nome = nome;
            this.Idade = idade;
            this.PossuiCnh = possuiCnh;

            Console.WriteLine("executando o construtor que recebe o nome, idade e a info se possui cnh ou não");
        }

        public override string ToString()
        {

            return string.Format($"nome: { this.Nome } | idade: { this.Idade } | possui cnh: { this.PossuiCnh }");
        }

        public void Apresentar()
        {
            Console.WriteLine("nome: " + this.Nome);
            Console.WriteLine($"idade: { this.Idade }");
        }

    }
}
