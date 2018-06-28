using integration.romaautopecas.core.models.aicbrasil.authenticate;
using integration.romaautopecas.core.models.aicbrasil.customer;
using integration.romaautopecas.core.models.aicbrasil.order;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace integration.romaautopecas.core.providers.aicbrasil
{
    public interface IAicBrasilApi
    {
        #region Authenticate
        /// <summary>
        /// Faz autenticação
        /// </summary>
        /// <returns></returns>
        Task<HttpWebResponse> AicAuthenticate(string code);
        #endregion

        #region Produto
        /// <summary>
        /// Busca os produtos para serem integrados - Criados
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="initDate">data inicial</param>
        /// <param name="maxDate">data final</param>
        /// <param name="page">Página Atual</param>
        /// <param name="limit">Quantidade por página</param>
        /// <returns></returns>
        Task<HttpResponseMessage> GetCreateProductsAsync(string token, DateTime? initDate = null, 
            DateTime? maxDate = null, int? page = null, int? limit = null);

        /// <summary>
        /// Busca a quantidade de produtos para serem integrados - Criados
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> GetCountCreateProductsAsync(string token, DateTime? initDate = null,
            DateTime? maxDate = null);

        /// <summary>
        /// Busca os produtos para serem integrados - Alterados
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="initDate">data inicial</param>
        /// <param name="maxDate">data final</param>
        /// <param name="page">Página Atual</param>
        /// <param name="limit">Quantidade por página</param>
        /// <returns></returns>
        Task<HttpResponseMessage> GetUpdateProductsAsync(string token, DateTime? initDate = null,
            DateTime? maxDate = null, int? page = null, int? limit = null);

        /// <summary>
        /// Busca a quantidade de produtos para serem integrados - Criados
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> GetCountUpdateProductsAsync(string token, DateTime? initDate = null,
            DateTime? maxDate = null);
        #endregion

        #region Pedido
        /// <summary>
        /// Inserir pedido no ERP
        /// </summary>
        /// <param name="token">Token autenticado</param>
        /// <param name="order">Objeto do pedido</param>
        /// <returns></returns>
        Task<HttpResponseMessage> InsertOrderAsync(string token, AicOrderInsertModel order);
        #endregion

        #region Clientes
        /// <summary>
        /// Insere cliente no ERP
        /// </summary>
        /// <param name="token"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> InsertCustomerAsync(string token, CustomerInsertAicBrasil customer);

        /// <summary>
        /// Busca um cliente por cpf
        /// </summary>
        /// <param name="token"></param>
        /// <param name="cpf"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> GetCustomersByCpfAsync(string token, string cpf);
        #endregion
    }
}
