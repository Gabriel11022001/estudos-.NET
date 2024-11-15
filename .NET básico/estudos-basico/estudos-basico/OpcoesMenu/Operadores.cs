using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.OpcoesMenu
{
    internal class Operadores : OpcaoMenu
    {

        public override void ExecutarOpcaoMenu()
        {
            Console.WriteLine("---- operadores ----");

            // soma
            int primeiroValor = 12;
            int segundoValor = 22;

            Console.WriteLine(primeiroValor + segundoValor);

            // subtração
            Console.WriteLine(primeiroValor - segundoValor);

            // multiplicação
            Console.WriteLine(primeiroValor * segundoValor);

            // divisão
            Console.WriteLine(primeiroValor / segundoValor);

            // resto da divisão
            Console.WriteLine(primeiroValor % segundoValor);

            // operador de atribuição
            int valor = 22;
            Console.WriteLine(valor);

            // incremento
            valor += 1;

            Console.WriteLine(valor); // 23

            valor++;

            Console.WriteLine(valor); // 24

            valor += 22;

            Console.WriteLine(valor); // 47

            // decremento
            valor -= 2; // vai decrementar 2
            valor--; // vai decrementar 1

            Console.WriteLine(valor);

            // tomar cuidado com a precedência de operadores
            double numero1 = 100;
            double numero2 = 10;

            // se eu não colocar a soma entre (), vai ser realiada primeiro a multiplicação
            double operacao = (numero1 + numero2) * 2;
            Console.WriteLine(operacao);
        }

    }
}
