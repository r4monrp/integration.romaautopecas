using integration.romaautopecas.core.managers;
using integration.romaautopecas.core.models.idealeware.authenticate;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace integration.romaautopecas.Controllers
{
    /// <summary>
    /// Controle de Integração
    /// </summary>
    [Route("integration")]
    public class IntegrationController : Controller
    {
        #region Objects
        /// <summary>
        /// 
        /// </summary>
        private readonly IIntegrationManager IntegrationManager;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="integrationManager"></param>
        public IntegrationController(IIntegrationManager integrationManager)
        {
            IntegrationManager = integrationManager;
        }
        #endregion

        #region GetToken/Integration
        /// <summary>
        /// Recupera o code para autenticação e inicia a integração
        /// </summary>
        /// <returns></returns>
        [HttpGet("getToken")]
        [SwaggerResponse((int)HttpStatusCode.OK, null, "Recebido com sucesso")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, null, "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, null, "Erro na API")]
        public IActionResult GetToken(string code)
        {
            IntegrationManager.RunIntegrationAuthenticateERP(code);
            return Ok();
        }

        #endregion
    }
}
