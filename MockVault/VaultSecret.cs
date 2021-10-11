using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MockVault
{
    public class GetVaultDataResponse
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("data")]
        public AccessKeyData AccessKeyData { get; set; }
    }

    public class AccessKeyData
    {
        [JsonPropertyName("access_key")]
        public string AccessKey { get; set; }
    }
}
