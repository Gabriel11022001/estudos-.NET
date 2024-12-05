using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Classes.Exercicio8
{
    internal abstract class CartaoWeb
    {

        private string _destinatario;
        public string Destinatario { 
            get
            {

                return this._destinatario;
            }
            set
            {

                if (value.Trim() == "")
                {

                    throw new Exception("Informe o destinatário do cartão!");
                }

                this._destinatario = value;
            }
        }

        public CartaoWeb(string destinatario)
        {
            this.Destinatario = destinatario;
        }

        public abstract void ApresentarMensagemCartao(string remetente);

        protected bool ValidarRemetente(string remetente)
        {

            if (remetente.Trim() == "")
            {

                return false;
            }

            return true;
        }

    }
}
