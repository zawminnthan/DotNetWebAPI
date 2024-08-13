using System.Text.Json.Serialization;

namespace DotNetWebAPI.Dtos
{
    public class CddForm
    {
        [JsonPropertyName("formName")]
        public string FormName { get; set; }

        [JsonPropertyName("pdfUrl")]
        public string PdfUrl { get; set; }

        [JsonPropertyName("formData")]
        public CddFormData FormData { get; set; }
    }
}
