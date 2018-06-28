using integration.romaautopecas.core.models.idealeware.authenticate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace integration.romaautopecas.core.httptransfermodel.authenticate
{
    public interface IHttpTransferAuthenticate
    {
        #region Login
        /// <summary>
        /// Metodo para efetuar autenticação na API
        /// </summary>
        /// <param name="login">Objeto do login</param>
        /// <returns></returns>
        TokenModel Login(LoginModel login);
        #endregion
    }
}
