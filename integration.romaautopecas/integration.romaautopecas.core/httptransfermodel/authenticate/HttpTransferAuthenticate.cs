using integration.romaautopecas.core.models.idealeware.authenticate;
using integration.romaautopecas.core.providers.idealeware;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace integration.romaautopecas.core.httptransfermodel.authenticate
{
    public class HttpTransferAuthenticate : IHttpTransferAuthenticate
    {
        #region Objetos
        private readonly IAuthenticateApi _authenticateApi;
        private readonly ILogger _logger;
        #endregion

        #region Construtor
        public HttpTransferAuthenticate(IAuthenticateApi authenticateApi, ILoggerFactory logger)
        {
            this._authenticateApi = authenticateApi;
            this._logger = logger.CreateLogger("HttpTransferAuthenticate");
            _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} - HttpTransferAuthenticate em execução.");
        }
        #endregion

        #region Login
        /// <summary>
        /// Metodo para efetuar autenticação na API
        /// </summary>
        /// <param name="login">Objeto do login</param>
        /// <returns></returns>
        public TokenModel Login(LoginModel login)
        {
            try
            {

            _logger.LogInformation("Efetuar autenticação na API: Enviando requisição para a API");
            var response =  _authenticateApi.Login(login).Result;
            if (!response.IsSuccessStatusCode)
            {
                var contentResult =  response.Content.ReadAsStringAsync().Result;
                _logger.LogError($"Efetuar autenticação na API: API retornou erro :( - {response.StatusCode}-{response.ReasonPhrase} -> {contentResult}");
                if (((int)response.StatusCode) >= 400 && ((int)response.StatusCode) < 500)
                    return null;

            }
            _logger.LogInformation("Efetuar autenticação na API: API retornou sucesso :)");

            var json =  response.Content.ReadAsStringAsync().Result;
            return  Task.Factory.StartNew(() => JsonConvert.DeserializeObject<TokenModel>(json)).Result;

            }
            catch (Exception)
            {
                _logger.LogError($"Efetuar autenticação na API: API retornou erro :(");
                return null;
            }
        }
        #endregion

    }
}
