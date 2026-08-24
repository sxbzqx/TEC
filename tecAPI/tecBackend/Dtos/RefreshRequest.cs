using System.Text.Json.Serialization;

namespace tecBackend.Dtos;

public class RefreshRequest
{
    [JsonPropertyName("refreshToken")] 
    public string RefreshToken { get; set; } = string.Empty;
}