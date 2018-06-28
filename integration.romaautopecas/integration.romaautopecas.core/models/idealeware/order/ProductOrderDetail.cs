using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.core.models.idealeware.order
{
    /// <summary>
    /// Produto do Pedido
    /// </summary>
    public class ProductOrderDetail
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Nome
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// SKU
        /// </summary>
        public SkuOrderDetail Sku { get; set; }
        /// <summary>
        /// Quantidade
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// (Preço ou Preço Promoção)
        /// </summary>
        public decimal TotalUnitPrice { get; set; }
        /// <summary>
        /// Total desconto
        /// </summary>
        public decimal TotalDiscountPrice { get; set; }
        /// <summary>
        /// Total
        /// </summary>
        public decimal TotalPrice { get; set; }
    }
}
