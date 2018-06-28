using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace integration.romaautopecas.core.helpers
{
    public class HttpClientHelper
    {
        private HttpClient _client;
        private StringContent _content;
        private Encoding _encoding;
        private string _mediaType;
        private string _endPoint;

        #region Constructors
        public HttpClientHelper(HttpClient client)
        {
            _client = client;
            _encoding = Encoding.UTF8;
            _mediaType = "application/json";
        }

        public HttpClientHelper(HttpClient client, Encoding encoding)
        {
            _client = client;
            _encoding = encoding;
            _mediaType = "application/json";
        }

        public HttpClientHelper(HttpClient client, Encoding encoding, string mediaType)
        {
            _client = client;
            _encoding = encoding;
            _mediaType = mediaType;
        }
        #endregion

        /// <summary>
        /// Serializa o objeto em um JSON
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public string Serialize(object o)
        {
         var content = JsonConvert.SerializeObject(o);
         return content;
        }
            

        /// <summary>
        /// Converte o conteudo a ser enviado
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public HttpClientHelper WithContent(object o)
        {
            _content = new StringContent(Serialize(o), _encoding, _mediaType);
            return this;
        }

        /// <summary>
        /// Converte o conteúdo a ser enviado
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public HttpClientHelper WithContentSerialized(object o)
        {
            _content = new StringContent(Serialize(o), _encoding, _mediaType);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public HttpClientHelper SetEndpoint(string endpoint)
        {
            _endPoint = endpoint;
            return this;
        }

        /// <summary>
        /// Adiciona cabeçalhos à requisição
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public HttpClientHelper AddHeader(string name, string value)
        {
            _client.DefaultRequestHeaders.Add(name, value);
            return this;
        }

        /// <summary>
        /// Metodo Get
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetAsync()
            => await _client.GetAsync(_endPoint);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> PostAsync()
            => await _client.PostAsync(_endPoint, _content);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> PutAsync()
            => await _client.PutAsync(_endPoint, _content);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> DeleteAsync()
            => await _client.DeleteAsync(_endPoint);
    }
}
