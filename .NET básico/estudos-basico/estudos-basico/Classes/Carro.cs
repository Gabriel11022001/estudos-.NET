using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Classes
{
    internal class Carro
    {
        // membro visível somente dentro do escopo da própria classe, não posso acessar direto por meio do objeto
        // em c#, o padrão é colocar o nome das pripriedades privadas com o _ na frente do nome da propriedade
        private int _velocidadeAtual = 0;
        private string _modelo;
        public string Modelo
        {
            get
            {

                return this._modelo.ToUpper();
            }
            set
            {

                if (value == "" || value is null)
                {

                    throw new Exception("modelo inválido!");
                }

                this._modelo = value;
            }
        }
        public string NomeDono { get; set; }

        public void SetVelocidade(int velocidadeAtual)
        {

            if (velocidadeAtual < 0)
            {
                Console.WriteLine("Velocidade atual inválida!");

                return;
            } 

            this._velocidadeAtual = velocidadeAtual;
        }

        public int GetVelocidadeAtual()
        {

            return this._velocidadeAtual;
        }

        public void ApresentarCarro()
        {
            Console.WriteLine($"modelo: { this.Modelo }");
            Console.WriteLine($"velocidade atual: { this.GetVelocidadeAtual() }km/H");
            Console.WriteLine($"dono: { this.NomeDono }");
        }

    }
}
