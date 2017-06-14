using Newtonsoft.Json;

namespace AtolOnline.v1
{
    public class CheckPayload
    {
        [JsonProperty(PropertyName = "check_number")]
        public int CheckNumber { get; set; }

        [JsonProperty(PropertyName = "document_number")]
        public int DocumentNumber { get; set; }

        [JsonProperty(PropertyName = "ecr_registration_number")]
        public string EcrRegistrationNumber { get; set; }

        [JsonProperty(PropertyName = "fiscal_document_number")]
        public int FiscalDocumentNumber { get; set; }

        [JsonProperty(PropertyName = "fiscal_document_attribute")]
        public decimal FiscalDocumentAttribute { get; set; }
    }
}