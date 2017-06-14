using Newtonsoft.Json;
using System;
using System.Globalization;


namespace AtolOnline.v1
{
    public enum Status
    {
        [JsonProperty(PropertyName = "wait")]
        Wait,

        [JsonProperty(PropertyName = "done")]
        Done,

        [JsonProperty(PropertyName = "fail")]
        Fail
    }

    public class CheckResponse
    {
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }


        [JsonProperty(PropertyName = "inn")]
        public string Inn { get; set; }


        [JsonProperty(PropertyName = "timestamp")]
        public string Timestamp { private get; set; }

        [JsonIgnore]
        public DateTime Date
        {
            get
            {

                DateTime date;
                DateTime.TryParseExact(Timestamp, Consts.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
                return date;
            }
        }

        [JsonProperty(PropertyName = "callback_url")]
        public string CallbackUrl { get; set; }

        [JsonProperty(PropertyName = "status")]
        public Status Status { get; set; }

        [JsonProperty(PropertyName = "error")]
        public CheckError Error { get; set; }

        [JsonProperty(PropertyName = "payload")]
        public CheckPayload Payload { get; set; }
       

    }
}
