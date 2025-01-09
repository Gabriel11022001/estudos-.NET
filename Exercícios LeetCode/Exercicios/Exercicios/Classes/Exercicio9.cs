using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicios.Classes
{
    internal class Exercicio9: IExercicio
    {

        public void ExecutarExercicio()
        {
            Console.WriteLine(IsPalindrome(213));
        }

        public bool IsPalindrome(int x)
        {
            String numeroString = x.ToString();

            if (numeroString.Length == 1)
            {

                return true;
            }

            if (numeroString.Length == 2 && numeroString[0].ToString().Equals(numeroString[1].ToString()))
            {

                return true;
            }

            String primeiroNumeroCaracter = numeroString[0].ToString();
            String ultimoNumeroCaracter = numeroString[numeroString.Length - 1].ToString();

            if (primeiroNumeroCaracter.Equals(ultimoNumeroCaracter))
            {

                return true;
            }

            return false;
        }

    }
}
