namespace tecBackend.Models;

using System.ComponentModel.DataAnnotations.Schema;

[Table("user_sessions")]
public class UserSession
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime ExpiryTime { get; set; }
}
