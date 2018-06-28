using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.core.models.aicbrasil.order
{
    public class AicCustomerOrderModel
    {
        [JsonProperty("code")]
        public string code { get; set; }

        [JsonProperty("cpf_cnpj")]
        public string cpfcnpj { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("first_name")]
        public string firstName { get; set; }

        [JsonProperty("last_name")]
        public string lastName { get; set; }

        [JsonProperty("created_on_utc")]
        public DateTime createddate { get; set; }
    }
}
