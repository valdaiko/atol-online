using Newtonsoft.Json;
using System;
using System.Globalization;


namespace AtolOnline.v2
{
    public class DocumentResponse
    {
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }

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

    }
}
