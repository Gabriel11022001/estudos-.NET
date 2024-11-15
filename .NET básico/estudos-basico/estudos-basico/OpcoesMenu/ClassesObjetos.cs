using estudos_basico.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.OpcoesMenu
{
    internal class ClassesObjetos : OpcaoMenu
    {

        public override void ExecutarOpcaoMenu()
        {
            Console.WriteLine("------ Classes e objetos ------");
            estudos_basico.Classes.Pessoa pessoa = new Classes.Pessoa();

            pessoa.Nome = "Gabriel Rodrigue dos Santos";
            pessoa.Idade = 23;
            pessoa.PossuiCnh = true;

            Console.WriteLine(pessoa.ToString());

            pessoa.Apresentar();

            estudos_basico.Classes.Pessoa pessoa2 = new Classes.Pessoa();
            estudos_basico.Classes.Pessoa pessoa3 = new Classes.Pessoa("Gabriel", 23);
            estudos_basico.Classes.Pessoa pessoa4 = new Classes.Pessoa(23, "Maria");
            estudos_basico.Classes.Pessoa pessoa5 = new Classes.Pessoa("Eduardo", 26, true);

            // outra forma de definir o construtor já inicializando as propriedades
            var carro7 = new Classes.Pessoa()
            {
                Nome = "Gabriel",
                Idade = 23
            };

            carro7.Apresentar();
        }

    }
}
