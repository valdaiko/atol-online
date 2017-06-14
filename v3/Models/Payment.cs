using Newtonsoft.Json;

namespace AtolOnline.v3
{

    public enum ePaymentType
    {
        None = 0,
        Cach = 1,
        Prepaid = 2,
        Credit = 3,
        Counteroffer = 4,
        OtherType5 = 5,
        OtherType6 = 6,
        OtherType7 = 7,
        OtherType8 = 8,
        OtherType9 = 9,
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