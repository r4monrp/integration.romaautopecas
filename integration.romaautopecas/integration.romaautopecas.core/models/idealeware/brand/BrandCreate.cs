using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.core.models.idealeware.brand
{
    public class BrandCreate
    {
        /// <summary>
        /// Nome
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Codigo de terceiros
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Posição
        /// </summary>
        public int Position { get; set; }
        /// <summary>
        /// Tag do titulo
        /// </summary>
        public string MetaTagTitle { get; set; }
        /// <summary>
        /// Tag da descrição
        /// </summary>
        public string MetaTagDescription { get; set; }
        /// <summary>
        /// status
        /// </summary>
        public bool Status { get; set; }
    }
}
