using integration.romaautopecas.core.models.idealeware.brand;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace integration.romaautopecas.core.httptransfermodel.brand
{
    public interface IHttpTransferBrand
    {
        #region Create

        #region Criar Marcas
        /// <summary>
        /// Cria uma marca nova
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="brand">Objeto do tipo marca</param>
        /// <returns></returns>
        BrandDetail CreateBrand(string token, BrandCreate brand);
        #endregion

        #endregion

        #region Read
        #region Buscar Marcas
        /// <summary>
        /// Metodo para retornar marcas completos
        /// </summary>
        /// <returns></returns>
        List<BrandDetail> GetBrandComplete(string token);
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
        BrandDetail UpdateBrand(string token, BrandUpdate brand, string id);
        #endregion

        #endregion
    }
}
