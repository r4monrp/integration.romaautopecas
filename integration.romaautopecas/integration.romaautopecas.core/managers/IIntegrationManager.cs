using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace integration.romaautopecas.core.managers
{
    public interface IIntegrationManager
    {

        #region Autenticação no ERP conforme code
        /// <summary>
        /// Autentica no erp conforme code
        /// </summary>
        /// <param name="code">code</param>
        void RunIntegrationAuthenticateERP(string code);
        #endregion

        #region Integração Produtos/Marcas
        /// <summary>
        /// Iniciar a integração do serviço - Produtos/Marcas - Criaçao
        /// </summary>
        /// <param name="tokenAicBrasil">token</param>
        bool RunIntegrationCreateProductsAndBrands(string tokenAicBrasil);

        /// <summary>
        /// Iniciar a integração do serviço - Produtos/Marcas - Alteração
        /// </summary>
        /// <param name="tokenAicBrasil">token</param>
        bool RunIntegrationUpdateProductsAndBrands(string tokenAicBrasil);
        #endregion

        #region Integração de Pedido
        /// <summary>
        /// Iniciar a integração do serviço - Pedidos
        /// </summary>
        /// <param name="tokenAicBrasil">token</param>
        void RunIntegrationOrder(string tokenAicBrasil);
        #endregion
    }
}
