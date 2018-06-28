﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.core.models.aicbrasil.customer
{
    public class CustomerResponseAicBrasil
    {
        [JsonProperty("customers")]
        public List<CustomerDetailAicBrasil> customers { get; set; }
    }
}
