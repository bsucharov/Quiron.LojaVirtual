using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class TesteCarrinhoCompras
    {
        //Teste Adicionar Itens ao Carrinho
        [TestMethod]
        public void AdicionarItensAoCarrinho()
        {
            Produto produto1 = new Produto
            {
                produtoID = 1,
                nome = "teste1"
            };

            Produto produto2 = new Produto
            {
                produtoID = 2,
                nome = "teste2"
            };

            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1,2);
            carrinho.AdicionarItem(produto2, 3);
            ItemCarrinho[] itens = carrinho.ItensCarrinho.ToArray();

            Assert.AreEqual(itens.Length, 2);
            Assert.AreEqual(itens[0].Produto, produto1);
            Assert.AreEqual(itens[1].Produto, produto2);
        }

        [TestMethod]
        public void AdicionarProdutoExistente()
        {
            Produto produto1 = new Produto
            {
                produtoID = 1,
                nome = "teste1"
            };

            Produto produto2 = new Produto
            {
                produtoID = 2,
                nome = "teste2"
            };

            //Produto produto3 = new Produto
            //{
            //    produtoID = 3,
            //    nome = "teste3"
            //};

            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 3);
            carrinho.AdicionarItem(produto1, 10);
            ItemCarrinho[] resultado = carrinho.ItensCarrinho.OrderBy(c => c.Produto.produtoID).ToArray();

            Assert.AreEqual(resultado.Length, 2);
            Assert.AreEqual(resultado[0].Quantidade, 11);

        }
    }
}
