using integration.romaautopecas.core.models.idealeware.product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace integration.romaautopecas.core.httptransfermodel.product
{
    public interface IHttpTransferProduct
    {
        #region Create

        #region Inserir informações basicas de produto
        /// <summary>
        /// Inserir Produto - Informações basicas
        /// </summary>
        /// <returns></returns>
        ProductDetail CreateProductInformation(string token, ProductInformationCreate product);
        #endregion

        #region Inserir SKU do Produto
        /// <summary>
        /// Inserir SKU do Produto
        /// </summary>
        /// <returns></returns>
        ProductDetail CreateProductSKU(string token, string id, SkuCreate sku);
        #endregion

        #endregion

        #region Read

        #region Buscar Produtos
        /// <summary>
        /// Metodo para retornar produtos completos
        /// </summary>
        /// <returns></returns>
        List<ProductDetail> GetProductsComplete(string token);
        #endregion

        #endregion

        #region Update

        #region Informações Basicas
        /// <summary>
        /// Alterar Produto - Informações basicas
        /// </summary>
        /// <returns></returns>
        ProductDetail UpdateProductInformation(string token, string id, ProductInformationUpdate product);
        #endregion

        #region Categorias
        /// <summary>
        /// Alterar Produto - Categorias
        /// </summary>
        /// <returns></returns>
        ProductDetail UpdateProductCategories(string token, string id, List<CategoryReference> categories);
        #endregion

        #region SEO
        /// <summary>
        /// Alterar Produto - SEO
        /// </summary>
        /// <returns></returns>
        ProductDetail UpdateProductSEO(string token, string id, ProductSeoUpdate seo);
        #endregion

        #endregion

        #region SKU do Produto
        /// <summary>
        /// Alterar Produto - SKU
        /// </summary>
        /// <returns></returns>
        ProductDetail UpdateProductSKU(string token, string id, string skuId, SkuUpdate sku);

        /// <summary>
        /// Alterar Produto - SKU FRETE
        /// </summary>
        /// <returns></returns>
        ProductDetail UpdateProductSKUFreight(string token, string id, string skuId, SkuUpdate sku);
        #endregion
    }
}
