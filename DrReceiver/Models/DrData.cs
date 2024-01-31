using System.Text.Json.Serialization;

namespace DrReceiver.Models;

public class DrData
{
    [JsonPropertyName("gw-from")] public string GwFrom { get; set; }
    [JsonPropertyName("gw-to")] public string GwTo { get; set; }
    [JsonPropertyName("gw-dlr-status")] public string GwDlrStatus { get; set; }
    [JsonPropertyName("gw-error-code")] public string GwErrorCode { get; set; }
    [JsonPropertyName("gw-msgid")] public string GwMsgId { get; set; }
}
