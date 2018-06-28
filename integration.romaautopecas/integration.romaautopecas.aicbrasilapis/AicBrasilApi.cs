using integration.romaautopecas.core;
using integration.romaautopecas.core.helpers;
using integration.romaautopecas.core.models.aicbrasil.authenticate;
using integration.romaautopecas.core.models.aicbrasil.customer;
using integration.romaautopecas.core.models.aicbrasil.order;
using integration.romaautopecas.core.providers.aicbrasil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace integration.romaautopecas.aicbrasilapis
{
    public class AicBrasilApi : IAicBrasilApi
    {
        #region Authenticate
        public async Task<HttpWebResponse> AicAuthenticate(string code)
        {
            var credentials = AppSettings.GetCredentials();
           
            string requestUriStringToken = $"{AppSettings.Apis.AicBrasilApi}api/token";

            string queryParametersToken = $"client_id={credentials.ClientId}&client_secret={credentials.ClientSecret}&code={code}&grant_type=authorization_code&redirect_uri={AppSettings.CallbackUrl}";

            var httpWebRequestToken = (HttpWebRequest)WebRequest.Create(requestUriStringToken);
            httpWebRequestToken.Method = "POST";
            httpWebRequestToken.ContentType = "application/x-www-form-urlencoded";

            using (new MemoryStream())
            {
                using (var streamWriter = new StreamWriter( await httpWebRequestToken.GetRequestStreamAsync()))
                {
                    streamWriter.Write(queryParametersToken);
                    streamWriter.Close();
                }
            }

            var httpWebResponseToken = (HttpWebResponse)await httpWebRequestToken.GetResponseAsync();

            return httpWebResponseToken;
        }
        #endregion

        #region Produto
        public async Task<HttpResponseMessage> GetCreateProductsAsync(string token, DateTime? initDate = null, DateTime? maxDate = null
            , int? page = null, int? limit = null)
        {
            HttpClient _client = new HttpClient();
            _client.BaseAddress = AppSettings.Apis.AicBrasilApi;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await new HttpClientHelper(_client)
            .SetEndpoint($"api/parts?created_at_min={initDate?.ToString("yyyy-MM-ddTHH:mm:ss")}&created_at_max={maxDate?.ToString("yyyy-MM-ddTHH:mm:ss")}&page={page}&limit={limit}")
            .AddHeader("Authorization", $"Bearer {token}")
            .GetAsync();
        }

        public async Task<HttpResponseMessage> GetCountCreateProductsAsync(string token, DateTime? initDate = null,
            DateTime? maxDate = null)
        {
            HttpClient _client = new HttpClient();
            _client.BaseAddress = AppSettings.Apis.AicBrasilApi;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await new HttpClientHelper(_client)
           .SetEndpoint($"api/parts/count?created_at_min={initDate?.ToString("yyyy-MM-ddTHH:mm:ss")}&created_at_max={maxDate?.ToString("yyyy-MM-ddTHH:mm:ss")}")
           .AddHeader("Authorization", $"Bearer {token}")
           .GetAsync();
        }


        public async Task<HttpResponseMessage> GetUpdateProductsAsync(string token, DateTime? initDate = null, DateTime? maxDate = null
    , int? page = null, int? limit = null)
        {
            HttpClient _client = new HttpClient();
            _client.BaseAddress = AppSettings.Apis.AicBrasilApi;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await new HttpClientHelper(_client)
            .SetEndpoint($"api/parts?updated_at_min={initDate?.ToString("yyyy-MM-ddTHH:mm:ss")}&updated_at_max={maxDate?.ToString("yyyy-MM-ddTHH:mm:ss")}&page={page}&limit={limit}")
            .AddHeader("Authorization", $"Bearer {token}")
            .GetAsync();
        }

        public async Task<HttpResponseMessage> GetCountUpdateProductsAsync(string token, DateTime? initDate = null,
            DateTime? maxDate = null)
        {
            HttpClient _client = new HttpClient();
            _client.BaseAddress = AppSettings.Apis.AicBrasilApi;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await new HttpClientHelper(_client)
           .SetEndpoint($"api/parts/count?updated_at_min={initDate?.ToString("yyyy-MM-ddTHH:mm:ss")}&updated_at_max={maxDate?.ToString("yyyy-MM-ddTHH:mm:ss")}")
           .AddHeader("Authorization", $"Bearer {token}")
           .GetAsync();
        }

        #endregion

        #region Pedido
        /// <summary>
        /// Inserir pedido no ERP
        /// </summary>
        /// <param name="token">Token autenticado</param>
        /// <param name="order">Objeto do pedido</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> InsertOrderAsync(string token, AicOrderInsertModel order)
        {
            HttpClient _client = new HttpClient();
            _client.BaseAddress = AppSettings.Apis.AicBrasilApi;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await new HttpClientHelper(_client)
              .SetEndpoint($"api/orders")
              .AddHeader("Authorization", $"Bearer {token}")
              .WithContentSerialized(order)
              .PostAsync();
        }
        #endregion

        #region Clientes

        public async Task<HttpResponseMessage> InsertCustomerAsync(string token, CustomerInsertAicBrasil customer)
        {
            HttpClient _client = new HttpClient();
            _client.BaseAddress = AppSettings.Apis.AicBrasilApi;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await new HttpClientHelper(_client)
              .SetEndpoint($"api/customers")
              .AddHeader("Authorization", $"Bearer {token}")
              .WithContentSerialized(customer)
              .PostAsync();
        }

        public async Task<HttpResponseMessage> GetCustomersByCpfAsync(string token, string cpf)
        {
            HttpClient _client = new HttpClient();
            _client.BaseAddress = AppSettings.Apis.AicBrasilApi;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await new HttpClientHelper(_client)
              .SetEndpoint($"api/customers?cpf_cnpj={cpf}")
              .AddHeader("Authorization", $"Bearer {token}")
              .GetAsync();
        }
        #endregion
    }
}
