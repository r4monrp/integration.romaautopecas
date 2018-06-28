using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.core.models.idealeware.authenticate
{
    public class LoginModel
    {
        public string Domain { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
    }
}
