using System.Text.Json.Serialization;

namespace tecBackend.Dtos;

public class TokenResponse
{
    [JsonPropertyName("accessToken")]
    public string AccessToken { get; set; }

    [JsonPropertyName("refreshToken")]
    public string RefreshToken { get; set; }

    [JsonPropertyName("role")]
    public string Role { get; set; } = "Worker"; 

    
    public TokenResponse(string accessToken, string refreshToken, string role)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
        Role = role;
    }

    
    public TokenResponse(string accessToken, string refreshToken)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
        Role = "Worker";
    }
}
