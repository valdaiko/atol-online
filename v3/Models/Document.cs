using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AtolOnline.v3
{
    public enum eSnoType
    {
        osn,
        usn_income,
        usn_income_outcome,
        envd,
        esn,
        patent
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

        [JsonProperty(PropertyName = "external_id")]
        public string  ExternalId{ get; set; }

        [JsonProperty(PropertyName = "receipt")]
        public ReceiptDocument Receipt { get; set; }

        [JsonProperty(PropertyName = "service")]
        public ServiceDocument Service {get; set;}
    }


    public class ReceiptDocument
    {
        [JsonProperty(PropertyName = "attributes")]
        public Attribute Attributes { get; set; }

        [JsonProperty(PropertyName = "items")]
        public List<DocumentProduct> Items { get; set; }

        [JsonProperty(PropertyName = "total")]
        public decimal Total { get { return Items.Sum(item => item.Price * item.Quantity); } }

        [JsonProperty(PropertyName = "payments")]
        public List<Payment> Payments { get; set; }


    }

    public class Attribute
    {
        [JsonIgnore]
        public eSnoType Sno { set; private get; }

        [JsonProperty(PropertyName = "sno")]
        public string SnoString { get { return Sno.ToString(); }}

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

    }


    public class ServiceDocument
    {
        [JsonProperty(PropertyName = "inn")]
        public string Inn { get; set; }

        [JsonProperty(PropertyName = "callback_url")]
        public string CallbackUrl { get; set; }

        [JsonProperty(PropertyName = "payment_address")]
        public string PaymentAddress { get; set; }

    }

}
