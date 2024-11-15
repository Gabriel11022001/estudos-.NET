using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.OpcoesMenu
{
    internal class EstruturasCondicionais : OpcaoMenu
    {

        public override void ExecutarOpcaoMenu()
        {
            Console.WriteLine("----- estruturas condicionais ------");

            // operadores booleanos
            int valor = 11;

            Console.WriteLine(valor == 11); // igual a 
            Console.WriteLine(valor > 10); // maior que
            Console.WriteLine(valor < 10); // menor que
            Console.WriteLine(valor != 2); // diferente de
            Console.WriteLine(valor >= 11); // maior ou igual a
            Console.WriteLine(valor <= 8); // menor ou igual a

            string nomeCompleto = "Gabriel Rodrigues dos Santos";

            if (nomeCompleto.Trim() == "")
            {
                Console.WriteLine("Nome é uma string vazia!");
            }
            else
            {
                Console.WriteLine("nome não é uma string vazia!");
            }

            int mesNumero = 2;

            if (mesNumero == 1)
            {
                Console.WriteLine($"{ mesNumero } -> janeiro");
            }
            else if (mesNumero == 2)
            {
                Console.WriteLine($"{ mesNumero } -> fevereiro");
            }
            else
            {
                Console.WriteLine("qualquer outro mês");
            }

            int idade = 22;

            if (idade >= 18 && idade <= 55)
            {
                Console.WriteLine("pode trabalhar no bar!");
            }
            else
            {
                Console.WriteLine("não pode trabalhar no bar!");
            }

            mesNumero = 11;
            string mesNome = "";

            switch (mesNumero)
            {
                case 1:
                    mesNome = "janeiro";
                    break;
                case 2:
                    mesNome = "fevereiro";
                    break;
                case 3:
                    mesNome = "março";
                    break;
                case 4:
                    mesNome = "abril";
                    break;
                case 5:
                    mesNome = "maio";
                    break;
                default:
                    mesNome = "qualquer outro mês";
                    break;
            }

            mesNome = mesNome.ToUpper();
            Console.WriteLine("mês: " + mesNome);

            // também posso ter um if com uma única sentença de código e não preciso colocar chaves
            if (mesNome.Equals("qualquer outro mês".ToUpper()))
                Console.WriteLine("if com uma única sentença de código sem as chaves!");

            Console.WriteLine("Informe o dia que você nasceu:");
            int dia = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Informe o mês que você nasceu:");
            int mes = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o ano que você nasceu:");
            int ano = int.Parse(Console.ReadLine());

            if (dia < 1 || dia > 31)
            {
                Console.WriteLine("dia inválido!");

                return;
            }

            if (mes < 1 || mes > 12)
            {
                Console.WriteLine("mês inválido!");

                return;
            }

            if (ano <= 0)
            {
                Console.WriteLine("ano inválido!");

                return;
            }

            DateTime dataAtual = DateTime.Now;
            DateTime dataNascimento = new DateTime(ano, mes, dia);
            int idadeUsuario = dataAtual.Year - dataNascimento.Year;

            if (idadeUsuario >= 18)
            {
                Console.WriteLine("você é de maior!");
            }
            else
            {
                Console.WriteLine("você é de menor!");
            }

        }

    }
}
