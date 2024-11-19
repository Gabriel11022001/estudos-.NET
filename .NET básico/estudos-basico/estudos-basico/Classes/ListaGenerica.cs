using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Classes
{
    internal class ListaGenerica<T>
    {

        private List<T> _elementos;

        public ListaGenerica()
        {
            this._elementos = new List<T>();
        }

        public void Adicionar(T elemento)
        {
            this._elementos.Add(elemento);
        }

        public void Adicionar(params T[] elementosAdicionar)
        {

            foreach (T elementoAdicionar in elementosAdicionar)
            {
                this._elementos.Add(elementoAdicionar);
            }

        }

        public void ApresentarElementos()
        {

            if (this._elementos.Count > 0)
            {
                this._elementos.ForEach(elemento => Console.WriteLine(elemento.ToString()));
            }
            else
            {
                Console.WriteLine("a lista não possui elementos!");
            }

        }

        public void Remover(T elementoRemover)
        {

            if (this._elementos.Count == 0)
            {
                Console.WriteLine("a lista não possui elementos!");

                return;
            }

            this._elementos.Remove(elementoRemover);
        }

        public void RemoverPeloIndice(int indice)
        {

            if (this._elementos.Count == 0)
            {
                Console.WriteLine("a lista não possui elementos!");

                return;
            }

            if ((this._elementos.Count - 1) < indice || indice < 0)
            {
                Console.WriteLine("indice inválido!");

                return;
            }

            this._elementos.RemoveAt(indice);
        }

        public void Editar(T elementoEditado, int indiceElementoEditar)
        {
            var elementoSeraEditado = this._elementos[ indiceElementoEditar ];

            if (elementoSeraEditado != null)
            {
                this._elementos[ indiceElementoEditar ] = elementoEditado;
            }
            else
            {
                Console.WriteLine("Não foi encontrado um elemento no indice: " + indiceElementoEditar);
            }

        }

    }
}
