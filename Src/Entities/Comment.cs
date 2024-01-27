using System.ComponentModel.DataAnnotations.Schema;
[Table("comment")]
public class Comment
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public DateTime PublishedDate { get; set; }
        
    [ForeignKey("User")]
    public int UserId { get; set; }
    public User? User { get; set; }

    [ForeignKey("Blog")]
    public int BlogId { get; set; }
    public Blog? Blog { get; set; }
}