using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.core.models.idealeware.authenticate
{
    public class TokenModel
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public int ExpiresIn { get; set; }
        public string Created_Date { get; set; }
    }
}
