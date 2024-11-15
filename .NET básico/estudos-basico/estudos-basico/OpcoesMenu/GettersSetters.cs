using estudos_basico.Classes;
using System;

namespace estudos_basico.OpcoesMenu
{
    internal class GettersSetters : OpcaoMenu
    {

        public override void ExecutarOpcaoMenu()
        {

            try
            {
                var carro1 = new Carro();
                carro1.SetVelocidade(100);
                carro1.SetVelocidade(200);

                Console.WriteLine(carro1.GetVelocidadeAtual());

                var carro2 = new Carro();

                carro2.Modelo = "gol bolinha";

                Console.WriteLine(carro2.Modelo);

                // carro2.Modelo = "";

                Carro carro3 = new Carro();

                carro3.NomeDono = "Gabriel Rodrigues dos Santos";
                carro3.SetVelocidade(200);
                carro3.Modelo = "Gol quadrado";

                // apresentar dados do carro
                carro3.ApresentarCarro();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }

        }

    }
}
