using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.core.models.idealeware.order
{
    /// <summary>
    /// Pedido
    /// </summary>
    public class OrderDetail
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Origem do Pedido (MarketPlace)
        /// </summary>
        public string Origin { get; set; }

        /// <summary>
        /// Numero do pedido
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Cliente
        /// </summary>
        public CustomerOrderDetail Customer { get; set; }
        /// <summary>
        /// Endereço de entrega
        /// </summary>
        public AddressOrderDetail DeliveryAddress { get; set; }
        /// <summary>
        /// Endereço de cobrança
        /// </summary>
        public AddressOrderDetail BillingAddress { get; set; }

        /// <summary>
        /// Informaçoes de Entrega/Frete
        /// </summary>
        public ShippingOrderDetail Shipping { get; set; }

        /// <summary>
        /// Pagamentos
        /// </summary>
        public PaymentsOrderDetail Payment { get; set; }
        /// <summary>
        /// Dia de criação
        /// </summary>
        public DateTimeOffset CreatedDate { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        public enOrderStatus Status { get; set; }
        /// <summary>
        /// Histórico de status
        /// </summary>
        public List<HistoryStatusOrderDetail> HistoryStatus { get; set; }
        /// <summary>
        /// Valor total de produtos
        /// </summary>
        public decimal TotalProductsPrice { get; set; }
        /// <summary>
        /// Valor total do fréte
        /// </summary>
        public decimal TotalFreightPrice { get; set; }
        /// <summary>
        /// Valor total do desconto
        /// </summary>
        public decimal TotalDiscountPrice { get; set; }
        /// <summary>
        /// Valor total dos serviços
        /// </summary>
        public decimal TotalServicePrice { get; set; }
        /// <summary>
        /// Valor total do pedido
        /// </summary>
        public decimal OrderPrice { get; set; }

        /// <summary>
        /// Produtos
        /// </summary>
        public List<ProductOrderDetail> Products { get; set; }

        /// <summary>
        /// Integrado ao ERP
        /// </summary>
        public bool Integrated { get; set; }

        /// <summary>
        /// Data da Integração
        /// </summary>
        public DateTimeOffset IntegratedDate { get; set; }
    }
}
