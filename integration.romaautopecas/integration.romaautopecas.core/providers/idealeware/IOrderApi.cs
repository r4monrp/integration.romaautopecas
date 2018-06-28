using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace integration.romaautopecas.core.providers.idealeware
{
    public interface IOrderApi
    {

        #region Read

        #region Buscar Pedidos Não Integrados
        /// <summary>
        /// Metodo para retornar pedidos não integrados ao ERP
        /// </summary>
        /// <returns></returns>
        Task<HttpResponseMessage> GetOrdersNotIntegrated(string token);
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
        Task<HttpResponseMessage> UpdateOrderIntegrated(string token, string id);
        #endregion

        #endregion
    }
}
