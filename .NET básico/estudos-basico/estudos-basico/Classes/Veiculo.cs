using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Classes
{
    internal abstract class Veiculo
    {

        public string Marca { get; set; }
        public string Modelo { get; set; }
        protected double VelocidadeMaxima { get; set; }
        private double _velocidadeAtual;

        public Veiculo()
        {
            this._velocidadeAtual = 0;
            this.VelocidadeMaxima = 100;
        }

        public Veiculo(double velocidadeMaxima)
        {
            this.VelocidadeMaxima = velocidadeMaxima;
            this._velocidadeAtual = 0;
        }

        protected void SetVelocidadeAtual(double novaVelocidade)
        {

            if (novaVelocidade < 0)
            {

                throw new Exception("Velocidade inválida!");
            }

            if (novaVelocidade > this.VelocidadeMaxima)
            {

                throw new Exception("Velocidade inválida!");
            }

            this._velocidadeAtual = novaVelocidade;
        }

        public double GetVelocidadeAtual()
        {

            return this._velocidadeAtual;
        }

        public abstract void Acelerar(double velocidadeAcelerar);

        /**
         * se eu quiser que um método possa ser sobreescrito, eu devo
         * marcar ele como virtual
         */
        public virtual void Frear()
        {
            // frear de 5 em 5 km por hora

            if (this._velocidadeAtual <= 0)
            {
                this._velocidadeAtual = 0;
            } else
            {
                this._velocidadeAtual -= 5;
            }

        }

        public void ApresentarDetalhesVeiculo()
        {
            Console.WriteLine($"Marca: { this.Marca }");
            Console.WriteLine($"Modelo: { this.Modelo }");
            Console.WriteLine($"Velocidáde máxima: { this.VelocidadeMaxima }km/h");
            Console.WriteLine($"Velocidade atual: { this._velocidadeAtual }km/h");
        }

    }
}
