using Newtonsoft.Json;

namespace AtolOnline.v3
{
    public enum eTaxType
    {
        none,
        vat0,
        vat10,
        vat18,
        vat110,
        vat118
    }

    public class DocumentProduct
    {
        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "sum")]
        public decimal Sum { get { return Price * Quantity; } }

        [JsonProperty(PropertyName = "quantity")]
        public decimal Quantity { get; set; }

        [JsonIgnore]
        public eTaxType Tax { private get; set; }

        [JsonProperty(PropertyName = "tax")]
        public string TaxString { get { return Tax.ToString(); }}

    }
}