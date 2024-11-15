using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.OpcoesMenu
{
    internal class EstudoStrings : OpcaoMenu
    {

        public override void ExecutarOpcaoMenu()
        {
            Console.WriteLine("---- Estudo sobre strings em c# ----");
            string nomeCompleto = "Gabriel Rodrigues dos Santos";
            String nomeCliente = "Marcio Eduardo da Silva";

            Console.WriteLine("nome completo: " + nomeCliente);
            Console.WriteLine("nome do cliente: " + nomeCliente);

            // concatenar
            string primeiroNome = "Gabriel";
            string sobrenome = "Rodrigues";

            Console.WriteLine(primeiroNome + " " + sobrenome);
            // interpolação
            Console.WriteLine($"{ primeiroNome } { sobrenome }");

            // obter string toda em maiusculo
            string mensagem = "mensagem qualquer";
            Console.WriteLine(mensagem.ToUpper());

            // obter string toda minusculo
            Console.WriteLine(mensagem.ToLower());

            // obter o tamanho da string(quantidade de caracteres)
            Console.WriteLine($"quantidade de caracteres do texto { mensagem } : { mensagem.Length }");

            // quebrar string em um array de strings
            string nomes = "Gabriel, Maria, Pedro, Vivian";
            string[] arrayNomes = nomes.Split(',');

            foreach (string nome in arrayNomes)
            {
                // remover espaços em branco do inicio e fim da string
                string nomeSemEspaco = nome.Trim();
                Console.WriteLine("nome: " + nomeSemEspaco);
            }

        }

    }
}
