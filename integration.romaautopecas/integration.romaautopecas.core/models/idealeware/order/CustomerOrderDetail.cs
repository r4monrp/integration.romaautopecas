using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.core.models.idealeware.order
{
    /// <summary>
    /// Cliente
    /// </summary>
    public class CustomerOrderDetail
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Código
        /// </summary>
        public string Code { get; set; } //Para integração com terceiros
        /// <summary>
        /// RG / Inscrição estadual
        /// </summary>
        public string Rg_Ie { get; set; }
        /// <summary>
        /// CPF / CNPJ
        /// </summary>
        public string Cpf_Cnpj { get; set; }
        /// <summary>
        /// Nome / Razaão social
        /// </summary>
        public string Firstname_Companyname { get; set; }
        /// <summary>
        /// Sobrenome / Nome fantasia
        /// </summary>
        public string Lastname_Tradingname { get; set; }
        /// <summary>
        /// Genero
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// Dia de aniversario
        /// </summary>
        public DateTimeOffset Birthdate { get; set; }
        /// <summary>
        /// Telefone
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Celular
        /// </summary>
        public string CelPhone { get; set; }
        /// <summary>
        /// E-mail
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Tipo
        /// </summary>
        public enCustomerType Type { get; set; }

        /// <summary>
        /// Lista de Endereços do Cliente
        /// </summary>
        public List<AddressOrderDetail> AddressesCustomer { get; set; }
    }
}
