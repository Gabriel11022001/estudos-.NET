using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico
{
    internal class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public double Salario { get; set; }
        public bool PossuiCnh { get; set; }
        public string NomePai { get; } = "Ailton";
        /**
         * quando vamos criar propriedades com o modificador de acesso
         * private, por convenção, utilizamos a sintaxe de deixar o nome começando
         * com camel-case e colocados o caracter _ na frente do nome a propriedade
         */
        private string _genero;

        // método construtor
        public Pessoa(string Nome, int Idade)
        {
            this.Nome = Nome;
            this.Idade = Idade;
        }

        // fazendo sobrecarga de construtores
        public Pessoa(string Nome, int Idade, double Salario, bool PossuiCnh)
        {
            this.Nome = Nome;
            this.Idade = Idade;
            this.PossuiCnh = PossuiCnh;
            this.Salario = Salario;
        }

        public Pessoa() 
        {
            // no escopo da classe eu posso alterar uma propriedade que não possui o set;
            this.NomePai = "Ailton Antônio dos Santos";
        }

        public void SetGenero(string Genero)
        {
            this._genero = Genero;
        }

        public string GetGenero()
        {

            return this._genero;
        }

    }
}
