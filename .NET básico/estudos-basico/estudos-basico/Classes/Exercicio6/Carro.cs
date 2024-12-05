using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Classes.Exercicio6
{
    internal class Carro
    {

        public String Modelo { get; set; }
        public String Marca { get; set; }

        public Carro() { }

        public Carro(String modelo, String marca)
        {
            this.Modelo = modelo;
            this.Marca = marca;
        }

        public void ApresentarCarro()
        {
            Console.WriteLine($"Modelo: { this.Modelo }");
            Console.WriteLine($"Marca: { this.Marca }");
        }

    }
}
