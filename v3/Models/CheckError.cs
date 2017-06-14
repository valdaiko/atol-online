using Newtonsoft.Json;

namespace AtolOnline.v3
{
    public class CheckError
    {
        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}