using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.core.models.idealeware.product
{
    public class SkuCreate
    {
        /// <summary>
        /// Código
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Ean
        /// </summary>
        public string Ean { get; set; }

        /// <summary>
        /// Estoque
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Preço
        /// </summary>
        public decimal Price { get; set; }


        /// <summary>
        /// Variações e opções
        /// </summary>
        public List<VariationReference> Variations { get; set; }

        /// <summary>
        /// Altura
        /// </summary>
        public float? Height { get; set; }

        /// <summary>
        /// Largura
        /// </summary>
        public float? Width { get; set; }

        /// <summary>
        /// Comprimento
        /// </summary>
        public float? Length { get; set; }

        /// <summary>
        /// Peso
        /// </summary>
        public float? Weight { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Indisponível
        /// </summary>
        public bool? Available { get; set; }

        /// <summary>
        /// Envio de email automatico
        /// </summary>
        public bool AwaitedProductNotification { get; set; }
    }
}
