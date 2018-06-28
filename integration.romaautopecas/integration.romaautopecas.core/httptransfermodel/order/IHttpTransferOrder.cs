using integration.romaautopecas.core.models.idealeware.order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace integration.romaautopecas.core.httptransfermodel.order
{
    public interface IHttpTransferOrder
    {

        #region Read

        #region Buscar Pedidos Não Integrados
        /// <summary>
        /// Metodo para retornar pedidos não integrados ao ERP
        /// </summary>
        /// <returns></returns>
        List<OrderDetail> GetOrdersNotIntegrated(string token);
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
        OrderDetail UpdateOrderIntegrated(string token, string id);
        #endregion

        #endregion
    }
}
