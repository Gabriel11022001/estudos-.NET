using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Classes.Exercicio7
{
    internal class Endereco
    {

        public String Logradouro { get; set; }
        public String Bairro { get; set; }
        public String Cep { get; set; }
        public String Complemento { get; set; }
        public String Cidade { get; set; }
        public String Numero { get; set; }

        public void ApresentarEndereco()
        {
            Console.WriteLine($"Logradouro: { this.Logradouro }");
            Console.WriteLine($"Cidade: { this.Cidade }");
            Console.WriteLine($"Bairro: { this.Bairro }");
            Console.WriteLine($"Cep: { this.Cep }");
            Console.WriteLine($"Complemento: { this.Complemento }");
            Console.WriteLine($"Número: { this.Numero }");
        }

    }
}
