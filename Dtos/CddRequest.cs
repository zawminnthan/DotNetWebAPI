using System.Text.Json.Serialization;

namespace DotNetWebAPI.Dtos
{
    public class CddRequest
    {
        [JsonPropertyName("userId")]
        public string UserId { get; set; }

        [JsonPropertyName("sysUserId")]
        public string SysUserId { get; set; }

        [JsonPropertyName("displayUsername")]
        public string DisplayUsername { get; set; }

        [JsonPropertyName("projectEntityName")]
        public string ProjectEntityName { get; set; }

        [JsonPropertyName("projectEntityUEN")]
        public string ProjectEntityUEN { get; set; }

        [JsonPropertyName("projectName")]
        public string ProjectName { get; set; }

        [JsonPropertyName("cddForm")]
        public List<CddForm> CddForm { get; set; }

        [JsonPropertyName("linkId")]
        public string LinkId { get; set; }
    }
}
