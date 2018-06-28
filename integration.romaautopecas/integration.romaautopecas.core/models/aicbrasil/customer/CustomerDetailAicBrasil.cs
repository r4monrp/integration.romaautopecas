using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.core.models.aicbrasil.customer
{
    public class CustomerDetailAicBrasil
    {
        [JsonProperty("code")]
        public string code { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("phone")]
        public string phone { get; set; }

        [JsonProperty("ie")]
        public string ie { get; set; }

        [JsonProperty("cpf_cnpj")]
        public string cpfcnpj { get; set; }
        
        [JsonProperty("first_name")]
        public string firstname { get; set; }

        [JsonProperty("last_name")]
        public string lastname { get; set; }

        [JsonProperty("billing_address")]
        public BillingAddressAicBrasil billingaddress { get; set; }

        [JsonProperty("shipping_address")]
        public ShippingAddressAicBrasil shippingaddress { get; set; }


    }
}
