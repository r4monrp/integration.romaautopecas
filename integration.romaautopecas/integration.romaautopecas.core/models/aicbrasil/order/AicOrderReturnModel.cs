using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.core.models.aicbrasil.order
{
    public class AicOrderReturnModel
    {
        [JsonProperty("orders")]
        public List<AicOrderModel> orders { get; set; }
    }
}
