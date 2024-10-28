using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // apresentar informação no console
            // Console -> classe
            // WriteLine -> método estático público
            // no c#, por padrão, o pessoal escreve os nomes dos métodos começando com letra maíuscula -> pascal case
            /*Console.WriteLine("Olá Mundo!");

            // tipos primitivos
            int idade = 23; // inteiro
            double peso = 87.98; // double -> número real
            String primeiroNome = "Gabriel";
            string sobrenome = "Rodrigues";
            string nomeCompleto = primeiroNome + " " + sobrenome; // concatenação

            Console.WriteLine("idade: " + idade);
            Console.WriteLine("peso: " + peso + "kg");
            Console.WriteLine("nome completo: " + nomeCompleto);

            string mensagem = $"meu nome é { nomeCompleto } e eu tenho { idade } anos de idade";

            Console.WriteLine(mensagem);

            // boolean
            bool possuiCnh = true;

            if (possuiCnh)
            {
                Console.WriteLine("possui cnh");
            }
            else
            {
                Console.WriteLine("não possui cnh");
            }

            int primeiroValor = 12, segundoValor = 11;

            // somar
            int soma = primeiroValor + segundoValor;

            // subtração
            int subtracao = primeiroValor - segundoValor;

            // multiplicação
            int multiplicacao = primeiroValor * segundoValor;

            // divisão
            int divisao = primeiroValor / segundoValor;

            // resto da divisão
            int restoDivisao = primeiroValor % segundoValor;

            Console.WriteLine(soma);
            Console.WriteLine(subtracao);
            Console.WriteLine(multiplicacao);
            Console.WriteLine(divisao);
            Console.WriteLine(restoDivisao);

            bool numeroEhPar = primeiroValor % 2 == 0;

            if (numeroEhPar)
            {
                Console.WriteLine("O número " + primeiroValor + " é par");
            }
            else
            {
                Console.WriteLine("o número " + primeiroValor + " é impar");
            }

            int mesAtualNumero = 11;

            if (mesAtualNumero == 1)
            {
                Console.WriteLine("janeiro");
            } 
            else if (mesAtualNumero == 2)
            {
                Console.WriteLine("fevereiro");
            }
            else if (mesAtualNumero == 3)
            {
                Console.WriteLine("março");
            }
            else
            {
                Console.WriteLine("nenhum dos meses bate com o número informado para o mês");
            }

            switch(mesAtualNumero)
            {
                case 1:
                    Console.WriteLine("janeiro");
                    break;
                case 2:
                    Console.WriteLine("fevereiro");
                    break;
                default:
                    Console.WriteLine("mês inválido!");
                    break;
            }

            int contador = 1;

            while (contador <= 100)
            {
                Console.WriteLine(contador);
                contador++; // contador = contador + 1
            }

            contador = 1;

            do
            {
                Console.WriteLine("contador com do-while: " + contador);
                contador = contador + 1;
            }
            while (contador <= 100);

            for (int i = 0; i <= 100; i++)
            {
                Console.WriteLine($"contador com for: { i }");
            }

            // também posso utilizar var ao invés de definir o tipo explicitamente
            // nesse caso, o tipo da variável vai depender do valor atribuído a ela
            var contador2 = 100;

            while (contador2 > 0)
            {
                Console.WriteLine(contador2);

                contador2--; // contador2 = contador2 - 1
            }

            LerDadosConsole();

            var nomeContarLetras = "";

            try
            {
                int quantidadeCaracteresNome = ContarLetrasNome(nomeContarLetras);

                Console.WriteLine($"o nome { nomeContarLetras } possui { quantidadeCaracteresNome } caracteres");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            TesteClasses();*/
            
            try
            {
                ExecutarPrograma();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        // por padrão, os métodos em c# começam com letra maiuscula
        private static void LerDadosConsole()
        {
            string nomeCompleto = "";
            Console.WriteLine("informe seu nome completo:");

            nomeCompleto = Console.ReadLine();

            Console.WriteLine("seu nome completo é: " + nomeCompleto);

            Console.WriteLine("informe sua idade:");

            // fazendo um cast de uma string para um inteiro
            int idade = Int32.Parse(Console.ReadLine());

            Console.WriteLine("idade: " + idade);
        }

        /**
         * em c#, você precisa definir o tipo de retorno dos métodos
         * em c#, você precisa definir o tipo dos parâmetros
         */
        private static int ContarLetrasNome(string nome)
        {

            if (nome is null || nome.Trim().Equals(""))
            {
                // lançando uma exception
                throw new Exception("informe o nome!");
            }

            return nome.Length;
        }

        private static void TesteClasses()
        {
            Pessoa pessoa1 = new Pessoa();
            pessoa1.Nome = "Gabriel";
            pessoa1.Idade = 23;
            pessoa1.Salario = 3500;
            pessoa1.PossuiCnh = true;

            Console.WriteLine(pessoa1.Nome);
            Console.WriteLine(pessoa1.Salario);
            Console.WriteLine(pessoa1.Idade);
            Console.WriteLine(pessoa1.PossuiCnh);

            pessoa1.Nome = "Gabriel Rodrigues dos Santos";
            Console.WriteLine("nome alterado: " + pessoa1.Nome);

            Console.WriteLine(pessoa1.NomePai);

            /**
             * na classe Pessoa, eu defini somente o get; então
             * quando eu instancio um objeto do tipo Pessoa, eu não
             * posso atribuir o valor para a propriedade, só obter mesmo o valor
             */
            // pessoa1.NomePai = "";

            pessoa1.SetGenero("Masculino");

            // método ToUpper() -> retorna string toda maiuscula
            Console.WriteLine(pessoa1.GetGenero().ToUpper());
        }

        private static void ExecutarPrograma()
        {
            Programa.Executar();
        }

    }
}
