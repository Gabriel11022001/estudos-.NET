using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Classes
{
    internal class Vectra: Veiculo
    {

        public Vectra(): base() 
        {
            Console.WriteLine("Invocando o construtor que não recebe parâmetros da classe Vectra!");
        }

        public Vectra(double velocidadeMaxima): base(velocidadeMaxima)
        {
            Console.WriteLine("Invocando o construtor da classe Vectra!");
        }

        public override void Acelerar(double velocidadeAcelerar)
        {
            Console.WriteLine("Acelerando o " + this.Modelo);

            double velocidadeAtual = this.GetVelocidadeAtual();
            double novaVelocidade = velocidadeAtual + velocidadeAcelerar;

            if (novaVelocidade > this.VelocidadeMaxima)
            {

                throw new Exception("Não pode acelerar tudo isso!");
            }

            this.SetVelocidadeAtual(novaVelocidade);
        }

        public override void Frear()
        {
            Console.WriteLine("Freando o Vectra!");

            if (this.GetVelocidadeAtual() - 8 <= 0)
            {
                this.SetVelocidadeAtual(0);
            }
            else
            {
                this.SetVelocidadeAtual(this.GetVelocidadeAtual() - 8);
            }

        }

    }
}
