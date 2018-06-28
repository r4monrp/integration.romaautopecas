using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.core.models.aicbrasil.customer
{
    public class ShippingAddressAicBrasil
    {
        [JsonProperty("country")]
        public string country { get; set; }

        [JsonProperty("address1")]
        public string address1 { get; set; }

        [JsonProperty("number")]
        public int number { get; set; }

        [JsonProperty("address2")]
        public string address2 { get; set; }

        [JsonProperty("district")]
        public string district { get; set; }

        [JsonProperty("state")]
        public string state { get; set; }

        [JsonProperty("city")]
        public string city { get; set; }

        [JsonProperty("zip_postal_code")]
        public string zipcode { get; set; }

        [JsonProperty("created_on_utc")]
        public DateTime createddate { get; set; }
    }
}
