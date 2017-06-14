using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace AtolOnline.v1
{
    public enum DiscountType
    {
        Precent,
        Fixed
    }

    public class Document
    {
        [JsonIgnore]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public string Timestamp
        {
            get
            {
                return Date.ToString(Consts.DateFormat, CultureInfo.InvariantCulture); 
            }
        }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }


        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }


        [JsonIgnore]
        public DiscountType DiscountType { get; set; }

        [JsonProperty(PropertyName = "discount_type_on_check")]
        public int DiscountTypeOnCheck { get { return (int)DiscountType; } }


        [JsonProperty(PropertyName = "discount_on_check")]
        public decimal Discount { get; set; }


        [JsonProperty(PropertyName = "items")]
        public List<DocumentProduct> Items { get; set; }


        [JsonProperty(PropertyName = "payments")]
        public List<Payment> Payments { get; set; }


        [JsonProperty(PropertyName = "callback_url")]
        public string CallbackUrl { get; set; }

    }
}
