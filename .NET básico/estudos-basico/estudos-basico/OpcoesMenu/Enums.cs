using estudos_basico.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.OpcoesMenu
{
    internal class Enums : OpcaoMenu
    {

        public override void ExecutarOpcaoMenu()
        {
            Console.WriteLine("====== Enums ======");

            Console.WriteLine(MesesEnum.Janeiro);
            Console.WriteLine(MesesEnum.Fevereiro);
            Console.WriteLine(MesesEnum.Marco);
            Console.WriteLine(MesesEnum.Abril);
        }

    }
}
