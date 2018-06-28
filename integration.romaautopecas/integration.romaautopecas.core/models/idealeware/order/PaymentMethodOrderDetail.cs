using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.core.models.idealeware.order
{
    /// <summary>
    /// Metodo de Pagamento
    /// </summary>
    public class PaymentMethodOrderDetail
    {
        /// <summary>
        /// Tipo do pagamento
        /// </summary>
        public enPaymentMethodType Type { get; set; }
        /// <summary>
        /// Código
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Nome
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Nome do titular do cartão de crédito
        /// </summary>
        public string CreditCardHolderName { get; set; }
        /// <summary>
        /// Contagem de parcelas de cartão de crédito
        /// </summary>
        public int CreditCardInstallmentCount { get; set; }
        /// <summary>
        /// Preço de parcelamento do cartão de crédito
        /// </summary>
        public decimal CreditCardInstallmentPrice { get; set; }
        /// <summary>
        /// Valor total do cartão de crédito
        /// </summary>
        public decimal CreditCardTotalValue { get; set; }
        /// <summary>
        /// Interesse do cartão de crédito
        /// </summary>
        public decimal CreditCardInterest { get; set; }
        /// <summary>
        /// Desconto no boleto
        /// </summary>
        public decimal BankSlipDiscount { get; set; }
        /// <summary>
        /// Valor total do boleto
        /// </summary>
        public decimal BankSlipTotalValue { get; set; }
        /// <summary>
        /// Url do Boleto
        /// </summary>
        public string BankSlipUrl { get; set; }
        /// <summary>
        /// Valor total em dinheiro
        /// </summary>
        public decimal? MoneyTotalValue { get; set; }
        /// <summary>
        /// Valor do troco
        /// </summary>
        public decimal? MoneyChange { get; set; }
    }
}
