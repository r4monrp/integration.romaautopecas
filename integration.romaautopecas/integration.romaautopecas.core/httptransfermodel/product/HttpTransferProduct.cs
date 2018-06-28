using integration.romaautopecas.core.providers.idealeware;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using integration.romaautopecas.core.models.idealeware.product;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace integration.romaautopecas.core.httptransfermodel.product
{
    public class HttpTransferProduct : IHttpTransferProduct
    {
        #region Objetos
        private readonly IProductApi _ProductApi;
        private readonly ILogger _logger;
        #endregion

        #region Construtor
        public HttpTransferProduct(IProductApi productApi, ILoggerFactory logger)
        {
            this._ProductApi = productApi;
            this._logger = logger.CreateLogger("HttpTransferProductModel");
            _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} - HttpTransferProductModel em execução.");
        }
        #endregion

        #region Create

        #region Inserir informações basicas de produto
        /// <summary>
        /// Inserir Produto - Informações basicas
        /// </summary>
        /// <returns></returns>
        public ProductDetail CreateProductInformation(string token, ProductInformationCreate product)
        {
            try
            {
                _logger.LogInformation("Criar informações basicas - Produto: Enviando requisição para a API");
                var response =  _ProductApi.CreateProductInformation(token, product).Result;
                if (!response.IsSuccessStatusCode)
                {
                    var contentResult =  response.Content.ReadAsStringAsync().Result;
                    _logger.LogError($"Criar informações basicas - Produto: API retornou erro :( - {response.StatusCode}-{response.ReasonPhrase} -> {contentResult}");
                    if (((int)response.StatusCode) >= 400 && ((int)response.StatusCode) < 500)
                        return null;
                }
                _logger.LogInformation("Criar informações basicas - Produto: API retornou sucesso :)");

                var json =  response.Content.ReadAsStringAsync().Result;
                return  Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ProductDetail>(json)).Result;
            }
            catch (Exception)
            {
                _logger.LogError($"Criar informações basicas - Produto: API retornou erro :(");
                return null;
            }

        }
        #endregion

        #region Inserir SKU do Produto
        /// <summary>
        /// Inserir SKU do Produto
        /// </summary>
        /// <returns></returns>
        public ProductDetail CreateProductSKU(string token, string id, SkuCreate sku)
        {
            try
            {
                _logger.LogInformation("Criar SKU - Produto: Enviando requisição para a API");
                var response =  _ProductApi.CreateProductSKU(token, id, sku).Result;
                if (!response.IsSuccessStatusCode)
                {
                    var contentResult =  response.Content.ReadAsStringAsync().Result;
                    _logger.LogError($"Criar SKU  - Produto: API retornou erro :( - {response.StatusCode}-{response.ReasonPhrase} -> {contentResult}");
                    if (((int)response.StatusCode) >= 400 && ((int)response.StatusCode) < 500)
                        return null;
                }
                _logger.LogInformation("Criar SKU - Produto: API retornou sucesso :)");

                var json =  response.Content.ReadAsStringAsync().Result;
                return  Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ProductDetail>(json)).Result;
            }
            catch (Exception)
            {
                _logger.LogError($"Criar SKU  - Produto: API retornou erro :(");
                return null;
            }
        }
        #endregion

        #endregion

        #region Read

        #region Buscar Produtos
        /// <summary>
        /// Metodo para retornar produtos completos
        /// </summary>
        /// <returns></returns>
        public List<ProductDetail> GetProductsComplete(string token)
        {
            try
            {

                _logger.LogInformation("Buscar todos produtos - Produto: Enviando requisição para a API");
                var response =  _ProductApi.GetProductsComplete(token).Result;
                if (!response.IsSuccessStatusCode)
                {
                    var contentResult =  response.Content.ReadAsStringAsync().Result;
                    _logger.LogError($"Buscar todos produtos - Produto: API retornou erro :( - {response.StatusCode}-{response.ReasonPhrase} -> {contentResult}");
                    if (((int)response.StatusCode) >= 400 && ((int)response.StatusCode) < 500)
                        return null;
                }
                _logger.LogInformation("Buscar todos produtos - Produto: API retornou sucesso :)");

                var json =  response.Content.ReadAsStringAsync().Result;
                return  Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<ProductDetail>>(json)).Result;
            }
            catch (Exception)
            {
                _logger.LogError($"Buscar todos produtos - Produto: API retornou erro :(");
                return null;
            }
        }
        #endregion

        #endregion

        #region Update

        #region Informações Basicas
        /// <summary>
        /// Alterar Produto - Informações basicas
        /// </summary>
        /// <returns></returns>
        public ProductDetail UpdateProductInformation(string token, string id, ProductInformationUpdate product)
        {
            try
            {

                _logger.LogInformation("Alterar informações basicas - Produto: Enviando requisição para a API");
                var response =  _ProductApi.UpdateProductInformation(token, id, product).Result;
                if (!response.IsSuccessStatusCode)
                {
                    var contentResult =  response.Content.ReadAsStringAsync().Result;
                    _logger.LogError($"Alterar informações basicas- Produto: API retornou erro :( - {response.StatusCode}-{response.ReasonPhrase} -> {contentResult}");
                    if (((int)response.StatusCode) >= 400 && ((int)response.StatusCode) < 500)
                        return null;
                }
                _logger.LogInformation("Alterar informações basicas - Produto: API retornou sucesso :)");

                var json =  response.Content.ReadAsStringAsync().Result;
                return  Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ProductDetail>(json)).Result;

            }
            catch (Exception)
            {
                _logger.LogError($"Alterar informações basicas- Produto: API retornou erro :( ");
                return null;
            }
        }
        #endregion

        #region Categorias
        /// <summary>
        /// Alterar Produto - Categorias
        /// </summary>
        /// <returns></returns>
        public ProductDetail UpdateProductCategories(string token, string id, List<CategoryReference> categories)
        {
            try
            {


                _logger.LogInformation("Alterar categorias - Produto: Enviando requisição para a API");
                var response =  _ProductApi.UpdateProductCategories(token, id, categories).Result;
                if (!response.IsSuccessStatusCode)
                {
                    var contentResult =  response.Content.ReadAsStringAsync().Result;
                    _logger.LogError($"Alterar categorias - Produto: API retornou erro :( - {response.StatusCode}-{response.ReasonPhrase} -> {contentResult}");
                    if (((int)response.StatusCode) >= 400 && ((int)response.StatusCode) < 500)
                        return null;
                }
                _logger.LogInformation("Alterar categorias - Produto: API retornou sucesso :)");

                var json =  response.Content.ReadAsStringAsync().Result;
                return  Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ProductDetail>(json)).Result;
            }
            catch (Exception)
            {
                _logger.LogError($"Alterar categorias - Produto: API retornou erro :(");
                return null;
            }
        }
        #endregion

        #region SEO
        /// <summary>
        /// Alterar Produto - SEO
        /// </summary>
        /// <returns></returns>
        public ProductDetail UpdateProductSEO(string token, string id, ProductSeoUpdate seo)
        {
            try
            {


                _logger.LogInformation("Alterar SEO - Produto: Enviando requisição para a API");
                var response =  _ProductApi.UpdateProductSEO(token, id, seo).Result;
                if (!response.IsSuccessStatusCode)
                {
                    var contentResult =  response.Content.ReadAsStringAsync().Result;
                    _logger.LogError($"Alterar SEO - Produto: API retornou erro :( - {response.StatusCode}-{response.ReasonPhrase} -> {contentResult}");
                    if (((int)response.StatusCode) >= 400 && ((int)response.StatusCode) < 500)
                        return null;
                }
                _logger.LogInformation("Alterar SEO - Produto: API retornou sucesso :)");

                var json =  response.Content.ReadAsStringAsync().Result;
                return  Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ProductDetail>(json)).Result;
            }
            catch (Exception)
            {
                _logger.LogError($"Alterar SEO - Produto: API retornou erro :( ");
                return null;
            }
        }
        #endregion

        #endregion

        #region SKU do Produto
        /// <summary>
        /// Alterar Produto - SKU
        /// </summary>
        /// <returns></returns>
        public ProductDetail UpdateProductSKU(string token, string id, string skuId, SkuUpdate sku)
        {
            try
            {

                _logger.LogInformation("Alterar SKU - Produto: Enviando requisição para a API");
                var response =  _ProductApi.UpdateProductSKU(token, id, skuId, sku).Result;
                if (!response.IsSuccessStatusCode)
                {
                    var contentResult =  response.Content.ReadAsStringAsync().Result;
                    _logger.LogError($"Alterar SKU - Produto: API retornou erro :( - {response.StatusCode}-{response.ReasonPhrase} -> {contentResult}");
                    if (((int)response.StatusCode) >= 400 && ((int)response.StatusCode) < 500)
                        return null;
                }
                _logger.LogInformation("Alterar SKU - Produto: API retornou sucesso :)");

                var json =  response.Content.ReadAsStringAsync().Result;
                return  Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ProductDetail>(json)).Result;

            }
            catch (Exception)
            {
                _logger.LogError($"Alterar SKU - Produto: API retornou erro :(");
                return null;
            }
        }

        /// <summary>
        /// Alterar Produto - SKU FRETE
        /// </summary>
        /// <returns></returns>
        public ProductDetail UpdateProductSKUFreight(string token, string id, string skuId, SkuUpdate sku)
        {
            try
            {

                _logger.LogInformation("Alterar SKU FRETE - Produto: Enviando requisição para a API");
                var response =  _ProductApi.UpdateProductSKUFreight(token, id, skuId, sku).Result;
                if (!response.IsSuccessStatusCode)
                {
                    var contentResult =  response.Content.ReadAsStringAsync().Result;
                    _logger.LogError($"Alterar SKU FRETE - Produto: API retornou erro :( - {response.StatusCode}-{response.ReasonPhrase} -> {contentResult}");
                    if (((int)response.StatusCode) >= 400 && ((int)response.StatusCode) < 500)
                        return null;
                }
                _logger.LogInformation("Alterar SKU FRETE - Produto: API retornou sucesso :)");

                var json =  response.Content.ReadAsStringAsync().Result;
                return  Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ProductDetail>(json)).Result;

            }
            catch (Exception)
            {
                _logger.LogError($"Alterar SKU FRETE - Produto: API retornou erro :(");
                return null;
            }
        }
        #endregion
    }
}
