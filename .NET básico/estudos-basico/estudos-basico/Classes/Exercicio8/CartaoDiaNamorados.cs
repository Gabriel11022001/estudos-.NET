using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Classes.Exercicio8
{
    internal class CartaoDiaNamorados: CartaoWeb
    {

        public CartaoDiaNamorados(string destinatario): base(destinatario) { }

        public override void ApresentarMensagemCartao(string remetente)
        {

            if (!this.ValidarRemetente(remetente))
            {

                throw new Exception("Informe o remetente!");
            }


        }

    }
}
