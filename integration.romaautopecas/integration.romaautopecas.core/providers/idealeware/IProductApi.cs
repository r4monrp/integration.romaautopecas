using integration.romaautopecas.core.models.idealeware.product;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace integration.romaautopecas.core.providers.idealeware
{
    public interface IProductApi
    {

        #region Create

        #region Inserir informações basicas de produto
        /// <summary>
        /// Inserir Produto - Informações basicas
        /// </summary>
        /// <returns></returns>
        Task<HttpResponseMessage> CreateProductInformation(string token, ProductInformationCreate product);
        #endregion

        #region Inserir SKU do Produto
        /// <summary>
        /// Inserir SKU do Produto
        /// </summary>
        /// <returns></returns>
        Task<HttpResponseMessage> CreateProductSKU(string token, string id, SkuCreate sku);
        #endregion

        #endregion

        #region Read

        #region Buscar Produtos
        /// <summary>
        /// Metodo para retornar produtos completos
        /// </summary>
        /// <returns></returns>
        Task<HttpResponseMessage> GetProductsComplete(string token);
        #endregion

        #endregion

        #region Update

        #region Informações Basicas
        /// <summary>
        /// Alterar Produto - Informações basicas
        /// </summary>
        /// <returns></returns>
        Task<HttpResponseMessage> UpdateProductInformation(string token, string id, ProductInformationUpdate product);
        #endregion

        #region Categorias
        /// <summary>
        /// Alterar Produto - Categorias
        /// </summary>
        /// <returns></returns>
        Task<HttpResponseMessage> UpdateProductCategories(string token, string id, List<CategoryReference> categories);
        #endregion

        #region SEO
        /// <summary>
        /// Alterar Produto - SEO
        /// </summary>
        /// <returns></returns>
        Task<HttpResponseMessage> UpdateProductSEO(string token, string id, ProductSeoUpdate seo);
        #endregion

        #endregion


        #region SKU do Produto
        /// <summary>
        /// Alterar Produto - SKU
        /// </summary>
        /// <returns></returns>
        Task<HttpResponseMessage> UpdateProductSKU(string token, string id, string skuId, SkuUpdate sku);

        /// <summary>
        /// Alterar Produto - SKU FRETE
        /// </summary>
        /// <returns></returns>
        Task<HttpResponseMessage> UpdateProductSKUFreight(string token, string id, string skuId, SkuUpdate sku);
        #endregion
    }
}
