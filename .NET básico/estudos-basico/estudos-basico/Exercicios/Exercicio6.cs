using estudos_basico.Classes.Exercicio6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Exercicios
{
    internal class Exercicio6 : Exercicio
    {
        /**
         * Crie uma classe `Carro` com atributos `marca` e `modelo`. Instancie um objeto e modifique os atributos.
         */
        public override void Executar()
        {
            Console.WriteLine("==== Exercício 6 =====");
            var carro1 = new Carro();
            var carro2 = new Carro();

            carro1.Modelo = "Carro 1";
            carro1.Marca = "fiat";

            carro2.Modelo = "Carro 2";
            carro2.Marca = "fiat";

            carro1.ApresentarCarro();
            carro2.ApresentarCarro();
        }

    }
}
