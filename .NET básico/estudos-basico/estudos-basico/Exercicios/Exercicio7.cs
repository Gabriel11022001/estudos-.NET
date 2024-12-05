using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Exercicios
{
    internal class Exercicio7 : Exercicio
    {

        public override void Executar()
        {
            Console.WriteLine("===== Exercício 7 ======");
            int soma = this.SomarMultiplosTresImpares();
            Console.WriteLine($"Soma: { soma }");
        }

        private int SomarMultiplosTresImpares()
        {
            int soma = 0;

            for (int contador = 0; contador < 500; contador++)
            {

                if (this.ValidarEhMultiploTres(contador) && this.ValidarEhImpar(contador))
                {
                    soma += contador;
                }

            }

            return soma;
        }

        private bool ValidarEhMultiploTres(int numero)
        {

            return numero % 3 == 0;
        }

        private bool ValidarEhImpar(int numero)
        {

            if (numero % 2 == 0)
            {

                return false;
            }

            return true;
        }

    }
}
