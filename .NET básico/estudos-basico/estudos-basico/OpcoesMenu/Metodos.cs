using estudos_basico.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.OpcoesMenu
{
    internal class Metodos : OpcaoMenu
    {

        public override void ExecutarOpcaoMenu()
        {
            Console.WriteLine("===== métodos =====");

            var calculadoraComun = new CalculadoraComun();

            Console.WriteLine("informe o primeiro valor:");
            int primeiroValor = int.Parse(Console.ReadLine());

            Console.WriteLine("informe o segundo valor:");
            int segundoValor = int.Parse(Console.ReadLine());

            int soma = calculadoraComun.Somar(primeiroValor, segundoValor);
            int subtracao = calculadoraComun.Subtrair(primeiroValor, segundoValor);

            Console.WriteLine("A soma entre " + primeiroValor + " e " + segundoValor + " é igual a: " + soma);
            Console.WriteLine($"A subtração de { primeiroValor } por { segundoValor } é igual a: { subtracao }");

            var calculadoraCadeia = new CalculadoraCadeia();

            // consigo encadear várias chamadas
            calculadoraCadeia.Somar(10)
                .Somar(22)
                .Somar(1)
                .Somar(11)
                .Somar(2);

            calculadoraCadeia.ApresentarValor();

            double soma2 = CalculadoraEstatica.RealizarOperacao(11, 11, "somar");
            double subtracao2 = CalculadoraEstatica.RealizarOperacao(11, 2, "subtrair");

            Console.WriteLine($"soma: { soma2 }");
            Console.WriteLine($"subtração: { subtracao2 }");

            CalculadoraEstatica.ApresentarUltimaOperacao();

            ApresentarVariasPessoas("Gabriel", "Pedro", "Maria", "Eduardo", "José");

            // passando parâmetros de forma nomeada
            ApresentarDadosPessoas(primeiraPessoa: "Gabriel Rodrigues dos Santos", segundaPessoa: "Pedro", terceiraPessoa: "Maria");

            ApresentarDadosPessoas(
                primeiraPessoa: "Eduardo",
                terceiraPessoa: "Pedro",
                segundaPessoa: "Fernanda"
            );
        }

        public static void ApresentarVariasPessoas(params string[] nomes)
        {

            foreach (string nome in nomes)
            {
                Console.WriteLine(nome.ToUpper());
            }

        }

        public static void ApresentarDadosPessoas(string primeiraPessoa, string segundaPessoa, string terceiraPessoa)
        {
            Console.WriteLine($"{ primeiraPessoa } { terceiraPessoa } { segundaPessoa }");
        }

    }
}
