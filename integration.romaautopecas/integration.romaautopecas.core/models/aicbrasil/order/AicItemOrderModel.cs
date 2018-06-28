using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.core.models.aicbrasil.order
{
    public class AicItemOrderModel
    {
        [JsonProperty("part_code")]
        public string code { get; set; }
    }
}
