using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicios.Classes
{
    internal class Exercicio1: IExercicio
    {

        public void ExecutarExercicio()
        {
            int[] indicesTestar = this.TwoSum(new int[] { 2, 7, 8, 3 }, 15);

            foreach (int indice in indicesTestar)
            {
                Console.WriteLine($"indice: { indice }");
            }

        }

        public int[] TwoSum(int[] nums, int target)
        {
            int[] indicesRetornar = new int[2];

            for (int contador = 0; contador < nums.Length; contador++)
            {

                if (indicesRetornar[0] == 0 && indicesRetornar[1] == 0)
                {

                    for (int contadorInterno = contador + 1; contadorInterno < nums.Length; contadorInterno++)
                    {

                        if (nums[contador] + nums[contadorInterno] == target)
                        {
                            indicesRetornar[0] = contador;
                            indicesRetornar[1] = contadorInterno;
                        }

                    }

                }

            }

            return indicesRetornar;
        }

    }
}
