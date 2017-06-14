using Newtonsoft.Json;
using System;
using System.Globalization;

namespace AtolOnline.v3
{
    public class CheckPayload
    {
        [JsonProperty(PropertyName = "total")]
        public decimal Total { get; set; }

        [JsonProperty(PropertyName = "fn_number")]
        public string FnNumber { get; set; }

        [JsonProperty(PropertyName = "shift_number")]
        public int ShiftNumber { get; set; }

        [JsonProperty(PropertyName = "receipt_datetime")]
        public string ReceiptDateTime { private get; set; }

        [JsonIgnore]
        public DateTime Date
        {
            get
            {
                DateTime date;
                DateTime.TryParseExact(ReceiptDateTime, Consts.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
                return date;
            }
        }

        [JsonProperty(PropertyName = "fiscal_receipt_number")]
        public int FiscalReceiptNumber { get; set; }

        [JsonProperty(PropertyName = "fiscal_document_number")]
        public int FiscalDocumentNumber { get; set; }

        [JsonProperty(PropertyName = "ecr_registration_number")]
        public string EcrRegistrationNumber { get; set; }

        [JsonProperty(PropertyName = "fiscal_document_attribute")]
        public decimal FiscalDocumentAttribute { get; set; }
    }
}