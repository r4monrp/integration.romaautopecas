using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.core.models.aicbrasil.order
{
    public class AicOrderModel
    {
        [JsonProperty("order_discount")]
        public decimal orderDiscount { get; set; }

        [JsonProperty("order_total")]
        public decimal orderTotal { get; set; }

        [JsonProperty("customer_ip")]
        public string customerIp { get; set; }

        [JsonProperty("customer_code")]
        public string customercode { get; set; }

        [JsonProperty("destination_type")]
        public string destinationtype { get; set; }

        [JsonProperty("billing_type")]
        public string billingtype { get; set; }

        [JsonProperty("shipping_type")]
        public string shippingtype { get; set; }

        [JsonProperty("installments")]
        public int installments { get; set; }

        [JsonProperty("order_items")]
        public List<AicItemOrderModel> orderitens { get; set; }
    }
}
