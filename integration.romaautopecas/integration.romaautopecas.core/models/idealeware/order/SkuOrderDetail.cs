using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.core.models.idealeware.order
{
    /// <summary>
    /// Sku do Produto - Pedido
    /// </summary>
    public class SkuOrderDetail
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Código
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Código de barras
        /// </summary>
        public string Ean { get; set; }
        /// <summary>
        /// Estoque
        /// </summary>
        public int Stock { get; set; }
        /// <summary>
        /// Preço
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Preço promocional
        /// </summary>
        public decimal PromotionalPrice { get; set; }
        /// <summary>
        /// Dia de inicio da promoção
        /// </summary>
        public DateTimeOffset PromotionalDateStart { get; set; }
        /// <summary>
        /// Dia final da promoção
        /// </summary>
        public DateTimeOffset PromotionalDateEnd { get; set; }
        /// <summary>
        /// Altura
        /// </summary>
        public float Height { get; set; }
        /// <summary>
        /// Largura
        /// </summary>
        public float Width { get; set; }
        /// <summary>
        /// Comprimento
        /// </summary>
        public float Length { get; set; }
        /// <summary>
        /// Peso
        /// </summary>
        public float Weight { get; set; }
        /// <summary>
        /// Imagem
        /// </summary>
        public string PictureUrl { get; set; }
        /// <summary>
        /// Variações
        /// </summary>
        public List<VariationOrderDetail> Variations { get; set; }
    }
}
