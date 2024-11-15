using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Classes
{
    internal class CalculadoraCadeia
    {

        private int _valor = 0;

        public CalculadoraCadeia Somar(int valorSomar)
        {
            this._valor += valorSomar;

            return this;
        }

        public void ApresentarValor()
        {
            Console.WriteLine($"valor até agora: { this._valor }");
        }

    }
}
