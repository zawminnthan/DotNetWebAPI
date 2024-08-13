using System.Text.Json.Serialization;

namespace DotNetWebAPI.Dtos
{
    public class CddFormData
    {
        [JsonPropertyName("fullName")]
        public string FullName { get; set; }

        [JsonPropertyName("idNumber")]
        public string IdNumber { get; set; }

        [JsonPropertyName("idType")]
        public string IdType { get; set; }

        [JsonPropertyName("idExpiryDate")]
        public string IdExpiryDate { get; set; }

        [JsonPropertyName("dob")]
        public string Dob { get; set; }

        [JsonPropertyName("birthPlace")]
        public string BirthPlace { get; set; }

        [JsonPropertyName("residenceAddress")]
        public string ResidenceAddress { get; set; }

        [JsonPropertyName("nationality")]
        public string Nationality { get; set; }

        [JsonPropertyName("occupation")]
        public string Occupation { get; set; }

        [JsonPropertyName("contactNumbers")]
        public List<string> ContactNumbers { get; set; }

        [JsonPropertyName("purchasePurpose")]
        public string PurchasePurpose { get; set; }

        [JsonPropertyName("isTruePurchaser")]
        public string IsTruePurchaser { get; set; }

        [JsonPropertyName("isPEP")]
        public string IsPEP { get; set; }

        [JsonPropertyName("isFamilyOfPEP")]
        public string IsFamilyOfPEP { get; set; }

        [JsonPropertyName("isAssociateOfPEP")]
        public string IsAssociateOfPEP { get; set; }

        [JsonPropertyName("isq13To15Response")]
        public string Isq13To15Response { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }
    }
}
