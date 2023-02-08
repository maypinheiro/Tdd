using System;
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
            var pedido = new Pedido();
            var pedidoItem = new PedidoItem(Guid.NewGuid(),"ProdutoTest",2,100);
            // Act
            pedido.AdicionarItem(pedidoItem);
            //Assert
            Assert.Equal(200, pedido.ValorTotal);
        }
    }
}
