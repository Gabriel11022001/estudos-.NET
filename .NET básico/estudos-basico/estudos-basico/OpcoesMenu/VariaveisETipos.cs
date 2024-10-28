using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.OpcoesMenu
{
    internal class VariaveisETipos : OpcaoMenu
    {

        public override void ExecutarOpcaoMenu()
        {
            Console.WriteLine("---- variáveis e tipos de dados ----");

            // string
            string nome = "Gabriel Rodrigues dos Santos";
            string _nome = "Fernada da Silva";
            // não posso inicializar variáveis com números
            // string 2_nome = "nome com erro";
            Console.WriteLine(nome);
            Console.WriteLine(_nome);
           
            // idade e Idade são variáveis distintas, c# é case-sentitive
            int idade = 23; // tipo inteiro
            // em c#, sempre utilizar camel-case na hora de definir o nome da variável
            int Idade = 22;

            Console.WriteLine(idade);
            Console.WriteLine(Idade);

            // concatenar e interpolar
            string primeiroNome = "Gabriel", sobrenome = "Rodrigues";
            string nomeCompleto = primeiroNome + " " + sobrenome;

            Console.WriteLine(nomeCompleto);

            // interpolação
            Console.WriteLine($"nome completo: { nomeCompleto }");

            // tipo booleano
            bool possuiCnh = true;

            Console.WriteLine("Possui cnh? " + (possuiCnh ? "Sim" : "Não"));

            // decimal, double e float
            decimal salario = 3500;
            float ajustePercentual = 12.98f;
            double decimoTerceiro = 3600;

            Console.WriteLine(salario);
            Console.WriteLine(ajustePercentual);
            Console.WriteLine(decimoTerceiro);

            decimal primeiroValor = 121;
            double segundoValor = 11;
            // não posso realizar um aperação entre um decimal e um double por exemplo
            // double soma = primeiroValor + segundoValor;
            int primeiroValorInt = 11;
            double segundoValorDouble = 22.98;
            // posso realizar operações entre inteiros com os outros tipos de dados
            Console.WriteLine(primeiroValorInt + segundoValorDouble);

            double resultadoSomaDouble = primeiroValorInt + segundoValorDouble;
            Console.WriteLine(resultadoSomaDouble);
        }

    }
}
