using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Classes
{
    internal class Contato
    {

        public int Id { get; set; }
        public string NomeContato { get; set; }
        public string Telefone { get; set; }

        public Contato() { }
        public Contato(int id, string nomeContato, string telefone)
        {
            this.Id = id;
            this.NomeContato = nomeContato;
            this.Telefone = telefone;
        }

        public void ApresentarContato()
        {
            Console.WriteLine($"id: { this.Id }");
            Console.WriteLine($"nome do contato: { this.NomeContato }");
            Console.WriteLine($"telefone: { this.Telefone }");
        }

    }
}
