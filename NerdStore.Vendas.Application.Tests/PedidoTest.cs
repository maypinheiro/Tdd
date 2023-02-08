using System;
using System.Linq;
using Xunit;

namespace NerdStore.Vendas.Application.Tests
{
    public class PedidoTest
    {
        [Fact(DisplayName = "Adicionar Item Novo Pedido")]
        [Trait("Categoria","Vendas -Pedido")]
        public void AdicionarItemPedido_NovoPedido_DeveAtualizarValor()
        {
            //Arrange
            var pedido = Pedido.PedidoFactory.NovoPedidoRascunho(Guid.NewGuid());
            var pedidoItem = new PedidoItem(Guid.NewGuid(),"ProdutoTest",2,100);
            // Act
            pedido.AdicionarItem(pedidoItem);
            //Assert
            Assert.Equal(200, pedido.ValorTotal);
        }


        [Fact(DisplayName = "Adicionar Item Pedido Existente")]
        [Trait("Categoria", "Vendas -Pedido")]
        public void AdicionarItemPedido_ItemExistente_DeveIncrementarUnidadesSomarValores()
        {
            //Arrange
            var pedido = Pedido.PedidoFactory.NovoPedidoRascunho(Guid.NewGuid());
            var produtoId = Guid.NewGuid();
            var pedidoItem = new PedidoItem(produtoId, "ProdutoTest", 2, 100);
            pedido.AdicionarItem(pedidoItem);
            var pedidoItem2= new PedidoItem(produtoId, "ProdutoTest", 1, 100);

            //Act
            pedido.AdicionarItem(pedidoItem2);
            //Assert
            Assert.Equal(300, pedido.ValorTotal);
            Assert.Equal(1, pedido.PedidoItens.Count);
            Assert.Equal(3, pedido.PedidoItens.FirstOrDefault(p=> p.ProdutoId == produtoId).Quantidade);
        }

    }
}
