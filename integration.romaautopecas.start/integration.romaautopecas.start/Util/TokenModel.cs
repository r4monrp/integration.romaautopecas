using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.start.Util
{
    public class TokenModel
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

        /// <summary>
        /// Refresh Token
        /// </summary>
        public string refresh_token { get; set; }
    }
}
