﻿using ApiCatalogoProdutos.Contexto;
using ApiCatalogoProdutos.DTO;
using ApiCatalogoProdutos.Models;

namespace ApiCatalogoProdutos.Repositorios
{
    public class ProdutoRepositorio : Repositorio<ProdutoDTO>
    {

        public ProdutoRepositorio(AppDbContexto contexto): base(contexto) { }

        public override ProdutoDTO BuscarPeloId(int id)
        {

            return new ProdutoDTO();
        }

        public override List<ProdutoDTO> BuscarTodos()
        {
            List<Produto> produtos = this._contexto.Produtos.ToList();
            List<ProdutoDTO> produtosDTO = new List<ProdutoDTO>();

            foreach (Produto produto in produtos)
            {
                ProdutoDTO produtoDTO = new ProdutoDTO();
                produtoDTO.ProdutoId = produto.ProdutoId;
                produtoDTO.UrlImagemProduto = produto.UrlImagemProduto;
                produtoDTO.Nome = produto.Nome;
                produtoDTO.PrecoCompra = produto.PrecoCompra;
                produtoDTO.PrecoVenda = produto.PrecoVenda;
                produtoDTO.Ativo = produto.Ativo;
                produtoDTO.UnidadesEstoque = produto.UnidadesEstoque;
                produtoDTO.CategoriaId = produto.CategoriaId;
               
                produtosDTO.Add(produtoDTO);
            }

            return produtosDTO;
        }

        public override bool Cadastrar(ProdutoDTO model)
        {
            Produto produto = new Produto();
            produto.Nome = model.Nome;
            produto.UrlImagemProduto = model.UrlImagemProduto;
            produto.PrecoVenda = model.PrecoVenda;
            produto.PrecoCompra = model.PrecoCompra;
            produto.Ativo = true;
            produto.Descricao = model.Descricao;
            produto.UnidadesEstoque = model.UnidadesEstoque;
            produto.CategoriaId = model.CategoriaId;

            // persistir o produto na base de dados
            this._contexto.Produtos.Add(produto);
            this._contexto.SaveChanges();

            return true;
        }

        public override bool Editar(ProdutoDTO model)
        {

            return true;
        }

    }
}