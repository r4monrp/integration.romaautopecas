using integration.romaautopecas.core.models.idealeware.order;
using integration.romaautopecas.core.providers.idealeware;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace integration.romaautopecas.core.httptransfermodel.order
{
    public class HttpTransferOrder : IHttpTransferOrder
    {
        #region Objetos
        private readonly IOrderApi _orderApi;
        private readonly ILogger _logger;
        #endregion

        #region Construtor
        public HttpTransferOrder(IOrderApi orderApi, ILoggerFactory logger)
        {
            this._orderApi = orderApi;
            this._logger = logger.CreateLogger("HttpTransferOrder");
            _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} - HttpTransferOrder em execução.");
        }
        #endregion

        #region Read

        #region Buscar Pedidos Não Integrados
        /// <summary>
        /// Metodo para retornar pedidos não integrados ao ERP
        /// </summary>
        /// <returns></returns>
        public  List<OrderDetail> GetOrdersNotIntegrated(string token)
        {
            try
            {

                _logger.LogInformation("Buscar todos as pedidos nao integrados: Enviando requisição para a API");
                var response =  _orderApi.GetOrdersNotIntegrated(token).Result;
                if (!response.IsSuccessStatusCode)
                {
                    var contentResult =  response.Content.ReadAsStringAsync().Result;
                    _logger.LogError($"Buscar todos as pedidos nao integrados: API retornou erro :( - {response.StatusCode}-{response.ReasonPhrase} -> {contentResult}");
                    if (((int)response.StatusCode) >= 400 && ((int)response.StatusCode) < 500)
                        return null;
                }
                _logger.LogInformation("Buscar todos as pedidos nao integrados: API retornou sucesso :)");

                var json =  response.Content.ReadAsStringAsync().Result;
                return  Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<OrderDetail>>(json)).Result;

            }
            catch (Exception)
            {
                _logger.LogError($"Buscar todos as pedidos nao integrados: API retornou erro :(");
                return null;
            }
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
        public OrderDetail UpdateOrderIntegrated(string token, string id)
        {
            try
            {

                _logger.LogInformation("Altera uma pedido para integrado: Enviando requisição para a API");
                var response =  _orderApi.UpdateOrderIntegrated(token, id).Result;
                if (!response.IsSuccessStatusCode)
                {
                    var contentResult =  response.Content.ReadAsStringAsync().Result;
                    _logger.LogError($"Altera uma pedido para integrado: API retornou erro :( - {response.StatusCode}-{response.ReasonPhrase} -> {contentResult}");
                    if (((int)response.StatusCode) >= 400 && ((int)response.StatusCode) <= 500)
                        return null;
                }
                _logger.LogInformation("Altera uma pedido para integrado: API retornou sucesso :)");

                var json =  response.Content.ReadAsStringAsync().Result;
                return  Task.Factory.StartNew(() => JsonConvert.DeserializeObject<OrderDetail>(json)).Result;

            }
            catch (Exception)
            {
                _logger.LogError($"Altera uma pedido para integrado: API retornou erro :(");
                return null;
            }
        }
        #endregion

        #endregion
    }
}
