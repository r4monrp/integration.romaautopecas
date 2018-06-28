using integration.romaautopecas.core.models.aicbrasil.authenticate;
using integration.romaautopecas.core.models.aicbrasil.count;
using integration.romaautopecas.core.models.aicbrasil.customer;
using integration.romaautopecas.core.models.aicbrasil.order;
using integration.romaautopecas.core.models.aicbrasil.product;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace integration.romaautopecas.core.httptransfermodel.aicbrasil
{
    public interface IHttpTransferAicBrasil
    {
        #region Autenticação
        /// <summary>
        /// Faz autenticação
        /// </summary>
        /// <returns></returns>
        AicTokenModel AicAuthenticate(string code);
        #endregion

        #region Produto
        /// <summary>
        /// Busca os produtos para serem integrados - Criados
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="alterDate">data de alteração</param>
        /// <param name="initDate">data inicial</param>
        /// <param name="maxDate">data final</param>
        /// <param name="page">Página Atual</param>
        /// <param name="limit">Quantidade por página</param>
        /// <returns></returns>
        List<ProductDetailAicBrasil> GetCreateProductsAsync(string token, DateTime? initDate = null,
            DateTime? maxDate = null, int? page = null, int? limit = null);

        /// <summary>
        /// Busca a quantidade de produtos para serem integrados - Criados
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        CountModel GetCountCreateProductsAsync(string token, DateTime? initDate = null,
            DateTime? maxDate = null, int? page = null, int? limit = null);

        /// <summary>
        /// Busca os produtos para serem integrados - Alterados
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="alterDate">data de alteração</param>
        /// <param name="initDate">data inicial</param>
        /// <param name="maxDate">data final</param>
        /// <param name="page">Página Atual</param>
        /// <param name="limit">Quantidade por página</param>
        /// <returns></returns>
        List<ProductDetailAicBrasil> GetUpdateProductsAsync(string token, DateTime? initDate = null,
            DateTime? maxDate = null, int? page = null, int? limit = null);

        /// <summary>
        /// Busca a quantidade de produtos para serem integrados - Alterados
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        CountModel GetCountUpdateProductsAsync(string token, DateTime? initDate = null,
            DateTime? maxDate = null, int? page = null, int? limit = null);
        #endregion

        #region Pedido
        /// <summary>
        /// Insere o Pedido no ERP
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="order">Pedido</param>
        /// <returns></returns>
        AicOrderReturnModel InsertOrderAsync(string token, AicOrderInsertModel order);
        #endregion

        #region Clientes
        /// <summary>
        /// Insere cliente no ERP
        /// </summary>
        /// <param name="token"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        CustomerReturnAicBrasil InsertCustomerAsync(string token, CustomerInsertAicBrasil customer);

        /// <summary>
        /// Busca um cliente por cpf
        /// </summary>
        /// <param name="token"></param>
        /// <param name="cpf"></param>
        /// <returns></returns>
        CustomerResponseAicBrasil GetCustomersByCpfAsync(string token, string cpf);
        #endregion
    }
}
