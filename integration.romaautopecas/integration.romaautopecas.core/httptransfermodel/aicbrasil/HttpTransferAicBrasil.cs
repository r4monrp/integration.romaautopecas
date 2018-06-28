using System;
using integration.romaautopecas.core.models.aicbrasil.authenticate;
using integration.romaautopecas.core.models.aicbrasil.order;
using integration.romaautopecas.core.models.aicbrasil.product;
using integration.romaautopecas.core.providers.aicbrasil;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using integration.romaautopecas.core.models.aicbrasil.customer;
using integration.romaautopecas.core.models.aicbrasil.count;
using System.IO;
using System.Net;
using System.Linq;

namespace integration.romaautopecas.core.httptransfermodel.aicbrasil.product
{
    public class HttpTransferProductAicBrasil : IHttpTransferAicBrasil
    {
        #region Objetos
        private readonly IAicBrasilApi _aicBrasilApi;
        private readonly ILogger _logger;
        #endregion

        #region Construtor
        public HttpTransferProductAicBrasil(IAicBrasilApi aicBrasilApi, ILoggerFactory logger)
        {
            this._aicBrasilApi = aicBrasilApi;
            this._logger = logger.CreateLogger("HttpTransferProductAicBrasil");
            _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} - HttpTransferProductAicBrasil em execução.");
        }
        #endregion

        #region Autenticação
        /// <summary>
        /// Faz autenticação conforme code
        /// </summary>
        /// <returns></returns>
        public AicTokenModel AicAuthenticate(string code)
        {
            try
            {
                _logger.LogInformation("Criar autenticação AicBrasil: Enviando requisição para a API");
                var response =  _aicBrasilApi.AicAuthenticate(code).Result;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    _logger.LogError($"Criar autenticação AicBrasil: API retornou erro :( - {response.StatusCode}-{response.StatusDescription} ");
                    if (((int)response.StatusCode) >= 400 && ((int)response.StatusCode) < 500)
                        return null;
                }
                _logger.LogInformation("Criar autenticação AicBrasil: API retornou sucesso :)");

                var resultToken = string.Empty;

                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        var streamReader = new StreamReader(responseStream);
                        resultToken = streamReader.ReadToEnd();
                        streamReader.Close();
                    }
                }

                var token = JsonConvert.DeserializeObject<AicTokenModel>(resultToken);
                return token;
            }
            catch (Exception)
            {

                _logger.LogError($"Criar autenticação AicBrasil: API retornou erro :( ");
                return null;

            }
        }
        #endregion

        #region Produto
        /// <summary>
        /// Busca os produtos para serem integrados
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="initDate">data inicial</param>
        /// <param name="maxDate">data final</param>
        /// <returns></returns>
        public List<ProductDetailAicBrasil> GetCreateProductsAsync(string token, DateTime? initDate = null,
            DateTime? maxDate = null, int? page = null, int? limit = null)
        {
            try
            {
                _logger.LogInformation("Buscar todos produtos criados AicBrasil: Enviando requisição para a API");
                var response =  _aicBrasilApi.GetCreateProductsAsync(token, initDate, maxDate, page, limit).Result;
                if (!response.IsSuccessStatusCode)
                {
                    var contentResult = response.Content.ReadAsStringAsync().Result;
                    _logger.LogError($"Buscar todos produtos criados AicBrasil: API retornou erro :( - {response.StatusCode}-{response.ReasonPhrase} -> {contentResult}");
                    if (((int)response.StatusCode) >= 400 && ((int)response.StatusCode) < 500)
                        return null;
                }
                _logger.LogInformation("Buscar todos produtos criados AicBrasil: API retornou sucesso :)");

                var json =  response.Content.ReadAsStringAsync().Result;
                var result = Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ProductReturnAicBrasil>(json)).Result;
                return result.Parts;
            }
            catch (Exception)
            {

                _logger.LogError($"Buscar todos produtos criados AicBrasil: API retornou erro :( -");
                return null;

            }
        }

        /// <summary>
        /// Busca os produtos para serem integrados
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="initDate">data inicial</param>
        /// <param name="maxDate">data final</param>
        /// <returns></returns>
        public List<ProductDetailAicBrasil> GetUpdateProductsAsync(string token, DateTime? initDate = null,
            DateTime? maxDate = null, int? page = null, int? limit = null)
        {
            try
            {
                _logger.LogInformation("Buscar todos produtos alterados AicBrasil: Enviando requisição para a API");
                var response =  _aicBrasilApi.GetUpdateProductsAsync(token, initDate, maxDate, page, limit).Result;
                if (!response.IsSuccessStatusCode)
                {
                    var contentResult = response.Content.ReadAsStringAsync().Result;
                    _logger.LogError($"Buscar todos produtos alterados AicBrasil: API retornou erro :( - {response.StatusCode}-{response.ReasonPhrase} -> {contentResult}");
                    if (((int)response.StatusCode) >= 400 && ((int)response.StatusCode) < 500)
                        return null;
                }
                _logger.LogInformation("Buscar todos produtos alterados AicBrasil: API retornou sucesso :)");

                var json = response.Content.ReadAsStringAsync().Result;
                var result = Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ProductReturnAicBrasil>(json)).Result;
                return result.Parts;
            }
            catch (Exception)
            {

                _logger.LogError($"Buscar todos produtos alterados AicBrasil: API retornou erro :( -");
                return null;

            }
        }

        /// <summary>
        /// Busca a quantidade de produtos para serem integrados
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public  CountModel GetCountCreateProductsAsync(string token, DateTime? initDate = null,
            DateTime? maxDate = null, int? page = null, int? limit = null)
        {
            try
            {


                _logger.LogInformation("Buscar a quantidade de produtos criados AicBrasil: Enviando requisição para a API");
                var response =  _aicBrasilApi.GetCountCreateProductsAsync(token, initDate, maxDate).Result;
                if (!response.IsSuccessStatusCode)
                {
                    var contentResult =  response.Content.ReadAsStringAsync().Result;
                    _logger.LogError($"Buscar a quantidade de produtos criados AicBrasil: API retornou erro :( - {response.StatusCode}-{response.ReasonPhrase} -> {contentResult}");
                    if (((int)response.StatusCode) >= 400 && ((int)response.StatusCode) < 500)
                        return new CountModel() { Count = 0 };
                }
                _logger.LogInformation("Buscar a quantidade de produtos criados AicBrasil: API retornou sucesso :)");

                var json =  response.Content.ReadAsStringAsync().Result;
                return  Task.Factory.StartNew(() => JsonConvert.DeserializeObject<CountModel>(json)).Result;
            }
            catch (Exception)
            {

                _logger.LogError($"Buscar a quantidade de produtos criados AicBrasil: API retornou erro :(");
                return null;
            }
        }

        /// <summary>
        /// Busca a quantidade de produtos para serem integrados
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public  CountModel GetCountUpdateProductsAsync(string token, DateTime? initDate = null,
            DateTime? maxDate = null, int? page = null, int? limit = null)
        {
            try
            {


                _logger.LogInformation("Buscar a quantidade de produtos alterados AicBrasil: Enviando requisição para a API");
                var response =  _aicBrasilApi.GetCountUpdateProductsAsync(token, initDate, maxDate).Result;
                if (!response.IsSuccessStatusCode)
                {
                    var contentResult =  response.Content.ReadAsStringAsync().Result;
                    _logger.LogError($"Buscar a quantidade de produtos alterados AicBrasil: API retornou erro :( - {response.StatusCode}-{response.ReasonPhrase} -> {contentResult}");
                    if (((int)response.StatusCode) >= 400 && ((int)response.StatusCode) < 500)
                        return new CountModel() { Count = 0 };
                }
                _logger.LogInformation("Buscar a quantidade de produtos alterados AicBrasil: API retornou sucesso :)");

                var json =  response.Content.ReadAsStringAsync().Result;
                return  Task.Factory.StartNew(() => JsonConvert.DeserializeObject<CountModel>(json)).Result;
            }
            catch (Exception)
            {

                _logger.LogError($"Buscar a quantidade de produtos  alterados AicBrasil: API retornou erro :(");
                return null;
            }
        }
        #endregion

        #region Pedido
        /// <summary>
        /// Insere o Pedido no ERP
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="order">Pedido</param>
        /// <returns></returns>
        public AicOrderReturnModel InsertOrderAsync(string token, AicOrderInsertModel order)
        {
            try
            {
                _logger.LogInformation("Inserir Pedido AIC: Enviando requisição para a API");
                var response =  _aicBrasilApi.InsertOrderAsync(token, order).Result;
                if (!response.IsSuccessStatusCode)
                {
                    var contentResult =  response.Content.ReadAsStringAsync().Result;
                    _logger.LogError($"Inserir Pedido AIC: API retornou erro :( - {response.StatusCode}-{response.ReasonPhrase} -> {contentResult}");
                    if (((int)response.StatusCode) >= 400 && ((int)response.StatusCode) < 500)
                        return null;
                }
                _logger.LogInformation("inserir Pedido AIC: API retornou sucesso :)");

                var json =  response.Content.ReadAsStringAsync().Result;
                return  Task.Factory.StartNew(() => JsonConvert.DeserializeObject<AicOrderReturnModel>(json)).Result;
            }
            catch (Exception)
            {
                _logger.LogError($"Inserir Pedido AIC: API retornou erro :(");
                return null;
            }
        }
        #endregion

        #region Clientes
        /// <summary>
        /// Insere cliente no ERP
        /// </summary>
        /// <param name="token"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        public CustomerReturnAicBrasil InsertCustomerAsync(string token, CustomerInsertAicBrasil customer)
        {
            try
            {


                _logger.LogInformation("Insere cliente na base AicBrasil: Enviando requisição para a API");
                var response =  _aicBrasilApi.InsertCustomerAsync(token, customer).Result;
                if (!response.IsSuccessStatusCode)
                {
                    var contentResult =  response.Content.ReadAsStringAsync().Result;
                    _logger.LogError($"Insere cliente na base AicBrasil: API retornou erro :( - {response.StatusCode}-{response.ReasonPhrase} -> {contentResult}");
                    if (((int)response.StatusCode) >= 400 && ((int)response.StatusCode) < 500)
                        return null;
                }
                _logger.LogInformation("Insere cliente na base AicBrasil: API retornou sucesso :)");

                var json =  response.Content.ReadAsStringAsync().Result;
                return  Task.Factory.StartNew(() => JsonConvert.DeserializeObject<CustomerReturnAicBrasil>(json)).Result;
            }
            catch (Exception)
            {
                _logger.LogError($"Insere cliente na base AicBrasil: API retornou erro :(");
                return null;
            }
        }

        /// <summary>
        /// Busca um cliente por cpf
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="cpf">cpf</param>
        /// <returns></returns>
        public CustomerResponseAicBrasil GetCustomersByCpfAsync(string token, string cpf)
        {
            try
            {
                cpf = cpf.Replace(".", "").Replace("-", "").Replace("_", "").Trim();

                _logger.LogInformation("Busca um cliente por CPF AicBrasil: Enviando requisição para a API");
                var response =  _aicBrasilApi.GetCustomersByCpfAsync(token, cpf).Result;
                if (!response.IsSuccessStatusCode)
                {
                    var contentResult =  response.Content.ReadAsStringAsync().Result;
                    _logger.LogError($"Busca um cliente por CPF AicBrasil: API retornou erro :( - {response.StatusCode}-{response.ReasonPhrase} -> {contentResult}");
                    if (((int)response.StatusCode) >= 400 && ((int)response.StatusCode) < 500)
                        return null;
                }
                _logger.LogInformation("Busca um cliente por CPF AicBrasil: API retornou sucesso :)");

                var json =  response.Content.ReadAsStringAsync().Result;
                return  Task.Factory.StartNew(() => JsonConvert.DeserializeObject<CustomerResponseAicBrasil>(json)).Result;
            }
            catch (Exception)
            {
                _logger.LogError($"Busca um cliente por CPF AicBrasil: API retornou erro :( ");
                return null;
            }
        }
        #endregion
    }
}
