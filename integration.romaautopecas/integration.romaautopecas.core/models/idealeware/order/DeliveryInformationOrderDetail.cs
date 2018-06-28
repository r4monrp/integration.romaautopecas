using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.core.models.idealeware.order
{
    /// <summary>
    /// Informações de entrega
    /// </summary>
    public class DeliveryInformationOrderDetail
    {
        /// <summary>
        /// Custo de entrega
        /// </summary>
        public decimal ShippingCost { get; set; }
        /// <summary>
        /// Nome do método de entrega
        /// </summary>
        public string DeliveryMethodName { get; set; }
        /// <summary>
        /// Nome da transportadora
        /// </summary>
        public string DeliveryProviderName { get; set; }
        /// <summary>
        /// Prazo de Entrega
        /// </summary>
        public DateTimeOffset DeliveryEstimatedDate { get; set; }
        /// <summary>
        /// Prazo Máximo de Entrega
        /// </summary>
        public DateTimeOffset DeliveryEstimatedDateMax { get; set; }
        /// <summary>
        /// Prazo de entrega em dias úteis
        /// </summary>
        public int DeliveryEstimateBusinessDays { get; set; }
        /// <summary>
        /// Código de rastreio
        /// </summary>
        public string Tracking { get; set; }
    }
}
