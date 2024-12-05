using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Exercicios
{
    internal class Exercicio5 : Exercicio
    {
        /**
         * Crie uma classe chamada `Pessoa` com os atributos `nome` e `idade`. Instancie um objeto dessa classe e imprima os atributos.
         */
        public override void Executar()
        {
            estudos_basico.Classes.Exercicio5.Pessoa primeiraPessoa = new Classes.Exercicio5.Pessoa();
            estudos_basico.Classes.Exercicio5.Pessoa segundaPessoa = new Classes.Exercicio5.Pessoa();

            primeiraPessoa.Nome = "Gabriel";
            primeiraPessoa.Idade = 24;

            segundaPessoa.Nome = "Pedro";
            segundaPessoa.Idade = 22;

            Console.WriteLine($"nome da primeira pessoa: { primeiraPessoa.Nome }");
            Console.WriteLine($"nome da segunda pessoa: { segundaPessoa.Nome }");

            Console.WriteLine($"idade da primeira pessoa: { primeiraPessoa.Idade }");
            Console.WriteLine($"idade da segunda pessoa: { segundaPessoa.Idade }");

            Console.WriteLine($"nome da primeira pessoa tudo em maiusculo: { primeiraPessoa.Nome.ToUpper() }");
            Console.WriteLine($"nome da segunda pessoa tudo em maiusculo: { segundaPessoa.Nome.ToUpper() }");
            Console.WriteLine($"nome da primeira pessoa tudo em minusculo: { primeiraPessoa.Nome.ToLower() }");
            Console.WriteLine($"nome da segunda pessoa tudo em minusculo: { segundaPessoa.Nome.ToLower() }");

            estudos_basico.Classes.Exercicio5.Pessoa terceiraPessoa = new Classes.Exercicio5.Pessoa("Maria", 23);
            estudos_basico.Classes.Exercicio5.Pessoa quartaPessoa = new Classes.Exercicio5.Pessoa()
            {
                Nome = "João",
                Idade = 34
            };

            Console.WriteLine($"nome da terceira pessoa: { terceiraPessoa.Nome } e idade da terceira pessoa: { terceiraPessoa.Idade }");
            Console.WriteLine($"nome da quarta pessoa: { quartaPessoa.Nome } e idade da quarta pessoa: { quartaPessoa.Idade }");
        }

    }
}
