using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.core.models.idealeware.brand
{
    public class BrandDetail
    {
        /// <summary>
        /// Nome
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Codigo de terceiros
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Posição
        /// </summary>
        public int? Position { get; set; }
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

        /// <summary>
        ///Imagems
        /// </summary>
        public string Picture { get; set; }
    }
}
