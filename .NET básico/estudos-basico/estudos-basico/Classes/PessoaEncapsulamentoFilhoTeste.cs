using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Classes
{
    internal class PessoaEncapsulamentoFilhoTeste: PessoaTesteEncapsulamento
    {

        public void TestarAcessosClasseFilho()
        {
            Console.WriteLine("Nome: " + this.Nome);
            Console.WriteLine("Sobrenome: " + this.Sobrenome);
            Console.WriteLine("Telefone: " + this.Telefone);
            /*
             não posso acessar a propriedade _salario pois é uma propriedade privada
             */
            // Console.WriteLine("Salário: " + this._salario);
        }

        public void DefinirSalarioClassefilho(double salarioDefinirClasseFilho)
        {
            /**
             * consigo invocar o método DefinirSalario(novoSalario) da super classe
             * pois é um método protected, ou seja, eu posso acessar esse método na classe filha
             */
            this.DefinirSalario(salarioDefinirClasseFilho);
        }

    }
}
