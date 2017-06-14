using Newtonsoft.Json;

namespace AtolOnline.v2
{

    public enum ePaymentType
    {
        type0 = 0,
        type1 = 1,
        type2 = 2,
        type3 = 3,
        type4 = 4,
        type5 = 5,
        type6 = 6,
        type7 = 7,
        type8 = 8,
        type9 = 9,
    }

    public class Payment
    {
        [JsonIgnore]
        public ePaymentType PaymentType { set; private get; }

        [JsonProperty(PropertyName = "type")]
        public int Type { get { return (int)PaymentType; }}

        [JsonProperty(PropertyName = "sum")]
        public decimal Sum { get; set; }
    }
}