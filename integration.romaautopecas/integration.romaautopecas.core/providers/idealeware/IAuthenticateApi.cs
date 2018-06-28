using integration.romaautopecas.core.models.idealeware.authenticate;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace integration.romaautopecas.core.providers.idealeware
{
    public interface IAuthenticateApi
    {
        /// <summary>
        /// Metodo para efetuar autenticação na API
        /// </summary>
        /// <param name="login">Objeto do login</param>
        /// <returns></returns>
        Task<HttpResponseMessage> Login(LoginModel login);
    }
}
