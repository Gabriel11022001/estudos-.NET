using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Classes.Exercicio7
{
    internal class Cliente
    {

        public int Id { get; set; }
        public String NomeCompleto { get; set; }
        public String Email { get; set; }
        public String Genero { get; set; }
        private List<Contato> _contatos;
        public Endereco Endereco { get; set; }

        public Cliente() 
        {
            this._contatos = new List<Contato>();
            this.Endereco = new Endereco();
        }

        public Cliente(int id, String nomeCompleto, String email, String genero)
        {
            this._contatos = new List<Contato>();
            this.Endereco = new Endereco();
            this.NomeCompleto = nomeCompleto;
            this.Email = email;
            this.Genero = genero;
        }

        public void ApresentarDadosCliente()
        {
            Console.WriteLine($"Id: { this.Id }");
            Console.WriteLine($"Nome do cliente: { this.NomeCompleto }");
            Console.WriteLine($"E-mail do cliente: { this.Email }");
            Console.WriteLine($"Gênero: { this.Genero }");
            this.Endereco.ApresentarEndereco();
            
            foreach (var contato in this._contatos)
            {
                contato.ApresentarContato();
            }

        }

        public void AdicionarContatoCliente(Contato contato)
        {
            this._contatos.Add(contato);
        }

        public List<Contato> GetContatosCliente()
        {

            return this._contatos;
        }

    }
}
