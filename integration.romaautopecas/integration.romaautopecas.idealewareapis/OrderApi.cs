using integration.romaautopecas.core;
using integration.romaautopecas.core.helpers;
using integration.romaautopecas.core.providers.idealeware;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace integration.romaautopecas.idealewareapis
{
    public class OrderApi : IOrderApi
    {
        #region Objects
        private HttpClient _client = new HttpClient();
        #endregion

        #region Constructor
        public OrderApi()
        {
            _client.BaseAddress = AppSettings.Apis.OrderApi;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion


        #region Read

        #region Buscar Pedidos Não Integrados
        /// <summary>
        /// Metodo para retornar pedidos não integrados ao ERP
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetOrdersNotIntegrated(string token)
        {
            _client = new HttpClient();
            _client.BaseAddress = AppSettings.Apis.OrderApi;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await new HttpClientHelper(_client)
              .SetEndpoint("orders/notintegrated")
              .AddHeader("Authorization", $"Bearer {token}")
              .GetAsync();
        }
        #endregion

        #endregion

        #region Update

        #region Atualiza o pedido

        /// <summary>
        /// Atualiza um pedido para integrado ao erp
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="id">id da marca</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UpdateOrderIntegrated(string token, string id)
        {
            _client = new HttpClient();
            _client.BaseAddress = AppSettings.Apis.OrderApi;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await new HttpClientHelper(_client)
            .SetEndpoint($"orders/{id}/integrated")
            .AddHeader("Authorization", $"Bearer {token}")
            .PutAsync();
        }
        #endregion

        #endregion
    }
}
