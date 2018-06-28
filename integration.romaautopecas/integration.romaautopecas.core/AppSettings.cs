using integration.romaautopecas.core.models.aicbrasil.authenticate;
using integration.romaautopecas.core.models.idealeware.authenticate;
using integration.romaautopecas.core.models.idealeware.product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace integration.romaautopecas.core
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
            /// Url da Api de Autenticação - E-commerce
            /// </summary>
            public static Uri AutenthicateApi { get { return new Uri("https://api-dev-authenticate.prd.idealeware.com.br/"); } }

            /// <summary>
            /// Url da Api de Marcas - E-commerce
            /// </summary>
            public static Uri BrandApi { get { return new Uri("https://api-dev-brand.prd.idealeware.com.br/"); } }

            /// <summary>
            /// Url da Api de Pedidos - E-commerce
            /// </summary>
            public static Uri OrderApi { get { return new Uri("https://api-dev-order.prd.idealeware.com.br/"); } }


            /// <summary>
            /// Url da Api de Produtos - E-commerce
            /// </summary>
            public static Uri ProductApi { get { return new Uri("https://api-dev-product.prd.idealeware.com.br/"); } }

            /// <summary>
            /// Url da Api de AIC Brasil - ERP
            /// </summary>
            public static Uri AicBrasilApi { get { return new Uri("https://admin.aicbrasil.com.br/"); } }
         
        }

        #endregion

        #region Login - E-commerce
        public static LoginModel GetUserIdealeware()
        {
            return new LoginModel() {Domain = "yourdomain", UserEmail = "yourduser", Password = "yourpasswd" };
        }
        #endregion

        #region Categoria Padrao - E-commerce
        public static CategoryReference GetDefaultCategory()
        {
            return new CategoryReference() {
                Id = "yourId",
                Name = "yourName"
            };
        }
        #endregion

        #region Variação Padrao - E-commerce
        public static VariationReference GetDefaultVariation()
        {
            return new VariationReference() {
                Id = "yourId",
                Name = "yourId",
                Option = new OptionReference() {
                    Id = "yourId",
                    Name = "yourName"
                }
            };
        }
        #endregion

        #region Callback URL
        /// <summary>
        /// Url que o token gerado será retornado
        /// </summary>
        public static string CallbackUrl = HttpUtility.UrlEncode("http://xxxxxxxxxxxxx/integration/getToken");
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

