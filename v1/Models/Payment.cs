using Newtonsoft.Json;

namespace AtolOnline.v1
{
    public class Payment
    {
        [JsonProperty(PropertyName = "type")]
        public int Type { get; set; }

        [JsonProperty(PropertyName = "value")]
        public decimal Value { get; set; }
    }
}