using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace integration.romaautopecas.start.Util
{
    public static class AppSettings
    {
        #region Apis
        /// <summary>
        /// Contém todas as Urls das Apis
        /// </summary>
        public static class Apis
        { 

            /// <summary>
            /// Url da Api de AIC Brasil - ERP
            /// </summary>
            public static Uri AicBrasilApi { get { return new Uri("http://admin.aicbrasil.com.br/"); } }

            /// <summary>
            /// Url da Api de Integração
            /// </summary>
            public static Uri IntegrationApi { get { return new Uri("http://xxxxxxx:5000/"); } }

        }
        #endregion

        #region Callback URL
        /// <summary>
        /// Url que o token gerado será retornado
        /// </summary>
        public static string CallbackUrl = HttpUtility.UrlEncode("http://xxxxxxxx:5000/integration/getToken");
        #endregion

        #region Login - ERP
        /// <summary>
        /// Objeto com as credenciais para geração do token
        /// </summary>
        /// <returns></returns>
        public static LoginModelAicBrasil GetCredentials()
        {
            return new LoginModelAicBrasil()
            {

                TokenName = "yourToken",
                ClientSecret = "yourSecret",
                ClientId = "yourID"
            };
        }
        #endregion

    }
}
