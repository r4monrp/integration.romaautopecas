using integration.romaautopecas.core;
using integration.romaautopecas.core.helpers;
using integration.romaautopecas.core.models.idealeware.product;
using integration.romaautopecas.core.providers.idealeware;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace integration.romaautopecas.idealewareapis
{
    public class ProductApi : IProductApi
    {
        #region Objects
        private HttpClient _client = new HttpClient();
        #endregion

        #region Constructor
        public ProductApi()
        {
            _client.BaseAddress = AppSettings.Apis.BrandApi;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion

        #region Create

        #region Inserir informações basicas de produto
        /// <summary>
        /// Inserir Produto - Informações basicas
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CreateProductInformation(string token, ProductInformationCreate product)
        {
            _client = new HttpClient();
            _client.BaseAddress = AppSettings.Apis.ProductApi;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await new HttpClientHelper(_client)
            .SetEndpoint("products/information")
            .AddHeader("Authorization", $"Bearer {token}")
            .WithContentSerialized(product)
            .PostAsync();
        }

        #endregion

        #region Inserir SKU do Produto
        /// <summary>
        /// Inserir SKU do Produto
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CreateProductSKU(string token, string id, SkuCreate sku)
        {
            _client = new HttpClient();
            _client.BaseAddress = AppSettings.Apis.ProductApi;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await new HttpClientHelper(_client)
              .SetEndpoint($"products/{id}/sku")
              .AddHeader("Authorization", $"Bearer {token}")
              .WithContentSerialized(sku)
              .PostAsync();
        }
        #endregion

        #endregion

        #region Read

        #region Buscar Produtos
        /// <summary>
        /// Metodo para retornar produtos completos
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetProductsComplete(string token)
        {
            _client = new HttpClient();
            _client.BaseAddress = AppSettings.Apis.ProductApi;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await new HttpClientHelper(_client)
              .SetEndpoint("products/complete")
              .AddHeader("Authorization", $"Bearer {token}")
              .GetAsync();
        }
        #endregion

        #endregion

        #region Update

        #region Informações Basicas
        /// <summary>
        /// Alterar Produto - Informações basicas
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UpdateProductInformation(string token, string id, ProductInformationUpdate product)
        {
            _client = new HttpClient();
            _client.BaseAddress = AppSettings.Apis.ProductApi;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await new HttpClientHelper(_client)
              .SetEndpoint($"products/{id}/information")
              .AddHeader("Authorization", $"Bearer {token}")
              .WithContentSerialized(product)
              .PutAsync();
        }
        #endregion

        #region Categorias
        /// <summary>
        /// Alterar Produto - Categorias
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UpdateProductCategories(string token, string id, List<CategoryReference> categories)
        {
            _client = new HttpClient();
            _client.BaseAddress = AppSettings.Apis.ProductApi;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await new HttpClientHelper(_client)
              .SetEndpoint($"products/{id}/categories")
              .AddHeader("Authorization", $"Bearer {token}")
              .WithContentSerialized(categories)
              .PutAsync();
        }
        #endregion

        #region SEO
        /// <summary>
        /// Alterar Produto - SEO
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UpdateProductSEO(string token, string id, ProductSeoUpdate seo)
        {
            _client = new HttpClient();
            _client.BaseAddress = AppSettings.Apis.ProductApi;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await new HttpClientHelper(_client)
              .SetEndpoint($"products/{id}/seo")
              .AddHeader("Authorization", $"Bearer {token}")
              .WithContentSerialized(seo)
              .PutAsync();
        }
        #endregion

        #endregion


        #region SKU do Produto
        /// <summary>
        /// Alterar Produto - SKU
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UpdateProductSKU(string token, string id, string skuId, SkuUpdate sku)
        {
            _client = new HttpClient();
            _client.BaseAddress = AppSettings.Apis.ProductApi;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await new HttpClientHelper(_client)
              .SetEndpoint($"products/{id}/sku/{skuId}")
              .AddHeader("Authorization", $"Bearer {token}")
              .WithContentSerialized(sku)
              .PutAsync();
        }

        /// <summary>
        /// Alterar Produto - SKU
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UpdateProductSKUFreight(string token, string id, string skuId, SkuUpdate sku)
        {
            _client = new HttpClient();
            _client.BaseAddress = AppSettings.Apis.ProductApi;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await new HttpClientHelper(_client)
              .SetEndpoint($"products/{id}/sku/{skuId}/freight")
              .AddHeader("Authorization", $"Bearer {token}")
              .WithContentSerialized(sku)
              .PutAsync();
        }
        #endregion
    }
}
