using estudos_basico.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.OpcoesMenu
{
    internal class Listas : OpcaoMenu
    {

        public override void ExecutarOpcaoMenu()
        {
            Console.WriteLine("====== List ======");

            List<string> nomes = new List<string>();

            // método Add() adicionar elemento na lista/pode adicionar repetido
            nomes.Add("Gabriel");
            nomes.Add("Maria");
            nomes.Add("Pedro");
            nomes.Add("Gabriel");

            foreach (string nome in nomes)
            {
                Console.WriteLine(nome);
            }

            // posso ter um List de objetos
            var produtos = new List<Produto>();

            produtos.Add(new Produto
            {
                Id = 1,
                Nome = "Produto 1",
                PrecoCompra = 22.98,
                PrecoVenda = 90.88,
                Estoque = 100
            });

            produtos.Add(new Produto(2, "Produto 2", 22.87, 81.87, 890));

            produtos.ForEach(produto => produto.Apresentar());

            // acessar o elemento da lista
            Produto segundoProdutoAdicionado = produtos[1]; // segunda posição da lista

            segundoProdutoAdicionado.Apresentar();

            // obter a quantidade de elementos na lista
            Console.WriteLine($"quantidade de produtos: { produtos.Count }");

            // remover pelo indice
            produtos.RemoveAt(1);

            produtos.ForEach(prod => prod.Apresentar());
        }

    }
}
