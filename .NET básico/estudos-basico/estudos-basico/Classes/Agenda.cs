using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Classes
{
    internal class Agenda
    {

        private List<Contato> _contatos;

        public Agenda()
        {
            Console.WriteLine("Sua agenda de contatos...");
            this._contatos = new List<Contato>();
        }

        public void AdicionarContato(Contato contato)
        {

            if (this.ValidarContatoJaExisteAgenda(contato))
            {
                // o contato já existe na agenda
                Console.WriteLine("O contato de telefone " + contato.Telefone + " já existe na agenda!");

                return;
            }

            if (this._contatos.Count == 0)
            {
                contato.Id = 1;
            }
            else
            {
                Contato ultimoContatoAdicionado = this._contatos.Last();
                contato.Id = ultimoContatoAdicionado.Id + 1;
            }

            this._contatos.Add(contato);
            Console.WriteLine($"O contato de telefone { contato.Telefone } foi adicionado na agenda!");
        }

        public void ApresentarContatos()
        {

            if (this._contatos.Count == 0)
            {
                Console.WriteLine("não existem contato na agenda!");
            }
            else
            {

                foreach (Contato contato in this._contatos)
                {
                    Console.WriteLine("====================================");
                    contato.ApresentarContato();
                    Console.WriteLine("====================================");
                }

            }

        }

        private Boolean ValidarContatoJaExisteAgenda(Contato contatoValidar)
        {
            Boolean contatoJaExisteAgenda = false;

            foreach (Contato contatoAgenda in this._contatos)
            {

                if (contatoAgenda.Telefone == contatoValidar.Telefone || contatoValidar.NomeContato == contatoAgenda.NomeContato)
                {

                    contatoJaExisteAgenda = true;
                }

            }

            return contatoJaExisteAgenda;
        }

        private Contato BuscarPeloTelefone(string telefone)
        {
            Contato contato = null;

            foreach (var contatoConsulta in this._contatos)
            {

                if (contatoConsulta.Telefone.Equals(telefone))
                {
                    contato = contatoConsulta;
                }

            }

            return contato;
        }

        public void RemoverContato(String telefone)
        {
            var contatoRemover = this.BuscarPeloTelefone(telefone);

            if (contatoRemover != null)
            {
                this._contatos.Remove(contatoRemover);
                Console.WriteLine("Contato removido com sucesso!");
            } 
            else
            {
                Console.WriteLine("Não existe um contato com o telefone " + telefone + " cadastrado na agenda!");
            }

        }

        public void EditarContatoAgenda(String telefoneContatoAgenda, Contato contatoAlterar)
        {
            var contatoEditar = this.BuscarPeloTelefone(telefoneContatoAgenda);

            if (contatoEditar != null)
            {
                contatoEditar.NomeContato = contatoAlterar.NomeContato;
                contatoEditar.Telefone = contatoAlterar.Telefone;
                Console.WriteLine($"Contato de id { contatoEditar.Id } alterado com sucesso!");
                Console.WriteLine("Como ficou a agenda:");
                this.ApresentarContatos();
            }
            else
            {
                Console.WriteLine("Não existe um contato cadastrado com o telefone " + telefoneContatoAgenda);
            }

        }

    }
}
