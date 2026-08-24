using System.ComponentModel.DataAnnotations;

namespace tecBackend.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public List<Post> Posts { get; set; } = new List<Post>();
}