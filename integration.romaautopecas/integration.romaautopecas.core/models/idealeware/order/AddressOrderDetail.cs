using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.core.models.idealeware.order
{
    /// <summary>
    /// Endereço
    /// </summary>
    public class AddressOrderDetail
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Tipo de endereço
        /// </summary>
        public enAddressType AddressType { get; set; }
        /// <summary>
        /// Nome
        /// </summary>
        public string AddressName { get; set; }
        /// <summary>
        /// Endereço
        /// </summary>
        public string AddressLine1 { get; set; }
        /// <summary>
        /// Complemento
        /// </summary>
        public string AddressLine2 { get; set; }
        /// <summary>
        /// Ponto de referencia
        /// </summary>
        public string Landmark { get; set; }
        /// <summary>
        /// Bairro
        /// </summary>
        public string District { get; set; }
        /// <summary>
        /// Cidade
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Estado
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// Pais
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Cep
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// Numero
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// Endereço principal
        /// </summary>
        public bool MainAddress { get; set; }
    }
}
