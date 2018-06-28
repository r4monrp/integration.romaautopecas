using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.core.models.aicbrasil.authenticate
{
    public class AicTokenModel
    {
        /// <summary>
        /// Token
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// Tipo Token
        /// </summary>
        public string token_type { get; set; }

        /// <summary>
        /// Expira em
        /// </summary>
        public int expires_in { get; set; }
    }
}
