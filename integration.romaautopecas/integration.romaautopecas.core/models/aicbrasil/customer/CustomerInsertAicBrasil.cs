using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.core.models.aicbrasil.customer
{
    public class CustomerInsertAicBrasil
    {
        [JsonProperty("customers")]
        public List<CustomerCreateAicBrasil> customers { get; set; }
    }
}
