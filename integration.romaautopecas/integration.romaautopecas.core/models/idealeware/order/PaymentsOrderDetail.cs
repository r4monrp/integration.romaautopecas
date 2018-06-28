using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.core.models.idealeware.order
{
    /// <summary>
    /// Informaçoes Pagamento
    /// </summary>
    public class PaymentsOrderDetail
    {
        /// <summary>
        /// Nome do Gateway (MundiPagg, PagSeguro, Pagamento na Retirada, Pagamento na Entrega)
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Online ou Offline
        /// </summary>
        public enPaymentType PaymentType { get; set; }
        /// <summary>
        ///  TransactionId da MundiPagg, Codigo do PagSeguro...
        /// </summary>
        public string PaymentReferenceCode { get; set; }
        /// <summary>
        ///  Data do Pagamento
        /// </summary>
        public DateTimeOffset PaymentDate { get; set; }
        /// <summary>
        /// Metodos de pagamento
        /// </summary>
        public IEnumerable<PaymentMethodOrderDetail> PaymentMethods { get; set; }
    }
}
