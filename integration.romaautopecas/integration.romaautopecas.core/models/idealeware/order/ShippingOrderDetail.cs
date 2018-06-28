using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.core.models.idealeware.order
{
    /// <summary>
    /// Detalhes da entrega
    /// </summary>
    public class ShippingOrderDetail
    {
        /// <summary>
        /// Tipo da entrega
        /// </summary>
        public enShippingType ShippingType { get; set; }
        /// <summary>
        /// Informações da entrega
        /// </summary>
        public DeliveryInformationOrderDetail DeliveryInformation { get; set; }
    }
}
