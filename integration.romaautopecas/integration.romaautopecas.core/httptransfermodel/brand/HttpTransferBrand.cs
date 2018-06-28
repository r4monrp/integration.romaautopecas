using integration.romaautopecas.core.models.idealeware.brand;
using integration.romaautopecas.core.providers.idealeware;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace integration.romaautopecas.core.httptransfermodel.brand
{
    public class HttpTransferBrand : IHttpTransferBrand
    {

        #region Objetos
        private readonly IBrandApi _brandApi;
        private readonly ILogger _logger;
        #endregion

        #region Construtor
        public HttpTransferBrand(IBrandApi brandApi, ILoggerFactory logger)
        {
            this._brandApi = brandApi;
            this._logger = logger.CreateLogger("HttpTransferBrand");
            _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} - HttpTransferBrand em execução.");
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
        public  BrandDetail CreateBrand(string token, BrandCreate brand)
        {
            try
            {

                _logger.LogInformation("Criar uma marcar nova: Enviando requisição para a API");
                var response =  _brandApi.CreateBrand(token, brand).Result;
                if (!response.IsSuccessStatusCode)
                {
                    var contentResult =  response.Content.ReadAsStringAsync().Result;
                    _logger.LogError($"Criar uma marcar nova: API retornou erro :( - {response.StatusCode}-{response.ReasonPhrase} -> {contentResult}");
                    if (((int)response.StatusCode) >= 400 && ((int)response.StatusCode) < 500)
                        return null;
                }
                _logger.LogInformation("Criar uma marcar nova: API retornou sucesso :)");

                var json =  response.Content.ReadAsStringAsync().Result;
                return  Task.Factory.StartNew(() => JsonConvert.DeserializeObject<BrandDetail>(json)).Result;
            }
            catch (Exception)
            {
                _logger.LogError($"Criar uma marcar nova: API retornou erro :( ");
                return null;
            }
        }
        #endregion

        #endregion

        #region Read
        #region Buscar Marcas
        /// <summary>
        /// Metodo para retornar marcas completos
        /// </summary>
        /// <returns></returns>
        public List<BrandDetail> GetBrandComplete(string token)
        {
            try
            {

            _logger.LogInformation("Busca todas as marcas: Enviando requisição para a API");
            var response =  _brandApi.GetBrandComplete(token).Result;
            if (!response.IsSuccessStatusCode)
            {
                var contentResult =  response.Content.ReadAsStringAsync().Result;
                _logger.LogError($"Busca todas as marcas: API retornou erro :( - {response.StatusCode}-{response.ReasonPhrase} -> {contentResult}");
                if (((int)response.StatusCode) >= 400 && ((int)response.StatusCode) < 500)
                    return null;
            }
            _logger.LogInformation("Busca todas as marcas: API retornou sucesso :)");

            var json =  response.Content.ReadAsStringAsync().Result;
            return  Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<BrandDetail>>(json)).Result;

            }
            catch (Exception)
            {
                _logger.LogError($"Busca todas as marcas: API retornou erro :( ");
                return null;
            }
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
        /// <returns></returns>
        public BrandDetail UpdateBrand(string token, BrandUpdate brand, string id)
        {
            try
            {

            _logger.LogInformation("Altera uma marca: Enviando requisição para a API");
            var response =  _brandApi.UpdateBrand(token, brand, id).Result;
            if (!response.IsSuccessStatusCode)
            {
                var contentResult =  response.Content.ReadAsStringAsync();
                _logger.LogError($"Altera uma marca: API retornou erro :( - {response.StatusCode}-{response.ReasonPhrase} -> {contentResult}");
                if (((int)response.StatusCode) >= 400 && ((int)response.StatusCode) < 500)
                    return null;
            }
            _logger.LogInformation("Altera uma marca: API retornou sucesso :)");

            var json =  response.Content.ReadAsStringAsync().Result;
            return  Task.Factory.StartNew(() => JsonConvert.DeserializeObject<BrandDetail>(json)).Result;

            }
            catch (Exception)
            {
                _logger.LogError($"Altera uma marca: API retornou erro :(");
                return null;
            }
        }
        #endregion

        #endregion
    }
}
