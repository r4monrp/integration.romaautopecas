using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.core.models.idealeware.product
{
    public class ProductInformationCreate
    {
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
        /// Status do Produto 
        /// </summary>
        public bool Status { get; set; }
    }
}
