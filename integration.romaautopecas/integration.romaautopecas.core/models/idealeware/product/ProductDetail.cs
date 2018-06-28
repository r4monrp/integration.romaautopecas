using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.core.models.idealeware.product
{
    /// <summary>
    /// Produto Completo
    /// </summary>
    public class ProductDetail
    {
        /// <summary>
        /// Id 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SkuId { get; set; }

        /// <summary>
        /// Nome 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descrição 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Descrição Resumida
        /// </summary>
        public string BriefDescription { get; set; }

        /// <summary>
        /// Marca 
        /// </summary>
        public BrandReference Brand { get; set; }

        /// <summary>
        /// Máximo de parcelas 
        /// </summary>
        public int InstallmentLimit { get; set; }

        /// <summary>
        /// Vídeos
        /// </summary>
        public string VideoUrl { get; set; }

        /// <summary>
        /// Demensionador
        /// </summary>
        public int AreaSizer { get; set; }

        /// <summary>
        /// Percetual de perda
        /// </summary>
        public int LossPercentage { get; set; }

        /// <summary>
        /// Adicional de frete
        /// </summary>
        public decimal AdditionalFreightPrice { get; set; }

        /// <summary>
        /// Dias de processamento
        /// </summary>
        public int DaysProcessing { get; set; }

        /// <summary>
        /// Manual
        /// </summary>
        public string FileGuide { get; set; }

        /// <summary>
        /// T´tulo da página
        /// </summary>
        public string MetaTagTitle { get; set; }

        /// <summary>
        /// Descrição da página
        /// </summary>
        public string MetaTagDescription { get; set; }

        /// <summary>
        /// Sku Base
        /// </summary>
        public SkuBaseDetail SkuBase { get; set; }

        /// <summary>
        /// Skus
        /// </summary>
        public List<SkuDetail> Skus { get; set; }

        /// <summary>
        /// Categoria Principal
        /// </summary>
        public CategoryReference BaseCategory { get; set; }
        /// <summary>
        /// Categorias
        /// </summary>
        public List<CategoryReference> Categories { get; set; }

        /// <summary>
        /// Status do Produto 
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Data de criação
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Url do produto - SKU Padrão
        /// </summary>
        public string ProductUrl { get; set; }

        /// <summary>
        /// NCM
        /// </summary>
        public string Ncm { get; set; }
    }
}
