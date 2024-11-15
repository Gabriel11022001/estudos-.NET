using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Exercicios
{
    internal class Exercicio1 : Exercicio
    {

        public override void Executar()
        {
            Console.WriteLine("1) Faça um algoritmo que leia os valores A, B, C e imprima na tela se a soma de A + B é menor que C.");
            this.LerValoresImprimir();
        }

        private void LerValoresImprimir()
        {

            try
            {
                Console.WriteLine("informe um valor:");
                int primeiroValor = Int32.Parse(Console.ReadLine());

                Console.WriteLine("informe um segundo valor:");
                int segundoValor = Int32.Parse(Console.ReadLine());

                Console.WriteLine("informe um terceiro valor:");
                int terceiroValor = Int32.Parse(Console.ReadLine());

                if ((primeiroValor + segundoValor) < terceiroValor)
                {
                    Console.WriteLine($"{ primeiroValor } + { segundoValor } é menor que { terceiroValor }");
                }
                else
                {
                    Console.WriteLine($"{ primeiroValor } + { segundoValor } não é menor que { terceiroValor }");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message.ToString());
            }

        }

    }
}
