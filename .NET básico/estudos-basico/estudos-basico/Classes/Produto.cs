using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_basico.Classes
{
    internal class Produto
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public double PrecoCompra { get; set; }
        public double PrecoVenda { get; set; }
        public int Estoque { get; set; }

        public Produto() { }

        public Produto(int id, string nome, double precoCompra, double precoVenda, int unidadesEstoque)
        {
            this.Id = id;
            this.Nome = nome;
            this.PrecoCompra = precoCompra;
            this.PrecoVenda = precoVenda;
            this.Estoque = unidadesEstoque;
        }

        public void Apresentar()
        {
            Console.WriteLine("======================================");
            Console.WriteLine($"id: { this.Id }");
            Console.WriteLine($"nome: { this.Nome }");
            Console.WriteLine($"preço de compra: { this.PrecoCompra }");
            Console.WriteLine($"preço de venda: { this.PrecoVenda }");
            Console.WriteLine($"unidades em estoque: { this.Estoque }");
        }

    }
}
