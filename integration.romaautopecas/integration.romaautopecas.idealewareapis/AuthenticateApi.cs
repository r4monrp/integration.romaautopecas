using integration.romaautopecas.core;
using integration.romaautopecas.core.helpers;
using integration.romaautopecas.core.models.idealeware.authenticate;
using integration.romaautopecas.core.providers.idealeware;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace integration.romaautopecas.idealewareapis
{
    public class AuthenticateApi : IAuthenticateApi
    {

        #region Objects
        private readonly HttpClient _client = new HttpClient();
        #endregion

        #region Constructor
        public AuthenticateApi()
        {
            _client.BaseAddress = AppSettings.Apis.AutenthicateApi;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion

        #region Autnticaçao
        public async Task<HttpResponseMessage> Login(LoginModel login)
            => await new HttpClientHelper(_client)
            .SetEndpoint("authenticate/login")
            .WithContent(login)
            .PostAsync();

        #endregion
    }
}
