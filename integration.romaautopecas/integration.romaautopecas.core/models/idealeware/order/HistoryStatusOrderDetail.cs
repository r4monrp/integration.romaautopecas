using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.core.models.idealeware.order
{
    /// <summary>
    /// Historico de Status do Pedido
    /// </summary>
    public class HistoryStatusOrderDetail
    {
        /// <summary>
        /// Status do pedido
        /// </summary>
        public enOrderStatus Status { get; set; }
        /// <summary>
        /// Dia da alteração
        /// </summary>
        public DateTimeOffset AlterDate { get; set; }
        /// <summary>
        /// Descrição
        /// </summary>
        public string Description { get; set; }
    }
}
