using System.ComponentModel.DataAnnotations.Schema;
[Table("blog")]
public class Blog
{
    public int Id { get; set; }
    public string? Content { get; set; } 
    public string? ImageURL { get; set; } =string.Empty;
    public DateTime PublishedDate { get; set; }
    public ICollection<Comment> Comments { get; set; } = [];
        
    [ForeignKey("User")]
    public int UserId { get; set; }
    public User? User { get; set; }

 
}