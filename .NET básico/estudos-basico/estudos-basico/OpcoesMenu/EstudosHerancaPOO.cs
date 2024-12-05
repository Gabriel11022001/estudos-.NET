using estudos_basico.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.OpcoesMenu
{
    internal class EstudosHerancaPOO: OpcaoMenu
    {

        public override void ExecutarOpcaoMenu()
        {
            Console.WriteLine("===== Estudos sobre o pilar da herança =======");

            Veiculo primeiroVeiculo = new Vectra();
            Vectra segundoVeicolo = new Vectra(100);

            primeiroVeiculo.Marca = "Marca do primeiro veiculo";
            segundoVeicolo.Marca = "Marca do segundo veiculo";
            primeiroVeiculo.Modelo = "Primeiro veiculo";
            segundoVeicolo.Modelo = "Segundo veiculo";

            primeiroVeiculo.Acelerar(10);
            primeiroVeiculo.Acelerar(5);
            primeiroVeiculo.Acelerar(2);

            segundoVeicolo.Acelerar(10);
            segundoVeicolo.Acelerar(1);
            segundoVeicolo.Acelerar(2);

            Console.WriteLine(primeiroVeiculo.GetVelocidadeAtual());
            Console.WriteLine(segundoVeicolo.GetVelocidadeAtual());

            primeiroVeiculo.ApresentarDetalhesVeiculo();
            segundoVeicolo.ApresentarDetalhesVeiculo();
        }

    }
}
