using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.core.models.idealeware.order
{
    /// <summary>
    /// Formas de Pagamentos
    /// </summary>
    public enum enPaymentMethodType
    {
        /// <summary>
        /// Cartão de Crédito
        /// </summary>
        CreditCard = 1,

        /// <summary>
        /// Boleto
        /// </summary>
        BankSlip = 2,

        /// <summary>
        /// Dinheiro
        /// </summary>
        Money = 3,

        /// <summary>
        /// Outros
        /// </summary>
        Other = 99
    }
}
