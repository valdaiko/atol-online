using Newtonsoft.Json;

namespace AtolOnline.v1
{
    public class DocumentProduct
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "barcode")]
        public string Barcode { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public decimal Quantity { get; set; }

        [JsonIgnore]
        public DiscountType DiscountType { get; set; }

        [JsonProperty(PropertyName = "discount_type")]
        public int DiscountTypeOnProduct { get { return (int)DiscountType; } }

        [JsonProperty(PropertyName = "discount")]
        public decimal Discount { get; set; }

        [JsonProperty(PropertyName = "VAT")]
        public int VAT { get; set; }

        [JsonProperty(PropertyName = "classifier")]
        public string Classifier { get; set; }

    }
}