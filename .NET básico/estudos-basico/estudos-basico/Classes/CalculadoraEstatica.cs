using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Classes
{
    internal class CalculadoraEstatica
    {

        public static string UltimaOperacao { get; set; }

        /**
         * o método RealizarOperacao é um método estático, ou seja, só pode ser
         * acessado por meio do invocação Classe.Metodo();
         */
        public static double RealizarOperacao(double primeiroValor, double segundoValor, string operacao)
        {

            if (operacao == "somar")
            {
                CalculadoraEstatica.UltimaOperacao = "soma";

                return primeiroValor + segundoValor;
            }

            if (operacao == "subtrair")
            {
                CalculadoraEstatica.UltimaOperacao = "subtração";

                return primeiroValor - segundoValor;
            }

            CalculadoraEstatica.UltimaOperacao = "nenhuma";

            return 0.0;
        }

        public static void ApresentarUltimaOperacao()
        {
            Console.WriteLine($"ultima aperação: { CalculadoraEstatica.UltimaOperacao }");
        }

    }
}
