namespace AsaBloggerApi.Src.Models{
public class CommentModel
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public DateTime PublishedDate { get; set; }
    public int UserId { get; set; }
    public int BlogId { get; set; }
}
}