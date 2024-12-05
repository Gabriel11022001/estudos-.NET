using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Classes
{
    internal class PessoaTesteEncapsulamento
    {

        // public -> pode ser acessado no escopo da própria classe e por uma instancia
        public string Nome { get; set; }
        public string Sobrenome { get; }
        // protected -> pode ser acessado no escopo da classe e pelas classes que herdarem dessa classe
        protected string Telefone { get; set; }
        // private -> só pode ser acessado no escopo da propria classe que possui o membro
        private double _salario = 0;

        /**
         * esse método possui o modificador de acesso public, ou seja, vou poder
         * acessar ele no escopo da propria classe, nas classes que herdarem dessa classe
         * e por meio do objeto
         */
        public void ApresentarPessoa()
        {
            Console.WriteLine("Nome: " + this.Nome.ToUpper());
            Console.WriteLine("Sobrenome: " + this.Sobrenome.ToUpper());
            Console.WriteLine("Telefone: " + this.Telefone);
            Console.WriteLine("Salário: R$" + this._salario);
        }

        /**
         * esse método é protegido, eu seja, só posso acessar ele no escopo
         * da propria classe e por meio de uma classe que herdar dessa classe
         */
        protected void DefinirSalario(double salarioDefinir)
        {

            if (!this.ValidarSalario(salarioDefinir))
            {

                throw new Exception("Erro ao tentar-se definir o salário!");
            }

            this._salario = salarioDefinir;
        }

        // método privado -> só posso acessar ele no escopo da propria classe onde ele foi implementado
        private bool ValidarSalario(double salarioValidar)
        {

            if (salarioValidar <= 0)
            {

                return false;
            }

            return true;
        }

    }
}
