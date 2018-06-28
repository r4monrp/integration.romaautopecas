using integration.romaautopecas.start.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace integration.romaautopecas.start.Integration
{
    public class IntegrationStart
    {
        public IntegrationStart()
        {
            this.Run();
        }

        public async Task Run()
        {
            try
            {

                var credentials = AppSettings.GetCredentials();

                Console.WriteLine($"{DateTime.Now} - Iniciando autenticaçaõ para integração.");

                Console.WriteLine($"{DateTime.Now} - Efetuando Request para Autenticaçãoe Inicio da Integração.");

                #region Recupera o code para a api e inicia a integração

                HttpClient _client = new HttpClient();
                _client.BaseAddress = AppSettings.Apis.AicBrasilApi;
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

                var resultCode = await new HttpClientHelper(_client)
                .SetEndpoint($"oauth/authorize?response_type=code&client_id={credentials.ClientId}&client_secret={credentials.ClientSecret}&redirect_uri={AppSettings.CallbackUrl}")
                .GetAsync();

                #endregion

                Console.WriteLine($"{DateTime.Now} - Request para Autenticar e Iniciar Integração Finalizado.");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now} - Foi encontrado um problema : {ex.Message}.");
            }
        }
    }
}
