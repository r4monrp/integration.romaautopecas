using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.core.models.idealeware.order
{
    /// <summary>
    /// Tipos de Status
    /// </summary>
    public enum enOrderStatus
    {
        NewOrder = 0,

        ApprovedOrder = 1,

        TransportedOrder = 2,

        FinishedOrder = 3,

        FaturedOrder = 10,

        PendingOrder = 11,

        CanceledOrder = 12,

        ProcessOrder = 13
    }
}
