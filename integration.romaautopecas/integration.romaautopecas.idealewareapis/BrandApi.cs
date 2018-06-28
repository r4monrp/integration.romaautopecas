using integration.romaautopecas.core;
using integration.romaautopecas.core.helpers;
using integration.romaautopecas.core.models.idealeware.brand;
using integration.romaautopecas.core.providers.idealeware;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace integration.romaautopecas.idealewareapis
{
    public class BrandApi : IBrandApi
    {
        #region Objects
        private HttpClient _client = new HttpClient();
        #endregion

        #region Constructor
        public BrandApi()
        {
            _client.BaseAddress = AppSettings.Apis.BrandApi;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion

        #region Create

        #region Criar Marcas
        /// <summary>
        /// Cria uma marca nova
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="brand">Objeto do tipo marca</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CreateBrand(string token, BrandCreate brand)
        {
            _client = new HttpClient();
            _client.BaseAddress = AppSettings.Apis.BrandApi;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await new HttpClientHelper(_client)
              .SetEndpoint("brands")
              .AddHeader("Authorization", $"Bearer {token}")
              .WithContentSerialized(brand)
              .PostAsync();
        }
        #endregion

        #endregion

        #region Read
        #region Buscar Marcas
        /// <summary>
        /// Metodo para retornar marcas completos
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetBrandComplete(string token)
        {
            _client = new HttpClient();
            _client.BaseAddress = AppSettings.Apis.BrandApi;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await new HttpClientHelper(_client)
            .SetEndpoint("brands")
            .AddHeader("Authorization", $"Bearer {token}")
            .GetAsync();
        }
        #endregion

        #endregion

        #region Update

        #region Atualiza uma marca

        /// <summary>
        /// Atualiza uma marca
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="brand">objeto do tipo marca</param>
        /// <param name="id">id da marca</param>
        /// <returns></returns>ret  
        public async Task<HttpResponseMessage> UpdateBrand(string token, BrandUpdate brand, string id)
        {
            _client = new HttpClient();
            _client.BaseAddress = AppSettings.Apis.BrandApi;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await new HttpClientHelper(_client)
         .SetEndpoint($"brands/{id}")
         .AddHeader("Authorization", $"Bearer {token}")
         .WithContentSerialized(brand)
         .PutAsync();
        }
        #endregion

        #endregion
    }
}
