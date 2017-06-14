using Newtonsoft.Json;

namespace AtolOnline.v3
{

    public class TokenDocument
    {
        [JsonProperty(PropertyName = "code")]
        public int Code { get; set;  }

        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}