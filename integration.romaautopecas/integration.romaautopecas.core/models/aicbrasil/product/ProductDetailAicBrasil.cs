using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace integration.romaautopecas.core.models.aicbrasil.product
{
    public class ProductDetailAicBrasil
    {
        /// <summary>
        /// Código
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("model")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("detran_code")]
        public string DetranCode { get; set; }

        /// <summary>
        /// Preço
        /// </summary>
        [JsonProperty("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Preço
        /// </summary>
        [JsonProperty("minimum_price")]
        public decimal MinimumPrice { get; set; }

        /// <summary>
        /// Altura
        /// </summary>
        [JsonProperty("height")]
        public float? Height { get; set; }

        /// <summary>
        /// Largura
        /// </summary>
        [JsonProperty("width")]
        public float? Width { get; set; }

        /// <summary>
        /// Comprimento
        /// </summary>
        [JsonProperty("length")]
        public float? Length { get; set; }

        /// <summary>
        /// Peso
        /// </summary>
        [JsonProperty("weight")]
        public float? Weight { get; set; }

        /// <summary>
        /// Testado
        /// </summary>
        [JsonProperty("tested")]
        public bool? Tested { get; set; }

        /// <summary>
        /// Daata criação
        /// </summary>
        [JsonProperty("created_on_utc")]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Útima data de alteração
        /// </summary>
        [JsonProperty("updated_on_utc")]
        public DateTime AlterDate { get; set; }

        /// <summary>
        /// Código do veiculo
        /// </summary>
        [JsonProperty("vehicle_code")]
        public string VehicleCode { get; set; }

        /// <summary>
        /// Código da Marca
        /// </summary>
        [JsonProperty("vehicle_manufacturer_code")]
        public string BrandCode { get; set; }

        /// <summary>
        /// Nome da Marca
        /// </summary>
        [JsonProperty("vehicle_manufacturer")]
        public string BrandName { get; set; }

        /// <summary>
        /// Código do modelo veiculo
        /// </summary>
        [JsonProperty("vehicle_model_code")]
        public string VehicleModelCode { get; set; }

        /// <summary>
        /// Modelo do veiculo
        /// </summary>
        [JsonProperty("vehicle_model")]
        public string VehicleModel { get; set; }

        /// <summary>
        /// Código do ano do veiculo
        /// </summary>
        [JsonProperty("vehicle_year_code")]
        public string VehicleYearCode { get; set; }

        /// <summary>
        /// ano do veiculo
        /// </summary>
        [JsonProperty("vehicle_year")]
        public string VehicleYear { get; set; }

        /// <summary>
        /// Tipo de peça
        /// </summary>
        [JsonProperty("part_type_name")]
        public string PartTypeName { get; set; }


    }
}
